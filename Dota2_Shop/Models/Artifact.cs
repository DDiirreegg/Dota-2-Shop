using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class Artifact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture")]
        public string ArtifactImage { get; set; }

        [Display(Name = "Artifact Name")]
        public string ArtifactName { get; set; }

        [Display(Name = "Improvements")]
        public string ArtifactBonus { get; set; }

        [Display(Name = "Cost")]
        public int ArtifactCost { get; set; }

        [Display(Name = "Disription")]
        public string ArtifactDisription { get; set; }
    }
}
