using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Common.Utilities.ExtensionMethods;
using System.Net;
using System.Linq.Expressions;
using System;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.CommissionRolePolicy)]
    public class CommissionErrorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CommissionErrorController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridParams gridParams, [FromQuery] CommissionErrorSearchParams searchParams, string? sortParams = null)
        {
            try
            {                
                Expression<Func<CommissionError,bool>> commissionExpression = obj => true;

                if (searchParams.TransDate != null)
                {
                    commissionExpression = obj => obj.TransDate == searchParams.TransDate;
                }

                if (searchParams.CarrierId != null)
                {
                    Expression<Func<CommissionError, bool>> carrierExpression =
                    c => c.CarrierId == searchParams.CarrierId;

                    commissionExpression = ExpressionExtension<CommissionError>.AndAlso(commissionExpression, carrierExpression);
                }        

                if (searchParams.Policy != null)
                {
                    Expression<Func<CommissionError, bool>> policyExpression =
                    c => c.Policy == searchParams.Policy;

                    commissionExpression = ExpressionExtension<CommissionError>.AndAlso(commissionExpression, policyExpression);
                }

                if (searchParams.TransType != null)
                {
                    Expression<Func<CommissionError, bool>> transTypeExpression =
                    c => c.TransType == searchParams.TransType;

                    commissionExpression = ExpressionExtension<CommissionError>.AndAlso(commissionExpression, transTypeExpression);
                }

                if (searchParams.CommPremium != null)
                {
                    Expression<Func<CommissionError, bool>> commPremiumExpression =
                    c => c.CommPremium == searchParams.CommPremium;

                    commissionExpression = ExpressionExtension<CommissionError>.AndAlso(commissionExpression, commPremiumExpression);
                }

                if (searchParams.CommOverrideRate != null)
                {
                    Expression<Func<CommissionError, bool>> commOverrideRateExpression =
                    c => c.CommOverrideRate == searchParams.CommOverrideRate;

                    commissionExpression = ExpressionExtension<CommissionError>.AndAlso(commissionExpression, commOverrideRateExpression);
                }

                if (searchParams.CommOverridePayment != null)
                {
                    Expression<Func<CommissionError, bool>> commOverridePaymentExpression =
                    c => c.CommOverridePayment == searchParams.CommOverridePayment;

                    commissionExpression = ExpressionExtension<CommissionError>.AndAlso(commissionExpression, commOverridePaymentExpression);
                }
                
                var pagedList = (await _unitOfWork.CommissionError.GetAll(filter: commissionExpression, includeProperties: ConstantClass.CommissionErrorExtendedProperties, gridParams: gridParams,sortParams: sortParams) as PagedList<CommissionError>);
                var list = _mapper.Map<IEnumerable<CommissionErrorDTO>>(pagedList);

                Response.AddPagination(pagedList.TotalCount);
                return Ok(list);
            }
            catch(Exception ex)
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
                var record = _mapper.Map<CommissionErrorDTO>(await _unitOfWork.CommissionError.Get(obj => obj.Id == id, includeProperties: ConstantClass.CommissionErrorExtendedProperties));
                
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
        public async Task<IActionResult> Post(CommissionErrorDTO commissionError)
        {
            try
            {
                var record = _mapper.Map<CommissionError>(commissionError);

                await _unitOfWork.CommissionError.Add(record);
                await _unitOfWork.Save();
                return Ok(
                    _mapper.Map<CommissionErrorDTO>(record)
                    );
            }
            catch(Exception ex)
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
        public async Task<IActionResult> Put(CommissionErrorDTO commissionError)
        {
            try
            {
                var commissionErrorObject = _mapper.Map<CommissionError>(commissionError);
                var record = await _unitOfWork.CommissionError.Get( obj => obj.Id == commissionErrorObject.Id );

                if ( record != null)
                {
                    _unitOfWork.CommissionError.Update(commissionErrorObject);
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
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var record = await _unitOfWork.CommissionError.Get( obj => obj.Id==id );
                if ( record != null )
                {
                    await _unitOfWork.CommissionError.Remove(record);
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
    }
}
