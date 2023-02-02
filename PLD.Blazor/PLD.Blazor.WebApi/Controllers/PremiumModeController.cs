using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    public class PremiumModeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PremiumModeController(IMapper mapper, 
            IUnitOfWork unitOfWork) { 
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<PremiumMode>, IEnumerable<PremiumModeDTO>>(await _unitOfWork.PremiumMode.GetAll());
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{code}")]
        public async Task<IActionResult> Get( string code)
        {
            try
            {
                var record = _mapper.Map<PremiumMode, PremiumModeDTO>(await _unitOfWork.PremiumMode.Get(premiumMode => premiumMode.Code == code));
                
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
        public async Task<IActionResult> Post( PremiumModeDTO premiumMode)
        {
            try
            {
                var record = _mapper.Map<PremiumModeDTO, PremiumMode>(premiumMode);

                await _unitOfWork.PremiumMode.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<PremiumMode, PremiumModeDTO> (record)
                    );
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

        [HttpPut]
        public async Task<IActionResult> Put( PremiumModeDTO premiumMode)
        {
            try
            { 
                var record = await _unitOfWork.PremiumMode.Get( obj => obj.Code == premiumMode.Code );
                var premiumModeObject = _mapper.Map<PremiumModeDTO, PremiumMode> (premiumMode);
                
                if (record != null)
                {
                    _unitOfWork.PremiumMode.Update(premiumModeObject);
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
        [Route("{code}")]
        public async Task<IActionResult> Delete( string code)
        {
            try
            {
                var record = await _unitOfWork.PremiumMode.Get(obj => obj.Code == code);

                if( record != null )
                {
                    await _unitOfWork.PremiumMode.Remove(record);
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

        [HttpGet]
        [Route("GetByDescriptionAndNotByCode" +
            "/{description}"+
            "/{code}"
            )]
        public async Task<IActionResult> Get(string description, string code)
        {
            try
            {

                IEnumerable<PremiumModeDTO> record =
                    _mapper.Map<IEnumerable<PremiumModeDTO>>(
                        await _unitOfWork.PremiumMode.GetAll(obj => obj.Description == description && obj.Code != code)
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
    }
}
