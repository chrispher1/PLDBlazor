using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;

namespace PLD.Blazor.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrierController : ControllerBase
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

        [Route("GetById/{id:int}")]
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
                            StatusCode = StatusCodes.Status403Forbidden,
                            ErrorMessage = ex.Message.Substring(1, 100)
                        }
                   );
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(CarrierDTO carrier)
        {
            var carrierObject = _mapper.Map<CarrierDTO, Carrier>(carrier);

            var record = await _unitOfWork.Carrier.Get(obj => obj.Id == carrierObject.Id);

            if (record !=null)
            {
                _unitOfWork.Carrier.Update(carrierObject);
                await _unitOfWork.Save();
                return Ok(record);
            }
            else
            {
                return BadRequest(
                    new ErrorModelDTO()
                    {
                        StatusCode = StatusCodes.Status403Forbidden,
                        ErrorMessage = ConstantClass.NoRecordFound
                    }
                   );
            }
        }

    }
}
