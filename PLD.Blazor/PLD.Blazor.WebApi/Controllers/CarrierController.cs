using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using Microsoft.Extensions.Options;

namespace PLD.Blazor.WebApi.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]    
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public sealed class CarrierController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarrierController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _mapper.Map<IEnumerable<Carrier>,IEnumerable<CarrierDTO>>( await _unitOfWork.Carrier.GetAll());            
            return Ok(list);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var record = _mapper.Map<Carrier, CarrierDTO>(await _unitOfWork.Carrier.Get(obj => obj.Id == id));
            return Ok(record);
        }

        [Route("GetByCode/{code}")]
        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            var record = _mapper.Map<Carrier, CarrierDTO>(await _unitOfWork.Carrier.Get(obj => obj.CarrierCode == code));

            if (record != null)
            {
                return Ok(record);
            }

            return BadRequest(
                    new ErrorModelDTO()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        ErrorMessage = ConstantClass.NoRecordFound
                    }
                   );
        }

        [Route("GetByCodeAndNotID/{code}/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string code, int id)
        {
            var record = _mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierDTO>>(await _unitOfWork.Carrier.GetAll(obj => obj.CarrierCode == code && obj.Id != id));
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarrierDTO carrier)
        {
            try
            {
                var carrierObject = _mapper.Map<CarrierDTO, Carrier>(carrier);                
                
                await _unitOfWork.Carrier.Add(carrierObject);
                await _unitOfWork.Save();

                return Ok(
                        _mapper.Map<Carrier, CarrierDTO>(carrierObject)
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
        public async Task<IActionResult> Put(CarrierDTO carrier)
        {
            try
            {
                var carrierObject = _mapper.Map<CarrierDTO, Carrier>(carrier);

                var record = await _unitOfWork.Carrier.Get(obj => obj.Id == carrierObject.Id);

                if (record != null)
                {
                    _unitOfWork.Carrier.Update(carrierObject);
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

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _unitOfWork.Carrier.Get(obj => obj.Id == id);
                if (record != null)
                {
                    await _unitOfWork.Carrier.Remove(record);
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
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1 )
                            }
                       );
            }            
        }
    }
}
