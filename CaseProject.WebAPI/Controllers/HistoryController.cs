using AutoMapper;
using CaseProject.Business.Abstract;
using CaseProject.Entities.Concrete;
using CaseProject.WebAPI.Controllers.Base;
using CaseProject.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CaseProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HistoryController : BaseController<History,HistoryModel,HistoryController>
    {
        private readonly IStringLocalizer<HistoryController> _localizer;
        private readonly IHistoryService _historyService;
        private readonly IMapper _mapper;

        public HistoryController(IHistoryService historyService, IStringLocalizer<HistoryController> localizer, IMapper mapper) :base(historyService, localizer, mapper)
        {
            _historyService = historyService;
            _localizer = localizer;
            _mapper = mapper;
        }
    }
}
