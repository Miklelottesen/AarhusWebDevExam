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
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactForm());
        }
        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid) { return CurrentUmbracoPage(); }
            else {
                IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Comment");

                comment.SetValue("messageName", model.Name);
                comment.SetValue("email", model.Email);
                comment.SetValue("subject", model.Subject);
                comment.SetValue("message", model.Message);

                // Save
                Services.ContentService.Save(comment);

                TempData.Add("Success", "Message successfully delivered");
                return RedirectToCurrentUmbracoPage();
            }
        }
    }
}