using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Common;
using Microsoft.AspNetCore.Authorization;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public sealed class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(await _unitOfWork.Role.GetAll());
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
                var record = await _unitOfWork.Role.Get(obj => obj.Id == id, includeProperties: ConstantClass.RoleExtendedProperties);

                if (record == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<Role, RoleDTO> (record));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("GetByName/{name}")]
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var record = await _unitOfWork.Role.Get(obj => obj.Name == name, includeProperties: ConstantClass.RoleExtendedProperties);

                if (record != null)
                {
                    return Ok(_mapper.Map<Role, RoleDTO>(record));
                }

                return NotFound(
                        new ErrorModelDTO()
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ErrorMessage = ConstantClass.NoRecordFound
                        }
                       );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetByNameAndNotID/{name}/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string name, int id)
        {
            try
            {
                var record = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDTO>>(await _unitOfWork.Role.GetAll(obj => obj.Id != id && obj.Name == name, includeProperties: ConstantClass.RoleExtendedProperties));
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoleDTO role)
        {
            try
            {
                var roleObject = _mapper.Map<RoleDTO, Role>(role);
                await _unitOfWork.Role.Add(roleObject);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<Role, RoleDTO>(roleObject)
                    );
            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException?.Message == null ? String.Empty :  ex.InnerException.Message[..^1]
                            }
                        );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(RoleDTO role)
        {
            try
            {
                var roleObject = _mapper.Map<RoleDTO, Role>(role);
                var record = await _unitOfWork.Role.Get(obj => obj.Id == role.Id);
                if (record != null)
                {
                    _unitOfWork.Role.Update(roleObject);
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
                                ErrorMessage = ex.InnerException?.Message == null ? String.Empty:ex.InnerException.Message[..^1]
                            }
                       );
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _unitOfWork.Role.Get(obj => obj.Id == id);

                if (record != null)
                {
                    await _unitOfWork.Role.Remove(record);
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
                                ErrorMessage = ex.InnerException?.Message == null ? String.Empty : ex.InnerException.Message[..^1]
                            }
                       );
            }
        }
    }
}
