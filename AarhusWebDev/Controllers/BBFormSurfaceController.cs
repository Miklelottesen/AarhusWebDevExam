using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AarhusWebDev.ViewModels;
using Umbraco.Core.Models;

namespace AarhusWebDev.Controllers
{
    public class BBFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("BBForm", new BBForm());
        }
        [HttpPost]
        public ActionResult HandleFormSubmit(BBForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }
            else {
                IContent message = Services.ContentService.CreateContent(model.Name, CurrentPage.Id, "Message");

                message.SetValue("messageName", model.Name);
                message.SetValue("messageText", model.Message);

                // Save
                Services.ContentService.Save(message);

                //TempData.Add("Success", "Message successfully delivered");
                return RedirectToCurrentUmbracoPage();
            }
        }
    }
}