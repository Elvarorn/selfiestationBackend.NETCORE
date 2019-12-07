using System;
using System.ComponentModel.DataAnnotations;


namespace SelfieStation.Models.Entities
{
    public class imageInfoEntity
    {
        public int ID { get; set; }
        [Required]
        public string imageGUID { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public DateTime timeStamp { get; set; }
        [Required]
        public string premiumUrl { get; set; }
        public string freeUrl { get; set; }
        [Required]
        public Boolean hasEmailBeenSent { get; set; } = false;
        [Required]
        public Boolean success { get; set; } = false;
        [Required]
        public Boolean hasImageBeenBought { get; set; } = false;

    }
}