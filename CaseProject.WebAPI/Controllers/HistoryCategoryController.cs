using AutoMapper;
using CaseProject.Business.Abstract;
using CaseProject.Entities.Concrete;
using CaseProject.WebAPI.Controllers.Base;
using CaseProject.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CaseProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryCategoryController : BaseController<HistoryCategory, HistoryCategoryModel, HistoryCategoryController>
    {
        private readonly IStringLocalizer<HistoryCategoryController> _localizer;
        private readonly IHistoryCategoryService _historyCategoryService;
        private readonly IMapper _mapper;

        public HistoryCategoryController(IHistoryCategoryService historyCategoryService, IStringLocalizer<HistoryCategoryController> localizer, IMapper mapper) : base(historyCategoryService, localizer, mapper)
        {
            _historyCategoryService = historyCategoryService;
            _localizer = localizer;
            _mapper = mapper;
        }
    }
}
