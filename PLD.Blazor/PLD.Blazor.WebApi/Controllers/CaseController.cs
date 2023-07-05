using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using PLD.Blazor.Common.Utilities.ExtensionMethods;
using System.Linq.Expressions;


namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.CaseRolePolicy)]
    public class CaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GridParams gridParams, [FromQuery] CaseAllSearchParams searchParams, string? sortParams = null) 
        {
            try
            {
                Expression<Func<Case, bool>> caseExpression = obj => true;

                if (searchParams.CarrierId != null)
                {
                    Expression<Func<Case, bool>> carrierExpression =
                    c => c.CarrierId == searchParams.CarrierId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, carrierExpression);

                }

                if (searchParams.Policy != null)
                {
                    Expression<Func<Case, bool>> policyExpression =
                    c => c.Policy == searchParams.Policy;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, policyExpression);
                }

                if (searchParams.StatusId != null)
                {
                    Expression<Func<Case, bool>> statusExpression =
                    c => c.StatusId == searchParams.StatusId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, statusExpression);
                }

                if (searchParams.ProductTypeId != null)
                {
                    Expression<Func<Case, bool>> productTypeExpression =
                    c => c.ProductTypeId == searchParams.ProductTypeId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, productTypeExpression);
                }

                if (searchParams.FaceAmount != null)
                {
                    Expression<Func<Case, bool>> faceAmountExpression =
                    c => c.FaceAmount == searchParams.FaceAmount;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, faceAmountExpression);
                }

                if (searchParams.AnnualizedPremium != null)
                {
                    Expression<Func<Case, bool>> annualizedPremiumExpression =
                    c => c.AnnualizedPremium == searchParams.AnnualizedPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, annualizedPremiumExpression);
                }

                if (searchParams.TargetPremium != null)
                {
                    Expression<Func<Case, bool>> targetPremiumExpression =
                    c => c.TargetPremium == searchParams.TargetPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, targetPremiumExpression);
                }

                if (searchParams.ModalPremium != null)
                {
                    Expression<Func<Case, bool>> modalPremiumExpression =
                    c => c.ModalPremium == searchParams.ModalPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, modalPremiumExpression);
                }

                if (searchParams.PlacementDate != null)
                {
                    Expression<Func<Case, bool>> placementDateExpression =
                    c => c.PlacementDate == searchParams.PlacementDate;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, placementDateExpression);
                }

                if (searchParams.CaseTypeId != null)
                {
                    Expression<Func<Case, bool>> caseTypeExpression =
                    c => c.TypeId == searchParams.CaseTypeId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, caseTypeExpression);
                }

                if (searchParams.ProductId != null)
                {
                    Expression<Func<Case, bool>> productExpression =
                    c => c.ProductId == searchParams.ProductId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, productExpression);
                }

                if (searchParams.ClientFirstName != null)
                {
                    Expression<Func<Case, bool>> clientFirstNameExpression =
                    c => c.ClientFirstName == searchParams.ClientFirstName;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, clientFirstNameExpression);
                }

                if (searchParams.ClientLastName != null)
                {
                    Expression<Func<Case, bool>> clientLastNameExpression =
                    c => c.ClientLastName == searchParams.ClientLastName;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, clientLastNameExpression);
                }
                
                var pagedList = (await _unitOfWork.Case.GetAll(includeProperties: ConstantClass.CaseExtendedProperties, filter: caseExpression, sortParams: sortParams, gridParams: gridParams) as PagedList<Case>);
                                
                var list = _mapper.Map<IEnumerable<CaseDTO>>(pagedList);

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

        [HttpGet]
        [Route("GetForApproval")]
        public async Task<IActionResult> GetForApproval([FromQuery] GridParams gridParams, [FromQuery] CaseAllSearchParams searchParams, string? sortParams = null)
        {
            try
            {
                Expression<Func<Case, bool>> caseExpression = obj => true;

                if (searchParams.CarrierId != null)
                {
                    Expression<Func<Case, bool>> carrierExpression =
                    c => c.CarrierId == searchParams.CarrierId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, carrierExpression);

                }

                if (searchParams.Policy != null)
                {
                    Expression<Func<Case, bool>> policyExpression =
                    c => c.Policy == searchParams.Policy;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, policyExpression);
                }

                if (searchParams.StatusId != null)
                {
                    Expression<Func<Case, bool>> statusExpression =
                    c => c.StatusId == searchParams.StatusId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, statusExpression);
                }

                // Expression for Case status not equal to Placed
                var caseStatus = (await _unitOfWork.CaseStatus.Get(obj => obj.Name == "Placed") ?? new CaseStatus());
                string caseStatusName = caseStatus.Name;
                Expression<Func<Case, bool>> statusPlacedExpression =
                    c => c.CaseStatus.Name != caseStatusName;

                caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, statusPlacedExpression);

                if (searchParams.ProductTypeId != null)
                {
                    Expression<Func<Case, bool>> productTypeExpression =
                    c => c.ProductTypeId == searchParams.ProductTypeId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, productTypeExpression);
                }

                if (searchParams.FaceAmount != null)
                {
                    Expression<Func<Case, bool>> faceAmountExpression =
                    c => c.FaceAmount == searchParams.FaceAmount;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, faceAmountExpression);
                }

                if (searchParams.AnnualizedPremium != null)
                {
                    Expression<Func<Case, bool>> annualizedPremiumExpression =
                    c => c.AnnualizedPremium == searchParams.AnnualizedPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, annualizedPremiumExpression);
                }

                if (searchParams.TargetPremium != null)
                {
                    Expression<Func<Case, bool>> targetPremiumExpression =
                    c => c.TargetPremium == searchParams.TargetPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, targetPremiumExpression);
                }

                if (searchParams.ModalPremium != null)
                {
                    Expression<Func<Case, bool>> modalPremiumExpression =
                    c => c.ModalPremium == searchParams.ModalPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, modalPremiumExpression);
                }

                if (searchParams.PlacementDate != null)
                {
                    Expression<Func<Case, bool>> placementDateExpression =
                    c => c.PlacementDate == searchParams.PlacementDate;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, placementDateExpression);
                }

                if (searchParams.CaseTypeId != null)
                {
                    Expression<Func<Case, bool>> caseTypeExpression =
                    c => c.TypeId == searchParams.CaseTypeId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, caseTypeExpression);
                }

                if (searchParams.ProductId != null)
                {
                    Expression<Func<Case, bool>> productExpression =
                    c => c.ProductId == searchParams.ProductId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, productExpression);
                }

                if (searchParams.ClientFirstName != null)
                {
                    Expression<Func<Case, bool>> clientFirstNameExpression =
                    c => c.ClientFirstName == searchParams.ClientFirstName;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, clientFirstNameExpression);
                }

                if (searchParams.ClientLastName != null)
                {
                    Expression<Func<Case, bool>> clientLastNameExpression =
                    c => c.ClientLastName == searchParams.ClientLastName;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, clientLastNameExpression);
                }

                var pagedList = (await _unitOfWork.Case.GetAll(includeProperties: ConstantClass.CaseExtendedProperties, filter: caseExpression, sortParams: sortParams, gridParams: gridParams) as PagedList<Case>);

                var list = _mapper.Map<IEnumerable<CaseDTO>>(pagedList);

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
        
        [HttpGet]
        [Route("GetComplete")]
        public async Task<IActionResult> GetComplete([FromQuery] GridParams gridParams, [FromQuery] CaseAllSearchParams searchParams, string? sortParams = null)
        {
            try
            {
                Expression<Func<Case, bool>> caseExpression = obj => true;

                if (searchParams.CarrierId != null)
                {
                    Expression<Func<Case, bool>> carrierExpression =
                    c => c.CarrierId == searchParams.CarrierId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, carrierExpression);

                }

                if (searchParams.Policy != null)
                {
                    Expression<Func<Case, bool>> policyExpression =
                    c => c.Policy == searchParams.Policy;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, policyExpression);
                }                

                // Expression for Case status equal to Placed
                var caseStatus = (await _unitOfWork.CaseStatus.Get(obj => obj.Name == "Placed") ?? new CaseStatus());
                string caseStatusName = caseStatus.Name;
                Expression<Func<Case, bool>> statusPlacedExpression =
                    c => c.CaseStatus.Name == caseStatusName;

                caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, statusPlacedExpression);

                if (searchParams.ProductTypeId != null)
                {
                    Expression<Func<Case, bool>> productTypeExpression =
                    c => c.ProductTypeId == searchParams.ProductTypeId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, productTypeExpression);
                }

                if (searchParams.FaceAmount != null)
                {
                    Expression<Func<Case, bool>> faceAmountExpression =
                    c => c.FaceAmount == searchParams.FaceAmount;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, faceAmountExpression);
                }

                if (searchParams.AnnualizedPremium != null)
                {
                    Expression<Func<Case, bool>> annualizedPremiumExpression =
                    c => c.AnnualizedPremium == searchParams.AnnualizedPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, annualizedPremiumExpression);
                }

                if (searchParams.TargetPremium != null)
                {
                    Expression<Func<Case, bool>> targetPremiumExpression =
                    c => c.TargetPremium == searchParams.TargetPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, targetPremiumExpression);
                }

                if (searchParams.ModalPremium != null)
                {
                    Expression<Func<Case, bool>> modalPremiumExpression =
                    c => c.ModalPremium == searchParams.ModalPremium;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, modalPremiumExpression);
                }

                if (searchParams.PlacementDate != null)
                {
                    Expression<Func<Case, bool>> placementDateExpression =
                    c => c.PlacementDate == searchParams.PlacementDate;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, placementDateExpression);
                }

                if (searchParams.CaseTypeId != null)
                {
                    Expression<Func<Case, bool>> caseTypeExpression =
                    c => c.TypeId == searchParams.CaseTypeId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, caseTypeExpression);
                }

                if (searchParams.ProductId != null)
                {
                    Expression<Func<Case, bool>> productExpression =
                    c => c.ProductId == searchParams.ProductId;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, productExpression);
                }

                if (searchParams.ClientFirstName != null)
                {
                    Expression<Func<Case, bool>> clientFirstNameExpression =
                    c => c.ClientFirstName == searchParams.ClientFirstName;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, clientFirstNameExpression);
                }

                if (searchParams.ClientLastName != null)
                {
                    Expression<Func<Case, bool>> clientLastNameExpression =
                    c => c.ClientLastName == searchParams.ClientLastName;

                    caseExpression = ExpressionExtension<Case>.AndAlso(caseExpression, clientLastNameExpression);
                }

                var pagedList = (await _unitOfWork.Case.GetAll(includeProperties: ConstantClass.CaseExtendedProperties, filter: caseExpression, sortParams: sortParams, gridParams: gridParams) as PagedList<Case>);

                var list = _mapper.Map<IEnumerable<CaseDTO>>(pagedList);

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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var record = _mapper.Map<CaseDTO>(await _unitOfWork.Case.Get(obj => obj.Id == id, includeProperties: ConstantClass.CaseExtendedProperties));

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
        public async Task<IActionResult> Post(CaseDTO objectCase)
        {
            try
            {
                var record = _mapper.Map<Case>(objectCase);

                await _unitOfWork.Case.Add(record);
                await _unitOfWork.Save();

                return Ok(
                            _mapper.Map<CaseDTO>(record)
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
        public async Task<IActionResult> Put(CaseDTO objectCase) 
        {
            try
            {
                var caseObject = _mapper.Map<Case>(objectCase);

                var record = _mapper.Map<CaseDTO>(await _unitOfWork.Case.Get(obj => obj.Id == objectCase.Id, includeProperties: ConstantClass.CaseExtendedProperties));
                if (record != null)
                {
                    _unitOfWork.Case.Update(caseObject);
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
                var record = await _unitOfWork.Case.Get(obj => obj.Id == id);
                if (record != null)
                {
                    await _unitOfWork.Case.Remove(record);
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
