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
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public class CaseTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CaseTypeController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<CaseType>, IEnumerable<CaseTypeDTO>>(await _unitOfWork.CaseType.GetAll());
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
                var record = await _unitOfWork.CaseType.Get(obj => obj.Id == id);

                if (record == null)
                {
                    return NotFound();
                }

                return Ok(
                    _mapper.Map<CaseTypeDTO>(record)
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
                var record = await _unitOfWork.CaseType.Get(obj => obj.Name == name);
                if (record == null)
                {
                    return NotFound();
                }

                return Ok(
                    _mapper.Map<CaseTypeDTO>(record)
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
                IEnumerable<CaseType> record = await _unitOfWork.CaseType.GetAll(obj => obj.Name == name && obj.Id != id);

                if (record.Count() != 0)
                {
                    return Ok(
                        _mapper.Map<IEnumerable<CaseTypeDTO>>(record)
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
        public async Task<IActionResult> Post(CaseTypeDTO caseType)
        {
            try
            {
                var record = _mapper.Map<CaseType>(caseType);

                await _unitOfWork.CaseType.Add(record);
                await _unitOfWork.Save();

                return Ok(
                            _mapper.Map<CaseTypeDTO>(record)
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
        public async Task<IActionResult> Put(CaseTypeDTO caseType)
        {
            try
            {
                var caseTypeObject = _mapper.Map<CaseType>(caseType);

                var record = await _unitOfWork.CaseType.Get(obj => obj.Id == caseType.Id);

                if (record != null)
                {
                    _unitOfWork.CaseType.Update(caseTypeObject);
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
                var record = await _unitOfWork.CaseType.Get(obj => obj.Id == id);

                if (record != null)
                {
                    await _unitOfWork.CaseType.Remove(record);
                    await _unitOfWork.Save();
                    return Ok();
                    ;
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
