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
    [Authorize(Policy = ConstantClass.CommissionRolePolicy)]
    public class CommissionFinalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommissionFinalController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridParams gridParams, [FromQuery] CommissionAllSearchParams searchParams, string? sortParams = null)
        {
            try
            {
                Expression<Func<CommissionFinal, bool>> commissionExpression = obj => true;

                if (searchParams.TransDate != null)
                {
                    commissionExpression = obj => obj.TransDate == searchParams.TransDate;
                }

                if (searchParams.CarrierId != null)
                {
                    Expression<Func<CommissionFinal, bool>> carrierExpression =
                    c => c.CarrierId == searchParams.CarrierId;

                    commissionExpression = ExpressionExtension<CommissionFinal>.AndAlso(commissionExpression, carrierExpression);
                }

                if (searchParams.Policy != null)
                {
                    Expression<Func<CommissionFinal, bool>> policyExpression =
                    c => c.Policy == searchParams.Policy;

                    commissionExpression = ExpressionExtension<CommissionFinal>.AndAlso(commissionExpression, policyExpression);
                }

                if (searchParams.TransType != null)
                {
                    Expression<Func<CommissionFinal, bool>> transTypeExpression =
                    c => c.TransType == searchParams.TransType;

                    commissionExpression = ExpressionExtension<CommissionFinal>.AndAlso(commissionExpression, transTypeExpression);
                }

                if (searchParams.CommPremium != null)
                {
                    Expression<Func<CommissionFinal, bool>> commPremiumExpression =
                    c => c.CommPremium == searchParams.CommPremium;

                    commissionExpression = ExpressionExtension<CommissionFinal>.AndAlso(commissionExpression, commPremiumExpression);
                }

                if (searchParams.CommOverrideRate != null)
                {
                    Expression<Func<CommissionFinal, bool>> commOverrideRateExpression =
                    c => c.CommOverrideRate == searchParams.CommOverrideRate;

                    commissionExpression = ExpressionExtension<CommissionFinal>.AndAlso(commissionExpression, commOverrideRateExpression);
                }

                if (searchParams.CommOverridePayment != null)
                {
                    Expression<Func<CommissionFinal, bool>> commOverridePaymentExpression =
                    c => c.CommOverridePayment == searchParams.CommOverridePayment;

                    commissionExpression = ExpressionExtension<CommissionFinal>.AndAlso(commissionExpression, commOverridePaymentExpression);
                }

                var pagedList = await _unitOfWork.CommissionFinal.GetAll(filter: commissionExpression, includeProperties: "Carrier,Product,Activity,PremiumMode", gridParams: gridParams, sortParams: sortParams);
                var list = _mapper.Map<IEnumerable<CommissionFinalDTO>>(pagedList);

                Response.AddPagination(pagedList.TotalCount);
                
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
                var record = _mapper.Map<CommissionFinalDTO>(await _unitOfWork.CommissionFinal.Get(obj => obj.Id == id, includeProperties: "Carrier,Product,Activity,PremiumMode"));

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
        public async Task<IActionResult> Post(CommissionFinalDTO commissionFinal)
        {
            try
            {
                var record = _mapper.Map<CommissionFinal>(commissionFinal);

                await _unitOfWork.CommissionFinal.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<CommissionFinalDTO>(record)
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
        public async Task<IActionResult> Put(CommissionFinalDTO commissionFinal)
        {
            try
            {
                var commissionFinalObject = _mapper.Map<CommissionFinal>(commissionFinal);
                var record = await _unitOfWork.CommissionFinal.Get(obj => obj.Id == commissionFinalObject.Id);

                if (record != null)
                {
                    _unitOfWork.CommissionFinal.Update(commissionFinalObject);
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
                var record = await _unitOfWork.CommissionFinal.Get(obj => obj.Id == id);
                if (record != null)
                {
                    await _unitOfWork.CommissionFinal.Remove(record);
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
