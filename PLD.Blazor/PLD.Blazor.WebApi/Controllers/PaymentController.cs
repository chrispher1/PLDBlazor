using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using System.Linq.Expressions;
using PLD.Blazor.Common.Utilities.ExtensionMethods;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.PaymentRolePolicy)]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridParams gridParams, [FromQuery] PaymentSearchParams searchParams, string? sortParams = null)
        {
            try
            {
                Expression<Func<Payment, bool>> paymentExpression = obj => true;

                if (searchParams.CarrierId != null)
                {
                    paymentExpression = obj => obj.CarrierId == searchParams.CarrierId;
                }

                if (searchParams.PaymentDate != null)
                {
                    Expression<Func<Payment, bool>> paymentDateExpression =
                    c => c.PaymentDate == searchParams.PaymentDate;

                    paymentExpression = ExpressionExtension<Payment>.AndAlso(paymentExpression, paymentDateExpression);
                }

                if (searchParams.CheckWireNumber != null)
                {
                    Expression<Func<Payment, bool>> checkWireNumberExpression =
                    c => c.CheckWireNumber == searchParams.CheckWireNumber;

                    paymentExpression = ExpressionExtension<Payment>.AndAlso(paymentExpression, checkWireNumberExpression);
                }

                if (searchParams.DepositDate != null)
                {
                    Expression<Func<Payment, bool>> depositDateExpression =
                    c => c.DepositDate == searchParams.DepositDate;

                    paymentExpression = ExpressionExtension<Payment>.AndAlso(paymentExpression, depositDateExpression);
                }

                if (searchParams.EFTOverrideAmount != null)
                {
                    Expression<Func<Payment, bool>> eFTOverrideAmountExpression =
                    c => c.EFTOverrideAmount == searchParams.EFTOverrideAmount;

                    paymentExpression = ExpressionExtension<Payment>.AndAlso(paymentExpression, eFTOverrideAmountExpression);
                }                

                var pagedList = (await _unitOfWork.Payment.GetAll(filter: paymentExpression, includeProperties: ConstantClass.PaymentExtendedProperties, gridParams: gridParams, sortParams: sortParams) as PagedList<Payment>);
                var list = _mapper.Map<IEnumerable<PaymentDTO>>(pagedList);

                Response.AddPagination(pagedList.TotalCount);
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
                var record = _mapper.Map<Payment?, PaymentDTO?>(await _unitOfWork.Payment.Get(obj => obj.Id == id, includeProperties: ConstantClass.PaymentExtendedProperties));

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
        public async Task<IActionResult> Post(PaymentDTO payment)
        {
            try
            {
                var record = _mapper.Map<PaymentDTO, Payment>(payment);
                await _unitOfWork.Payment.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<Payment, PaymentDTO>(record)
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
        public async Task<IActionResult> Put(PaymentDTO payment)
        {
            try
            {
                var paymentObject = _mapper.Map<Payment>(payment);
                var record = await _unitOfWork.Payment.Get(obj => obj.Id == paymentObject.Id);

                if (record != null)
                {
                    _unitOfWork.Payment.Update(paymentObject);
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
                var record = await _unitOfWork.Payment.Get(obj => obj.Id == id);
                if (record != null)
                {
                    await _unitOfWork.Payment.Remove(record);
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
