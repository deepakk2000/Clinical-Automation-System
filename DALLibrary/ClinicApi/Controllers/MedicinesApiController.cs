using ClinicApi.Models;
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
    public class MedicinesApiController : ApiController
    {
        private readonly Service service;
        public MedicinesApiController()
        {
            service = new Service();
        }

        // GET
        public List<Medicine> GetMedicines()
        {
            return service.GetAllMedicines();
        }

        // GET:
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult GetMedicine(int id)
        {
            Medicine medicine = service.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicine(int id, Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }

            service.UpdateMedicine(medicine);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: 
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult PostMedicine(Medicine medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddMedicine(medicine);

            return CreatedAtRoute("DefaultApi", new { id = medicine.MedicineId }, medicine);
        }

        // DELETE: 
        [ResponseType(typeof(Medicine))]
        public IHttpActionResult DeleteMedicine(int id)
        {
            Medicine medicine = service.GetMedicineById(id);
            if (medicine == null)
            {
                return NotFound();
            }
            service.DeleteMedicine(id);
            return Ok(medicine);
        }

    }
}
