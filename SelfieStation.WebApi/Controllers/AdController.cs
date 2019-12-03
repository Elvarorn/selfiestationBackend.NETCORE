using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieStation.Models.Entities;
using SelfieStation.Repositories.data;
using SelfieStation.Services;

namespace SelfieStation.WebApi.Controllers
{
    [Route("api/Ads")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        // GET: api/Ad
        [HttpGet]
        public ActionResult GetadInfo()
        {
            var ching = _adService.GetadInfo();
            Debug.WriteLine(ching);
            return Ok(ching);
        }

        // GET: api/Ad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdEntity>> GetAdEntity(int id)
        {
            var adEntity = await _adService.GetAd(id);

            if (adEntity == null)
            {
                return NotFound();
            }

            return Ok(adEntity);
        }

        // PUT: api/Ad/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdEntity(int id, AdEntity adEntity)
        {
            if (id != adEntity.Id)
            {
                return BadRequest();
            }

            await _adService.PutAd(id, adEntity);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AdEntity>> PostAdEntity(AdEntity adEntity)
        {
            var adEntityCreated = await _adService.PostAd(adEntity);

            return CreatedAtAction("GetAdEntity", new { id = adEntity.Id }, adEntity);
        }

        // DELETE: api/Ad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdEntity>> DeleteAdEntity(int id)
        {
            if (!AdEntityExists(id))
            {
                return NotFound();
            }

            return await _adService.DeleteAd(id);
        }

        private bool AdEntityExists(int id)
        {
            return _adService.AdEntityExists(id);
        }
    }
}
