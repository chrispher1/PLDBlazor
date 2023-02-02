using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize(Policy = ConstantClass.CommissionRolePolicy)]
    public class CommissionErrorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommissionErrorController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<CommissionErrorDTO>>(await _unitOfWork.CommissionError.GetAll(includeProperties: "Carrier,Product,Activity,PremiumMode"));

                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var record = _mapper.Map<CommissionErrorDTO>(await _unitOfWork.CommissionError.Get(obj => obj.Id == id, includeProperties: "Carrier,Product,Activity,PremiumMode"));
                
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

        [HttpPost]
        public async Task<IActionResult> Post(CommissionErrorDTO commissionError)
        {
            try
            {
                var record = _mapper.Map<CommissionError>(commissionError);

                await _unitOfWork.CommissionError.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<CommissionErrorDTO>(record)
                    );
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new ErrorModelDTO()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        ErrorMessage = ex?.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                    }
                    );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CommissionErrorDTO commissionError)
        {
            try
            {
                var commissionErrorObject = _mapper.Map<CommissionError>(commissionError);
                var record = await _unitOfWork.CommissionError.Get( obj => obj.Id == commissionErrorObject.Id );

                if ( record != null)
                {
                    _unitOfWork.CommissionError.Update(commissionErrorObject);
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

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _unitOfWork.CommissionError.Get( obj => obj.Id==id );
                if ( record != null )
                {
                    await _unitOfWork.CommissionError.Remove(record);
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
