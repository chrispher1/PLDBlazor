using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using System.Security.AccessControl;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public class CaseStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CaseStatusController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<CaseStatus>, IEnumerable<CaseStatusDTO>>(await _unitOfWork.CaseStatus.GetAll());
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
                var record = await _unitOfWork.CaseStatus.Get( obj => obj.Id == id );

                if ( record == null )
                {
                    return NotFound();
                }

                return Ok(
                    _mapper.Map<CaseStatusDTO>(record)
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var record = await _unitOfWork.CaseStatus.Get( obj => obj.Name == name );
                if ( record == null ) 
                {
                    return NotFound();
                }

                return Ok(
                    _mapper.Map<CaseStatusDTO>(record)
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByNameAndNotById/{name}/{id:int}")]
        public async Task<IActionResult> Get(string name, int id)
        {
            try
            {
                IEnumerable<CaseStatus> record = await _unitOfWork.CaseStatus.GetAll( obj => obj.Name == name && obj.Id != id );

                if ( record.Count() != 0 )
                {
                    return Ok(
                        _mapper.Map<IEnumerable<CaseStatusDTO>>(record)
                        ); 
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
        public async Task<IActionResult> Post( CaseStatusDTO caseStatus)
        {
            try
            {
                var record = _mapper.Map<CaseStatus>(caseStatus);

                await _unitOfWork.CaseStatus.Add(record);
                await _unitOfWork.Save();

                return Ok(
                            _mapper.Map<CaseStatusDTO>(record)
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
        public async Task<IActionResult> Put( CaseStatusDTO caseStatus)
        {
            try
            {
                var caseStatusObject = _mapper.Map<CaseStatus>(caseStatus);

                var record = await _unitOfWork.CaseStatus.Get(obj => obj.Id == caseStatus.Id);

                if(record != null)
                {
                    _unitOfWork.CaseStatus.Update(caseStatusObject);
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
                var record = await _unitOfWork.CaseStatus.Get(obj => obj.Id == id);

                if (record != null)
                {
                    await _unitOfWork.CaseStatus.Remove(record);
                    await _unitOfWork.Save();
                    return Ok();
;               }
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
