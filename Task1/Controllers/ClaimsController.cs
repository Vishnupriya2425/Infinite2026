using System.Collections.Generic;
using System.Web.Mvc;
using Task1.Models;

namespace Task1.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        private void LoadDropdowns()
        {
            ViewBag.Systems = new List<SelectListItem>
            {
                new SelectListItem { Text = "CSC", Value = "CSC" },
                new SelectListItem { Text = "QNXT", Value = "QNXT" }
            };

            ViewBag.Priorities = new List<SelectListItem>
            {
                new SelectListItem { Text = "Low", Value = "Low" },
                new SelectListItem { Text = "Medium", Value = "Medium" },
                new SelectListItem { Text = "High", Value = "High" },
                new SelectListItem { Text = "Escalation", Value = "Escalation" }
            };

            ViewBag.LineOfBusiness = new List<SelectListItem>
            {
                new SelectListItem { Text = "A - All Lines of Business", Value = "A - All Lines of Business" },
                new SelectListItem { Text = "B - Medicare", Value = "B - Medicare" },
                new SelectListItem { Text = "C - Medicaid", Value = "C - Medicaid" },
                new SelectListItem { Text = "D - DSNP and MLTSS", Value = "D - DSNP and MLTSS" },
                new SelectListItem { Text = "E - MAPD", Value = "E - MAPD" },
                new SelectListItem { Text = "F - DSNP", Value = "F - DSNP" },
                new SelectListItem { Text = "G - MLTSS", Value = "G - MLTSS" },
                new SelectListItem { Text = "H - M4", Value = "H - M4" },
                new SelectListItem { Text = "I - Commercial", Value = "I - Commercial" },
                new SelectListItem { Text = "J - Other", Value = "J - Other" }
            };

            ViewBag.ReprocessingTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Net Zero $/No Impact $", Value = "Net Zero" },
                new SelectListItem { Text = "Overpayment", Value = "Overpayment" },
                new SelectListItem { Text = "Underpayment", Value = "Underpayment" },
                new SelectListItem { Text = "Underpayment/Overpayment", Value = "Underpayment/Overpayment" }
            };

            ViewBag.ReprocessingReasons = new List<SelectListItem>
            {
                new SelectListItem { Text="Non Reprocessing - Other Request", Value="Non Reprocessing - Other Request" },
                new SelectListItem { Text="Reprocessing - Claims automation: BOT error", Value="BOT error" },
                new SelectListItem { Text="Reprocessing - Claims automation: Other", Value="Claims Automation Other" },
                new SelectListItem { Text="Reprocessing - Clinical: Authorization update", Value="Authorization Update" },
                new SelectListItem { Text="Reprocessing - Enrollment: COB or OHI", Value="COB or OHI" },
                new SelectListItem { Text="Reprocessing - Enrollment: Effective date update", Value="Effective Date Update" },
                new SelectListItem { Text="Reprocessing - Enrollment: Other", Value="Enrollment Other" },
                new SelectListItem { Text="Reprocessing - Enrollment: Termination date update", Value="Termination Date Update" },
                new SelectListItem { Text="Reprocessing - Enrollment: Waiver code update", Value="Waiver Code Update" },
                new SelectListItem { Text="Reprocessing - Processor error: Denied in error", Value="Denied In Error" },
                new SelectListItem { Text="Reprocessing - Processor error: Incorrect payment", Value="Incorrect Payment" },
                new SelectListItem { Text="Reprocessing - Processor error: Other", Value="Processor Other" },
                new SelectListItem { Text="Reprocessing - Provider: Contract affiliation change", Value="Contract Affiliation Change" },
                new SelectListItem { Text="Reprocessing - Provider: PAR / NonPAR status change", Value="PAR NonPAR Status Change" },
                new SelectListItem { Text="Reprocessing - Provider: Specialty change", Value="Specialty Change" },
                new SelectListItem { Text="Reprocessing - Provider: W9 received", Value="W9 Received" },
                new SelectListItem { Text="Reprocessing - Regulatory Required: CMS rate update", Value="CMS Rate Update" },
                new SelectListItem { Text="Reprocessing - Regulatory Required: DMAS rate update", Value="DMAS Rate Update" },
                new SelectListItem { Text="Reprocessing - Regulatory Required: Other", Value="Regulatory Other" },
                new SelectListItem { Text="Reprocessing - System configuration: Benefit issue", Value="Benefit Issue" },
                new SelectListItem { Text="Reprocessing - System configuration: CES issue", Value="CES Issue" },
                new SelectListItem { Text="Reprocessing - System Configuration: Contract Configuration Issue", Value="Contract Configuration Issue" },
                new SelectListItem { Text="Reprocessing - System configuration: Provider contract change", Value="Provider Contract Change" },
                new SelectListItem { Text="Reprocessing - System configuration: Zelis issue", Value="Zelis Issue" }
            };

            ViewBag.ServiceTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Inpatient", Value = "Inpatient" },
                new SelectListItem { Text = "Outpatient", Value = "Outpatient" },
                new SelectListItem { Text = "Lab", Value = "Lab" },
                new SelectListItem { Text = "Multiple", Value = "Multiple" },
                new SelectListItem { Text = "Unknown", Value = "Unknown" }
            };

            ViewBag.YesNo = new List<SelectListItem>
            {
                new SelectListItem { Text = "Yes", Value = "Yes" },
                new SelectListItem { Text = "No", Value = "No" }
            };

            ViewBag.VendorTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Hospital", Value = "Hospital" },
                new SelectListItem { Text = "Provider", Value = "Provider" },
                new SelectListItem { Text = "Both", Value = "Both" },
                new SelectListItem { Text = "Unknown", Value = "Unknown" }
            };
            ViewBag.ReprocessingTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Net Zero $/No Impact $", Value = "Net Zero" },
                new SelectListItem { Text = "Overpayment", Value = "Overpayment" },
                new SelectListItem { Text = "Underpayment", Value = "Underpayment" },
                new SelectListItem { Text = "Underpayment/Overpayment", Value = "Underpayment/Overpayment" }
            };
            ViewBag.TimelyReprocessing = new List<SelectListItem>
            {
                new SelectListItem { Text = "Yes", Value = "Yes" },
                new SelectListItem { Text = "No", Value = "No" }
            };
            ViewBag.InterestApplies = new List<SelectListItem>
            {
                new SelectListItem { Text = "Yes", Value = "Yes" },
                new SelectListItem { Text = "No", Value = "No" },

            };
        }

        public ActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClaimsReprocessing model)
        {
            LoadDropdowns();

            if (ModelState.IsValid)
            {
                db.ClaimsReprocessing.Add(model);
                db.SaveChanges();

                TempData["Message"] = "Claim Saved Successfully";

                return RedirectToAction("Create");
            }

            return View(model);
        }
    }
}