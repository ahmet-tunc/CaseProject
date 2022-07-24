using AutoMapper;
using CaseProject.Business.Abstract.BaseServices;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CaseProject.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class BaseController<T,TMap,TController> : ControllerBase where T:class,IEntity,new()
    {
        private readonly IBaseService<T> _baseService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<TController> _localizer;
        private readonly int _lang;

        public BaseController(IBaseService<T> baseService, IStringLocalizer<TController> localizer, IMapper mapper)
        {
            _baseService = baseService;
            _localizer = localizer;
            _lang = Convert.ToInt32(_localizer["Language"]);
            _mapper = mapper;
        }


        [HttpGet("GetAllAsync")]
        public virtual async Task<IActionResult> GetAllAsync(int page = 1, int pagesize = 10, bool includeRelationShips = false)
        {
            var result = await _baseService.GetAllAsync(page,pagesize, _lang, includeRelationShips);
            if (result.Success)
            {
                return Ok(new
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data
                });
            }

            return StatusCode(Response.StatusCode, (new
            {
                Success = result.Success,
                Message = result.Message,
            }));
        }


        [HttpGet("GetByIdAsync")]
        public virtual async Task<IActionResult> GetByIdAsync(int id, bool includeRelationShips = false)
        {
            var result = await _baseService.GetByIdAsync(id,_lang, includeRelationShips);
            if (result.Success)
            {
                return Ok(new
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data
                });
            }
            return StatusCode(Response.StatusCode, (new
            {
                Success = result.Success,
                Message = result.Message,
            }));
        }

        [HttpPost("AddAsync")]
        public virtual async Task<IActionResult> AddAsync([FromBody] TMap model)
        {
            model.GetType().GetProperty("CreatedUserId").SetValue(model, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            model.GetType().GetProperty("UpdatedUserId").SetValue(model, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var result = await _baseService.AddAsync(_mapper.Map<T>(model), _lang);
            if (result.Success)
            {
                return Ok(new
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data
                });
            }
            return StatusCode(Response.StatusCode, (new
            {
                Success = result.Success,
                Message = result.Message,
            }));
        }


        [HttpPost("AddListAsync")]
        public virtual async Task<IActionResult> AddListAsync([FromBody] List<TMap> listModel)
        {
            listModel.ForEach(x => x.GetType().GetProperty("CreatedUserId").SetValue(x, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
            var result = await _baseService.AddListAsync(_mapper.Map<List<T>>(listModel), _lang);
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
                Message = result.Message,
            }));
        }


        [HttpPut("UpdateAsync")]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] TMap model)
        {
            model.GetType().GetProperty("UpdatedUserId").SetValue(model, Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var result = await _baseService.UpdateAsync(_mapper.Map<T>(model));
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
                Message = result.Message,
            }));
        }


        [HttpDelete("DeleteAsync")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _baseService.DeleteAsync(id, _lang);
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
                Message = result.Message,
            }));
        }


        [HttpDelete("DeleteListAsync")]
        public virtual async Task<IActionResult> DeleteListAsync(int[] ids)
        {
            var result = await _baseService.DeleteListAsync(ids, _lang);
            if (result.Success)
            {
                return Ok(new
                {
                    Success = result.Success,
                    Message = result.Message,
                });
            }
            return StatusCode(Response.StatusCode, (new
            {
                Success = result.Success,
                Message = result.Message,
            }));
        }
    }
}
