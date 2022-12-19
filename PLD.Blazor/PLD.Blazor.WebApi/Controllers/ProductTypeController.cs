using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using Microsoft.AspNetCore.Authorization;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public sealed class ProductTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductTypeController(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitOfWork = unitofWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _mapper.Map<IEnumerable<ProductType>,IEnumerable<ProductTypeDTO>>(await _unitOfWork.ProductType.GetAll());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var record = _mapper.Map<ProductType, ProductTypeDTO>( await _unitOfWork.ProductType.Get(obj => obj.Id == id) );

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

        [HttpPost]
        public async Task<IActionResult> Post(ProductTypeDTO productType)
        {
            try
            {
                var productTypeObject = _mapper.Map<ProductTypeDTO, ProductType>(productType);
                await _unitOfWork.ProductType.Add(productTypeObject);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<ProductType, ProductTypeDTO>(productTypeObject)
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

        [Route("GetByCode/{code}")]
        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            var record = _mapper.Map<ProductType, ProductTypeDTO>(await _unitOfWork.ProductType.Get(obj => obj.Code == code));

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
        public async Task<IActionResult> GetByCodeAndNotID(string code, int id)
        {
            var record = _mapper.Map<IEnumerable<ProductType>, IEnumerable<ProductTypeDTO>>(await _unitOfWork.ProductType.GetAll(obj => obj.Code == code && obj.Id != id));
            return Ok(record);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductTypeDTO productType)
        {
            try
            {
                var productTypeObject = _mapper.Map<ProductTypeDTO, ProductType>(productType);

                var record = await _unitOfWork.ProductType.Get(obj => obj.Id == productTypeObject.Id);

                if (record != null)
                {
                    _unitOfWork.ProductType.Update(productTypeObject);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _unitOfWork.ProductType.Get(obj => obj.Id == id);
                if (record != null)
                {
                    await _unitOfWork.ProductType.Remove(record);
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
