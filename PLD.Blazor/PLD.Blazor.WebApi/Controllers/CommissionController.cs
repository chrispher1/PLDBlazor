using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using System.Linq;
using PLD.Blazor.Common.Utilities.ExtensionMethods;
using System.Linq.Expressions;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.CommissionRolePolicy)]
    public class CommissionController : ControllerBase
    {
        #region Fields
        
        private readonly IUnitOfWork _unitOfWork;
        
        #endregion
        public CommissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridParams gridParams, [FromQuery] CommissionAllSearchParams searchParams, string? sortParams=null)
        {
            try
            {
                Expression<Func<CommissionDTO, bool>> commissionExpression = obj => true;

                if (searchParams.TransDate != null)
                {
                    commissionExpression = obj => obj.TransDate == searchParams.TransDate;
                }

                if (searchParams.CarrierId != null)
                {
                    Expression<Func<CommissionDTO, bool>> carrierExpression =
                    c => c.CarrierId == searchParams.CarrierId;

                    commissionExpression = ExpressionExtension<CommissionDTO>.AndAlso(commissionExpression, carrierExpression);
                }

                if (searchParams.Policy != null)
                {
                    Expression<Func<CommissionDTO, bool>> policyExpression =
                    c => c.Policy == searchParams.Policy;

                    commissionExpression = ExpressionExtension<CommissionDTO>.AndAlso(commissionExpression, policyExpression);
                }

                if (searchParams.TransType != null)
                {
                    Expression<Func<CommissionDTO, bool>> transTypeExpression =
                    c => c.TransType == searchParams.TransType;

                    commissionExpression = ExpressionExtension<CommissionDTO>.AndAlso(commissionExpression, transTypeExpression);
                }

                if (searchParams.CommPremium != null)
                {
                    Expression<Func<CommissionDTO, bool>> commPremiumExpression =
                    c => c.CommPremium == searchParams.CommPremium;

                    commissionExpression = ExpressionExtension<CommissionDTO>.AndAlso(commissionExpression, commPremiumExpression);
                }

                if (searchParams.CommOverrideRate != null)
                {
                    Expression<Func<CommissionDTO, bool>> commOverrideRateExpression =
                    c => c.CommOverrideRate == searchParams.CommOverrideRate;

                    commissionExpression = ExpressionExtension<CommissionDTO>.AndAlso(commissionExpression, commOverrideRateExpression);
                }

                if (searchParams.CommOverridePayment != null)
                {
                    Expression<Func<CommissionDTO, bool>> commOverridePaymentExpression =
                    c => c.CommOverridePayment == searchParams.CommOverridePayment;

                    commissionExpression = ExpressionExtension<CommissionDTO>.AndAlso(commissionExpression, commOverridePaymentExpression);
                }

                var pagedList = (await _unitOfWork.Commission.GetAll(filter: commissionExpression, includeProperties: "Carrier,Product,Activity,PremiumMode", gridParams: gridParams,sortParams: sortParams) as PagedList<CommissionDTO>);
                var list = (pagedList as IEnumerable<CommissionDTO>);

                Response.AddPagination(pagedList.TotalCount);
                
                return Ok(
                            list
                        );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
