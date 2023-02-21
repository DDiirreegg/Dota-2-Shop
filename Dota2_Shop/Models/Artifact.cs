using Dota2_Shop.Date.Base;
using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class Artifact:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Image is required")]
        public string ArtifactImage { get; set; }

        [Display(Name = "Artifact Name")]
        [Required(ErrorMessage = "Name is required")]
        public string ArtifactName { get; set; }

        [Display(Name = "Improvements")]
        [Required(ErrorMessage = "Improvements is required")]
        public string ArtifactBonus { get; set; }

        [Display(Name = "Cost")]
        [Required(ErrorMessage = "Cost is required")]
        public int ArtifactCost { get; set; }

        [Display(Name = "Disription")]
        [Required(ErrorMessage = "Disription is required")]
        public string ArtifactDisription { get; set; }
    }
}
