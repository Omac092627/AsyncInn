﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;


        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<AmenityDTO>> GetAmenities(int id)
        {
            var amenities = await _amenity.GetAmenity(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            var amenities = await _amenity.GetAmenity(id);
/*            Amenity amenity = await _amenity.GetAmenity(id);
 *            
 *           
*/
            if(amenities == null)
            {
                return NotFound();
            }
            return amenities;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize(Policy = "District Manager")]
        [Authorize(Policy = "Property Manager")]
        [Authorize(Policy = "Agent")]
        public async Task<IActionResult> PutAmenity(int id, Amenity amenity)
        {
            if (id != amenity.Id)
            {
                return BadRequest();
            }
            var updateAmenity = await _amenity.Update(amenity);
            return Ok(updateAmenity);

        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Policy = "District Manager")]
        [Authorize(Policy = "Property Manager")]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {

            await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.Id }, amenity);
        }




        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "District Manager")]
        [Authorize(Policy = "Agent")]
        public async Task<ActionResult<Amenity>> DeleteAmenity(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }
    }
}
