using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMS.Model.Models;
using CIMS.Services;
using CIMS.Services.Abstract;

namespace CIMS.Web.Areas.PatientRecord.Controllers
{
    public class PatientInformationController : Controller
    {
        private readonly IPatientService patientService;

        public PatientInformationController()
        {
            patientService = new PatientService();
        }
        // GET: PatientRecord/PatientInformation
        public ActionResult Index()
        {
            var patients = patientService.GetPatients();
            return View(patients);
        }

        public ActionResult Edit(Guid id)
        {
            var patient = patientService.GetPatientById(id);
            return View(patient);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delelte(Guid id)
        {
            var success = patientService.DeletePatient(id);
            //if (success)
            //    JsonResult("Sucess", JsonRequestBehavior.AllowGet);
            return View("Index");
        }
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid) return View("Index");
            patient.PatientID = Guid.NewGuid();
            var status = patientService.CreatePatient(patient);
            return View("Index",patientService.GetPatients());
        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if (!ModelState.IsValid) return View("Index");
            var status = patientService.UpdatePatient(patient);
            return View("Index", patientService.GetPatients());
        }

        public ActionResult Details(Guid id)
        {
            var patient = patientService.GetPatientById(id);
            return View(patient);
        }
    }
}