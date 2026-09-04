using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Task1.Models
{
    public class ClaimsReprocessing
    {
            public int Id { get; set; }

            [Required]
            [RegularExpression(@"^[a-zA-Z\s]+$")]
            public string Requester { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public DateTime CreatedDate { get; set; }

            public string Phone { get; set; }

            public string DepartmentName { get; set; }

            public string LocationName { get; set; }

            public string Team { get; set; }

            public string AssignedTo { get; set; }

            [Required]
            public DateTime? DueDate { get; set; }

            [Required]
            public string Summary { get; set; }

            [Required]
            public string SystemName { get; set; }

            [Required]
            public string Priority { get; set; }

            [Required]
            public string LineOfBusiness { get; set; }

            [Required]
            public string ReprocessingType { get; set; }

            [Required]
            public string ReprocessingReason { get; set; }

            [Required]
            [RegularExpression(@"^[a-zA-Z\s]+$")]
            public string ProviderName { get; set; }

            public string ParOrNonPar { get; set; }

            [Required]
            public string TypeOfService { get; set; }

            [Required]
            [Range(1, 999999)]
            public int? ClaimsCount { get; set; }

            [Required]
            public string TimelyFilingApprovalObtained { get; set; }

            [Required]
            [Range(typeof(decimal), "0.01", "999999999")]
            public decimal? ProjectedAmount { get; set; }

            [Required]
            public string InterestApplies { get; set; }

            [Required]
            public string VendorType { get; set; }

            [Required]
            public string Description { get; set; }

            public string InternalNotes { get; set; }
        }
    }

