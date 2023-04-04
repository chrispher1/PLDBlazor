using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public class StateCodeController: ControllerBase
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion
        public StateCodeController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list =  _mapper.Map<IEnumerable<StateCode>, IEnumerable<StateCodeDTO>>( await _unitOfWork.StateCode.GetAll()) ;
                return Ok(list);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var record = await _unitOfWork.StateCode.Get(obj => obj.Code == code);                

                if (record == null)
                {
                    return NotFound();
                }
                return Ok( _mapper.Map<StateCodeDTO>(record));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post( StateCodeDTO statusCode)
        {
            try
            {
                var record = _mapper.Map<StateCode>(statusCode);
                await _unitOfWork.StateCode.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<StateCode, StateCodeDTO>(record)
                    );
            }
            catch(Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1) 
                            }
                        );
                }
                return BadRequest();                
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put( StateCodeDTO stateCode)
        {
            try
            {
                var record = await _unitOfWork.StateCode.Get(obj => obj.Code == stateCode.Code);
                var statusCodeObject = _mapper.Map<StateCodeDTO, StateCode>(stateCode);

                if (record != null)
                {
                    _unitOfWork.StateCode.Update(statusCodeObject);
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
                if (ex.InnerException != null)
                {
                    return BadRequest(
                           new ErrorModelDTO()
                           {
                               StatusCode = StatusCodes.Status400BadRequest,
                               ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                           }
                      );
                }
                return BadRequest();
            }
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                var record = await _unitOfWork.StateCode.Get(obj => obj.Code == code);

                if (record != null)
                {
                    await _unitOfWork.StateCode.Remove(record);
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
                if (ex.InnerException != null)
                {
                    return BadRequest(
                           new ErrorModelDTO()
                           {
                               StatusCode = StatusCodes.Status400BadRequest,
                               ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                           }
                      );
                }
                return BadRequest();
            }
        }
    }
}
