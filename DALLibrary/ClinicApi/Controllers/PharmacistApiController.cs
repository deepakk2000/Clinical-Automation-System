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
    public class PharmacistApiController : ApiController
    {
        private readonly Service service;
        public PharmacistApiController()
        {
            service = new Service();
        }


        // GET: 
        public IEnumerable<Pharmacist> GetPharmacists()
        {
            return service.GetAllPharmacists();
        }

        // GET: 
        [ResponseType(typeof(Pharmacist))]
        public IHttpActionResult GetPharmacist(int id)
        {
            Pharmacist pharmacist = service.GetPharmacistById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            return Ok(pharmacist);
        }

        // PUT: 
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPharmacist(int id, Pharmacist pharmacist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pharmacist.PharmacistId)
            {
                return BadRequest();
            }

            service.UpdatePharmacist(pharmacist);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST:
        [ResponseType(typeof(Pharmacist))]
        public IHttpActionResult PostPharmacist(Pharmacist pharmacist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddPharmacist(pharmacist);

            return CreatedAtRoute("DefaultApi", new { id = pharmacist.PharmacistId }, pharmacist);
        }

        // DELETE: 
        [ResponseType(typeof(Pharmacist))]
        public IHttpActionResult DeletePharmacist(int id)
        {
            Pharmacist pharmacist = service.GetPharmacistById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }

            service.DeletePharmacist(id);

            return Ok(pharmacist);
        }

    }
}
