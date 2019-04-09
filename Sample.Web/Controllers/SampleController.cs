using System;
using System.Globalization;
using Sample.Web.Models;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;


namespace Sample.Web.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index(SampleViewModel model = null)
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult ProcessDate(SampleViewModel sampleViewModel)
        {

            

            var success = DateTime.TryParseExact(sampleViewModel.Date, "yyyy/MM/ddThh:mm:ss",
                CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var dateToProcess);



                if (!success)
            {

                sampleViewModel.Result = ViewBag.Message = string.Format("Specify proper date time format! ");
                return RedirectToAction("Index", sampleViewModel);

            }
           
                var timeDiff = DateTime.Now - dateToProcess;

                var result =
                    $"It's been {timeDiff.Days} days, {timeDiff.Hours} hours, {timeDiff.Minutes} minutes and {timeDiff.Seconds} seconds since that day... Good times... Good times...";

                sampleViewModel.Result = result;

                return RedirectToAction("Index", sampleViewModel);
            
        }
    }
}