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
        
        #endregion
        public CommissionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var commissionList = await _unitOfWork.Commission.GetAll(includeProperties: "Carrier,Product,Activity,PremiumMode");
                
                return Ok(
                            commissionList
                        );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
