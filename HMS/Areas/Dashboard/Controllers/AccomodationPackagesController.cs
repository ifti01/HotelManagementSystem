using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationPackagesController : Controller
    {
        
        // GET: Dashboard/AccomodationPackages

        AccomodationPackagesServices accomodationPackagesServices = new AccomodationPackagesServices();
        AccomodationTypesServices accomodationTypesServices = new AccomodationTypesServices();



        public ActionResult Index(string searchterm)
        {
            AccomodationPackagesListingModel model = new AccomodationPackagesListingModel();

            model.SearchTerm = searchterm;

            model.AccomodationPackages = accomodationPackagesServices.SearchAccomodationPackages(searchterm);

            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationPackageActionModel model = new AccomodationPackageActionModel();

            if (ID.HasValue)
            {
                //edit a record

                var accomodationPackage = accomodationPackagesServices.GetAccomodationPackageByID(ID.Value);

                model.ID = accomodationPackage.ID;
                model.AccomodationTypeID = accomodationPackage.AccomodationTypeID;
                model.Name = accomodationPackage.Name;
                model.NoOfRoom = accomodationPackage.NoOfRoom;
                model.FeePerNight = accomodationPackage.FeePerNight;
            }

            model.AccomodationTypes = accomodationTypesServices.GetAllAccomodationTypes();

            return PartialView("_Action", model);

        }

        public ActionResult Listing()
        {
            return PartialView("_Listing");

        }

        [HttpPost]
        public JsonResult Action(AccomodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            if (model.ID > 0)
            {
                var accomodationPackage = accomodationPackagesServices.GetAccomodationPackageByID(model.ID);

                accomodationPackage.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackage.Name = model.Name;
                accomodationPackage.NoOfRoom = model.NoOfRoom;
                accomodationPackage.FeePerNight = model.FeePerNight;

                //edit a record

                result = accomodationPackagesServices.UpdateAccomodationPackage(accomodationPackage);

            }

            else
            {
                AccomodationPackages accomodationPackages = new AccomodationPackages();

                accomodationPackages.AccomodationTypeID = model.AccomodationTypeID;
                accomodationPackages.Name = model.Name;
                accomodationPackages.NoOfRoom = model.NoOfRoom;
                accomodationPackages.FeePerNight = model.FeePerNight;

                result = accomodationPackagesServices.SaveAccomodationPackage(accomodationPackages);

            }

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on AccomodationPackage Type" };
            }

            return json;
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AccomodationPackageActionModel model = new AccomodationPackageActionModel();

            var accomodationPackage = accomodationPackagesServices.GetAccomodationPackageByID(ID);

            model.ID = accomodationPackage.ID;

            return PartialView("_Delete", model);

        }

        public JsonResult Delete(AccomodationPackageActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var accomodationPackage = accomodationPackagesServices.GetAccomodationPackageByID(model.ID);

            result = accomodationPackagesServices.DeleteAccomodationPackage(accomodationPackage);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on AccomodationPackage Type" };
            }

            return json;
        }


    }
}