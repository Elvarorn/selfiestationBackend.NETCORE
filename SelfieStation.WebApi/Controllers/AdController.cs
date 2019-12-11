using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfieStation.Models.Entities;
using SelfieStation.Services;

namespace SelfieStation.WebApi.Controllers
{
    // Endpoints for all requests that target ads.
    [Route("api/Ads")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }

        // GET: api/Ads
        [HttpGet]
        public ActionResult GetadInfo()
        {
            var ching = _adService.GetadInfo(this.HttpContext);
            Debug.WriteLine(ching);
            return Ok(ching);
        }

        // GET: api/Ads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdEntity>> GetAdEntity(int id)
        {
            var adEntity = await _adService.GetAd(id, this.HttpContext);
            if (adEntity == null)
            {
                return NotFound();
            }

            return Ok(adEntity);
        }

        // PUT: api/Ads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdEntity(int id, AdEntity adEntity)
        {
            if (id != adEntity.Id)
            {
                return BadRequest();
            }
            await _adService.PutAd(id, adEntity, this.HttpContext);

            return NoContent();
        }

        // POST: api/Ads/5
        [HttpPost]
        public async Task<ActionResult<AdEntity>> PostAdEntity(AdEntity adEntity)
        {
            var adEntityCreated = await _adService.PostAd(adEntity, this.HttpContext);
            return CreatedAtAction("GetAdEntity", new { id = adEntity.Id }, adEntity);
        }

        // DELETE: api/Ads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdEntity>> DeleteAdEntity(int id)
        {
            if (!AdEntityExists(id))
            {
                return NotFound();
            }

            return await _adService.DeleteAd(id, this.HttpContext);
        }

        private bool AdEntityExists(int id)
        {
            return _adService.AdEntityExists(id);
        }
    }
}
