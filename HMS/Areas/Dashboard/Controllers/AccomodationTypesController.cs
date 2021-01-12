using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        //created a object of AccomodationTypesServices

        AccomodationTypesServices accomodationTypesServices = new AccomodationTypesServices();

        // GET: Dashboard/AccomodationTypes

        public ActionResult Index(string searchterm)
        {
            AccomodationTypesListingModel model = new AccomodationTypesListingModel();

            model.SearchTerm = searchterm;

            model.AccomodationTypes = accomodationTypesServices.SearchAccomodationTypes(searchterm);

            return View(model);
        }

        //public ActionResult Listing()
        //{
        //    AccomodationTypesListingModel model = new AccomodationTypesListingModel();
            
        //     model.AccomodationTypes = accomodationTypesServices.GetAllAccomodationTypes();
            
        //    return PartialView("_Listing",model);
        //}

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            if (ID.HasValue)
            {
                //edit a record

                var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(ID.Value);

                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }

            return PartialView("_Action",model);

        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0)
            {
                var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(model.ID);

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                //edit a record

                result = accomodationTypesServices.UpdateAccomodationType(accomodationType);

            }

            else
            {
                AccomodationType accomodationType = new AccomodationType();

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypesServices.SaveAccomodationType(accomodationType);

            }

            if (result)
            {
                json.Data = new {Success = true};
            }
            else
            {
                json.Data = new {Success = false, Message = "Unable to perform action on Accomodation Type"};
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationTypeActionModel model = new AccomodationTypeActionModel();

            var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(ID);

            model.ID = accomodationType.ID;
            
            return PartialView("_Delete", model);

        }

        public JsonResult Delete(AccomodationTypeActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;
            
            var accomodationType = accomodationTypesServices.GetAccomodationTypeByID(model.ID);

            result = accomodationTypesServices.DeleteAccomodationType(accomodationType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Accomodation Type" };
            }

            return json;
        }

    }
}