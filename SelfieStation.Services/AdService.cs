using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieStation.Models.Entities;
using SelfieStation.Repositories.data;
using SelfieStation.Services;

namespace SelfieStation.Repositories
{
    // Adservice connects the Ad controller to the Ad repository.
    public class AdService : IAdService
    {

        private IAdRepository _adRepository;
        private AuthenticationService _authService;
        private string whoHasAuth;

        public AdService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
            _authService = new AuthenticationService();
            whoHasAuth = "admin";

        }


        public IEnumerable<AdEntity> GetadInfo(HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            return _adRepository.GetadInfo();
        }

        public async Task<ActionResult<AdEntity>> GetAd(int id, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            return await _adRepository.GetAd(id);
        }

        public async Task<IActionResult> PutAd(int id, AdEntity adEntity, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            await _adRepository.PutAd(id, adEntity);
            return null;
        }

        public async Task<ActionResult<AdEntity>> PostAd(AdEntity adEntity, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            return await _adRepository.PostAd(adEntity);
        }


        public async Task<ActionResult<AdEntity>> DeleteAd(int id, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            return await _adRepository.DeleteAd(id);
        }

        public bool AdEntityExists(int id)
        {
            return _adRepository.AdEntityExists(id);
        }

    }
}
