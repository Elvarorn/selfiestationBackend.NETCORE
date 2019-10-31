using System;

namespace SelfieStationApi.Models.DTO
{
    public class imageInfoDto
    {
        public int ID;
        public string imageGUID { get; set; }
        public string email { get; set; }
        public DateTime timeStamp { get; set; }
        public Boolean hasEmailBeenSent { get; set; }
        public Boolean success { get; set; }
        public Boolean hasImageBeenBought { get; set; }
    }
}