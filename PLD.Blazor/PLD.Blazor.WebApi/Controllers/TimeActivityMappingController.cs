using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using System.Collections.Generic;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public class TimeActivityMappingController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TimeActivityMappingController(
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {   
                var list = _mapper.Map<IEnumerable<TimeActivityMapping>, IEnumerable<TimeActivityMappingDTO>>( await _unitOfWork.TimeActivityMapping.GetAll( includeProperties: ConstantClass.TimeActivityMappingExtendedProperties));
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var record = _mapper.Map<TimeActivityMapping, TimeActivityMappingDTO>( await _unitOfWork.TimeActivityMapping.Get(obj => obj.Id == id, includeProperties: ConstantClass.TimeActivityMappingExtendedProperties));

                if (record == null)
                {
                    return NotFound();
                }
                return Ok(record);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEnd" +
            "/{carrierId}" +
            "/{carrierActivity}" +
            "/{policyYearStart:int}" +
            "/{policyYearEnd:int}" +
            "/{carrierTime?}")]
        [HttpGet]        
        public async Task<IActionResult> Get(int carrierId, string carrierActivity, 
            int policyYearStart,
            int policyYearEnd,
            string? carrierTime=null)
        {
            try
            {
                TimeActivityMappingDTO? record = _mapper.Map<TimeActivityMapping, TimeActivityMappingDTO>(
                await _unitOfWork.TimeActivityMapping.Get(obj => (obj.CarrierId == carrierId && obj.CarrierTime == carrierTime)
                && (obj.CarrierActivity == carrierActivity)
                && (obj.PolicyYearStart == policyYearStart && obj.PolicyYearEnd == policyYearEnd)
                )
                );

                if (record != null)
                {
                    return Ok(record);
                }
                else
                {
                    return NotFound(
                        new ErrorModelDTO()
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ErrorMessage = ConstantClass.NoRecordFound
                        }
                        );
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetByCarrierIdCarrierTimeCarrierActivityPolicyYearStartPolicyYearEndAndNotById" +
            "/{carrierId}" +
            "/{carrierActivity}" +
            "/{policyYearStart:int}" +
            "/{policyYearEnd:int}" +
            "/{id:int}" +
            "/{carrierTime?}")]
        [HttpGet]
        public async Task<IActionResult> Get(int carrierId, string carrierActivity,
            int policyYearStart,
            int policyYearEnd,
            int id,
            string? carrierTime = null)
        {
            try
            {
                IEnumerable<TimeActivityMappingDTO>? record = _mapper.Map<IEnumerable<TimeActivityMapping>, 
                    IEnumerable<TimeActivityMappingDTO>>(
                    await _unitOfWork.TimeActivityMapping.GetAll(obj => (obj.CarrierId == carrierId && obj.CarrierTime == carrierTime)
                    && (obj.CarrierActivity == carrierActivity)
                    && (obj.PolicyYearStart == policyYearStart && obj.PolicyYearEnd == policyYearEnd)
                    && (obj.Id != id)
                    )
                );

                if (record.Count() != 0)
                {
                    return Ok(record);
                }
                else
                {
                    return NotFound(
                        new ErrorModelDTO()
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ErrorMessage = ConstantClass.NoRecordFound
                        }
                        );
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post (TimeActivityMappingDTO timeActivityMapping)
        {
            try
            {
                var record = _mapper.Map<TimeActivityMappingDTO, TimeActivityMapping>(timeActivityMapping);

                await _unitOfWork.TimeActivityMapping.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<TimeActivityMapping, TimeActivityMappingDTO>(record)
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
        public async Task<IActionResult> Put(TimeActivityMappingDTO timeActivityMapping)
        {
            try
            {
                var timeActivityMappingObject = _mapper.Map<TimeActivityMappingDTO, TimeActivityMapping>(timeActivityMapping);
                var record = await _unitOfWork.TimeActivityMapping.Get( obj => obj.Id == timeActivityMappingObject.Id );

                if (record != null )
                {
                    _unitOfWork.TimeActivityMapping.Update(timeActivityMappingObject);
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

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _unitOfWork.TimeActivityMapping.Get( obj => obj.Id == id );

                if (record != null)
                {
                    await _unitOfWork.TimeActivityMapping.Remove(record);
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
            catch(Exception ex)
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
