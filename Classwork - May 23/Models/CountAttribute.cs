using Classwork___May_23.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classwork___May_23.Models
{
    public class CountAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cRepo = new CandidatesRepository(Properties.Settings.Default.Constr);
            filterContext.Controller.ViewBag.PendingCount = cRepo.GetCount(Status.Pending);
            filterContext.Controller.ViewBag.ConfirmedCount = cRepo.GetCount(Status.Confirmed);
            filterContext.Controller.ViewBag.RefusedCount = cRepo.GetCount(Status.Refused);
            base.OnActionExecuting(filterContext);
        }
    }
}