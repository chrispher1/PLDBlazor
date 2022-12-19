using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Business.Repositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public sealed class ActivityController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ActivityController(
            IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<Activity>, IEnumerable<ActivityDTO>>(await _unitOfWork.Activity.GetAll());
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [Route("{code}")]
        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var record = _mapper.Map<Activity, ActivityDTO>(await _unitOfWork.Activity.Get(obj => obj.Code == code ) );
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{code}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                var record = await _unitOfWork.Activity.Get(obj => obj.Code == code);

                if (record != null ) {
                    await _unitOfWork.Activity.Remove(record);
                    await _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(
                                new ErrorModelDTO()
                                {
                                    StatusCode = StatusCodes.Status400BadRequest,
                                    ErrorMessage = ConstantClass.NoRecordFound
                                }
                               );
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                            }
                       );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ActivityDTO activity)
        {
            try
            {
                var record = _mapper.Map<ActivityDTO, Activity>(activity);
                await _unitOfWork.Activity.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<Activity, ActivityDTO>(record)
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                            }
                        );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ActivityDTO activity)
        {
            try
            {
                var record = await _unitOfWork.Activity.Get(obj => obj.Code == activity.Code);
                var activityObject = _mapper.Map<ActivityDTO, Activity>(activity);

                if (record != null)
                {
                    _unitOfWork.Activity.Update(activityObject);
                    await _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ConstantClass.NoRecordFound
                            }
                           );
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(
                           new ErrorModelDTO()
                           {
                               StatusCode = StatusCodes.Status400BadRequest,
                               ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                           }
                      );
            }
        }
    }
}
