using System.ComponentModel.DataAnnotations;

namespace Dota2_Shop.Models
{
    public class Artifact
    {
        [Key]
        public int Id { get; set; }
        public string ArtifactImage { get; set; }
        public string ArtifactName { get; set; }
        public string ArtifactBonus { get; set; }
        public int ArtifactCost { get; set; }
        public string ArtifactDisription { get; set; }
    }
}
