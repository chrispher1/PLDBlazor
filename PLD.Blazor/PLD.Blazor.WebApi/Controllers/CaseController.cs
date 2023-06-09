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
    [Authorize(Policy = ConstantClass.CaseRolePolicy)]
    public class CaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridParams gridParams, [FromQuery] CommissionAllSearchParams searchParams, string? sortParams = null) 
        {
            try
            {
                var list = _mapper.Map<IEnumerable<Case>, IEnumerable<CaseDTO>>(await _unitOfWork.Case.GetAll(includeProperties: "Carrier,Product,CaseStatus,CaseType,ProductType"));
                return Ok(list);
            }
            catch (Exception ex)
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
                var record = _mapper.Map<CaseDTO>(await _unitOfWork.Case.Get(obj => obj.Id == id, includeProperties: "Carrier,Product,CaseStatus,CaseType,ProductType"));

                if (record == null)
                {
                    return NotFound();
                }
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CaseDTO objectCase)
        {
            try
            {
                var record = _mapper.Map<Case>(objectCase);

                await _unitOfWork.Case.Add(record);
                await _unitOfWork.Save();

                return Ok(
                            _mapper.Map<CaseDTO>(record)
                        );
            }
            catch (Exception ex)
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
        public async Task<IActionResult> Put(CaseDTO objectCase) 
        {
            try
            {
                var caseObject = _mapper.Map<Case>(objectCase);

                var record = _mapper.Map<CaseDTO>(await _unitOfWork.Case.Get(obj => obj.Id == objectCase.Id, includeProperties: "Carrier,Product,CaseStatus,CaseType,ProductType"));
                if (record != null)
                {
                    _unitOfWork.Case.Update(caseObject);
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
                var record = await _unitOfWork.Case.Get(obj => obj.Id == id);
                if (record != null)
                {
                    await _unitOfWork.Case.Remove(record);
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
