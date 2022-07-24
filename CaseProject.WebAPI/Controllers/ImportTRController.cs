using AutoMapper;
using CaseProject.Business.Abstract;
using CaseProject.Entities.Concrete;
using CaseProject.Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CaseProject.WebAPI.Controllers
{
    [Route("api/TR/Import/")]
    [Authorize]

    public class ImportTRController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        private readonly IHistoryCategoryService _historyCategoryService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ImportTRController> _localizer;

        public ImportTRController(IHistoryService historyService, IHistoryCategoryService historyCategoryService, IStringLocalizer<ImportTRController> localizer, IMapper mapper)
        {
            _historyService = historyService;
            _historyCategoryService = historyCategoryService;
            _localizer = localizer;
            _mapper = mapper;
        }

        [HttpPost("ImportFileAsync")]
        public async Task<IActionResult> ImportFileAsync(IFormFile jsonFile)
        {
            if (!jsonFile.FileName.EndsWith(".json"))
                return BadRequest();

            using var content = new StreamReader(jsonFile.OpenReadStream());
            var listModel = _mapper.Map<List<History>>(JsonConvert.DeserializeObject<List<HistoryTRAddDto>>(content.ReadToEnd()));
            listModel.ForEach(x => x.CreatedUserId =  Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            listModel.ForEach(x => x.UpdatedUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));

            if (listModel.Count == 0)
                return BadRequest();

            var result = await _historyService.AddListAsync(listModel,Convert.ToInt32(_localizer["Language"]));

            if (result.Success)
            {
                return Ok(new
                {
                    Success = result.Success,
                    Message = result.Message
                });
            }
            return StatusCode(Response.StatusCode, (new
            {
                Success = result.Success,
                Message = result.Message
            }));
        }
    }
}
