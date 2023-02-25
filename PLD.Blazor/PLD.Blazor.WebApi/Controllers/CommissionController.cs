using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using System.Linq;

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
        private readonly IMapper _mapper;
        
        #endregion
        public CommissionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var commissionList = _unitOfWork.CommissionError.GetAll(includeProperties: "Carrier,Product,Activity,PremiumMode")
                    .GetAwaiter().GetResult().Select(obj => new CommissionDTO
                    {
                        Id = obj.Id,
                        TransDate = obj.TransDate,
                        Carrier = new CarrierDTO { Id = obj.Carrier.Id, Name =obj.Carrier.Name , 
                            CarrierCode = obj.Carrier.CarrierCode },
                        Policy = obj.Policy,
                        Activity = new ActivityDTO { Description = obj.Activity.Description } ,
                        CommPremium = obj.CommPremium,
                        CommOverrideRate = obj.CommOverrideRate,
                        CommOverridePayment = obj.CommOverridePayment,
                        TableName = EnumClass.Commission.Error
                    })

                .Union
                (
                    _unitOfWork.CommissionFinal.GetAll(includeProperties: "Carrier,Product,Activity,PremiumMode")
                    .GetAwaiter().GetResult().Select(obj => new CommissionDTO
                    {
                        Id = obj.Id,
                        TransDate = obj.TransDate,
                        Carrier = new CarrierDTO
                        {
                            Id = obj.Carrier.Id,
                            Name = obj.Carrier.Name,
                            CarrierCode = obj.Carrier.CarrierCode
                        },
                        Policy = obj.Policy,
                        Activity = new ActivityDTO { Description = obj.Activity.Description } ,
                        CommPremium = obj.CommPremium,
                        CommOverrideRate = obj.CommOverrideRate,
                        CommOverridePayment = obj.CommOverridePayment,
                        TableName = EnumClass.Commission.Final
                    })
                    );

                return Ok(commissionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
