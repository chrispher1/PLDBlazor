﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLD.Blazor.DataAccess.Model;

namespace PLD.Blazor.Business.DTO
{
    public class TimeActivityMappingDTO
    {
        #region Properties
            public int Id { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "The Carrier field is required.")]
            public int CarrierId { get; set; }
            public CarrierDTO? Carrier { get; set; }

            [Display(Name = "Carrier Time")]
            [MaxLength(5)]
            public string? CarrierTime
            {
                get
                {
                    if (String.IsNullOrEmpty(_carrierTime))
                        return null;
                    return _carrierTime;
                }
                set
                {
                    _carrierTime = value;
                }
            }

            [Display(Name = "Carrier Activity")]
            [MaxLength(5)]
            [Required]
            public string? CarrierActivity { get; set; }

            [Display(Name = "Policy Year Start")]
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Policy Year Start must be greater than 0.")]
            public int PolicyYearStart { get; set; }

            [Display(Name = "Policy Year End")]
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Policy Year End must be greater than 0.")]
            public int PolicyYearEnd { get; set; }

            [Display(Name = "Time Code")]
            [MaxLength(4)]
            public string? TimeCode
            {
                get
                {
                    if (String.IsNullOrEmpty(_timeCode))
                        return null;
                    return _timeCode;
                }
                set
                {
                    _timeCode = value;
                }
            }

            [Display(Name = "Transaction Type")]
            [MaxLength(4)]
            [Required]
            public string TransactionType { get; set; }
            public ActivityDTO? Activity { get; set; }

            [Display(Name = "Compensable Indicator")]
            [MaxLength(2)]
            [Required]
            public string CompensableIndicator { get; set; }

            public bool CompensableIndicatorBoolean
            {
                get
                {
                    if (CompensableIndicator == "Y")
                        return true;
                    else
                        return false;
                }
            }

            [Display(Name = "Created Date")]
            public DateTime CreatedDate { get; set; }

            [Display(Name = "Created By")]
            [MaxLength(100)]
            public string? CreatedBy { get; set; }

            [Display(Name = "Modified Date")]
            public DateTime? ModifiedDate { get; set; }

            [Display(Name = "Modified By")]
            [MaxLength(100)]
            public string? ModifiedBy { get; set; }

        #endregion

        #region Fields

            private string? _carrierTime;
            private string? _timeCode;

        #endregion        
    }
}
