using System.ComponentModel.DataAnnotations;

namespace SelfieStation.Models.Entities
{
    public class AdEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string GUID { get; set; }
        [Required]
        public string ImgURL { get; set; }
    }
}