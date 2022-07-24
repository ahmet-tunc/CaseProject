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
    [Route("api/IT/Import/")]
    [Authorize]
    public class ImportITController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ImportITController> _localizer;

        public ImportITController(IHistoryService historyService, IStringLocalizer<ImportITController> localizer, IMapper mapper)
        {
            _historyService = historyService;
            _localizer = localizer;
            _mapper = mapper;
        }


        [HttpPost("ImportFileAsync")]
        public async Task<IActionResult> ImportFileAsync(IFormFile jsonFile)
        {
            if (!jsonFile.FileName.EndsWith(".json"))
                return BadRequest();

            using var content = new StreamReader(jsonFile.OpenReadStream());
            var listModel = _mapper.Map<List<History>>(JsonConvert.DeserializeObject<List<HistoryITAddDto>>(content.ReadToEnd()));
            listModel.ForEach(x => x.GetType().GetProperty("CreatedUserId").SetValue(x, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            listModel.ForEach(x => x.GetType().GetProperty("UpdatedUserId").SetValue(x, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));

            if (listModel.Count == 0)
                return BadRequest();

            var result = await _historyService.AddListAsync(listModel, Convert.ToInt32(_localizer["Language"]));

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
