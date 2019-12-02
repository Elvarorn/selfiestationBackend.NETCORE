using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfieStation.Models.Entities;

namespace SelfieStation.Repositories
{
    public interface IAdRepository
    {
        Task<ActionResult<IEnumerable<AdEntity>>> GetadInfo();
        Task<ActionResult<AdEntity>> GetAd(int id);
        Task<IActionResult> PutAd(int id, AdEntity adEntity);
        Task<ActionResult<AdEntity>> PostAd(AdEntity adEntity);
        Task<ActionResult<AdEntity>> DeleteAd(int id);
        bool AdEntityExists(int id);
    }
}
