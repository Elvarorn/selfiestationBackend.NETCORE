using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieStation.Models.Entities;
using SelfieStation.Repositories.data;

namespace SelfieStation.Repositories
{

    public class AdRepository : IAdRepository
    {
        protected databaseContext _context;

        public AdRepository(databaseContext context)
        {
            _context = context;
        }


        public IEnumerable<AdEntity> GetadInfo()
        {
            return _context.adInfo.ToList();
        }

        public async Task<ActionResult<AdEntity>> GetAd(int id)
        {
            var adEntity = await _context.adInfo.FindAsync(id);

            if (adEntity == null)
            {
                //sumthin
                return null;
            }

            return adEntity;
        }

        public async Task<IActionResult> PutAd(int id, AdEntity adEntity)
        {
            if (id != adEntity.Id)
            {
                //sumthin
            }

            _context.Entry(adEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdEntityExists(id))
                {
                    //tjekkar hvort hann hafi búist til
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        public async Task<ActionResult<AdEntity>> PostAd(AdEntity adEntity)
        {
            _context.adInfo.Add(adEntity);
            await _context.SaveChangesAsync();

            return adEntity;
        }


        public async Task<ActionResult<AdEntity>> DeleteAd(int id)
        {
            var adEntity = await _context.adInfo.FindAsync(id);
            if (adEntity == null)
            {
                return null;
            }

            _context.adInfo.Remove(adEntity);
            await _context.SaveChangesAsync();

            return adEntity;
        }

        public bool AdEntityExists(int id)
        {
            return _context.adInfo.Any(e => e.Id == id);
        }

    }
}
