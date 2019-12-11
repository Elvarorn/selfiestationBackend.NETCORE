using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfieStation.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace SelfieStation.Services
{
    public interface IAdService
    {
        IEnumerable<AdEntity> GetadInfo(HttpContext context);
        Task<ActionResult<AdEntity>> GetAd(int id, HttpContext context);
        Task<IActionResult> PutAd(int id, AdEntity adEntity, HttpContext context);
        Task<ActionResult<AdEntity>> PostAd(AdEntity adEntity, HttpContext context);
        Task<ActionResult<AdEntity>> DeleteAd(int id, HttpContext context);
        bool AdEntityExists(int id);
    }
}
