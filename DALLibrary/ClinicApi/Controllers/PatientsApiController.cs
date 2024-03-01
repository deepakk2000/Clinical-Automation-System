﻿using ClinicApi.Models;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ClinicApi.Controllers
{
    public class PatientsApiController : ApiController
    {
        private readonly Service service;
        public PatientsApiController()
        {
            service = new Service();
        }

        // GET: api/PatientsApi
        public IEnumerable<Patient> GetPatients()
        {
            return service.GetAllPatients();
        }

        // GET: 
        [ResponseType(typeof(Patient))]
        public IHttpActionResult GetPatient(int id)
        {
            Patient patient = service.FindPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatient(int id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.PatientId)
            {
                return BadRequest();
            }

            service.UpdatePatient(patient);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: 
        [ResponseType(typeof(Patient))]
        public IHttpActionResult PostPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            service.InsertPatient(patient);

            return CreatedAtRoute("DefaultApi", new { id = patient.PatientId }, patient);
        }

        // DELETE:
        [ResponseType(typeof(Patient))]
        public IHttpActionResult DeletePatient(int id)
        {
            Patient patient = service.FindPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            service.DeletePatient(id);

            return Ok(patient);
        }

    }
}
