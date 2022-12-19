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
    public sealed class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await _unitOfWork.Product.GetAll(includeProperties: "Carrier,ProductType"));
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
                var record = _mapper.Map<Product, ProductDTO>(await _unitOfWork.Product.Get(obj => obj.Id == id, includeProperties: "Carrier,ProductType"));
                
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

        [Route("GetByCode/{code}")]
        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var record = _mapper.Map<Product, ProductDTO>(await _unitOfWork.Product.Get(obj => obj.Code == code, includeProperties: "Carrier,ProductType"));

                if (record != null)
                {
                    return Ok(record);
                }

                return NotFound(
                        new ErrorModelDTO()
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ErrorMessage = ConstantClass.NoRecordFound
                        }
                       );
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("GetByCodeAndNotID/{code}/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string code, int id)
        {
            try 
            {
                var record = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await _unitOfWork.Product.GetAll(obj => obj.Id != id && obj.Code == code, includeProperties: "Carrier,ProductType"));
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO product)
        {
            try
            {
                var record = _mapper.Map<ProductDTO, Product>(product);
                await _unitOfWork.Product.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<Product, ProductDTO>(record)
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
        public async Task<IActionResult> Put(ProductDTO product)
        {
            try
            {
                var productObject = _mapper.Map<ProductDTO, Product>(product);
                var record = await _unitOfWork.Product.Get(obj => obj.Id == product.Id);
                if (record != null)
                {
                    _unitOfWork.Product.Update(productObject);
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
                var record = await _unitOfWork.Product.Get(obj => obj.Id == id);

                if (record != null)
                {
                    await _unitOfWork.Product.Remove(record);
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
