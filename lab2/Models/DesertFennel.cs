using lab2.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class DesertFennel : BaseDbModel, IAnimal
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Annotations))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Weight", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 20, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort Weight { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 15, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort Age { get; set; }

        [Display(Name = "EarLength", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 20, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort EarLength { get; set; }

        [Display(Name = "MaxSpeed", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 40, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort MaxSpeed { get; set; }

        [Display(Name = "FavouriteWord", ResourceType = typeof(Resources.Annotations))]
        [StringLength(100, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public string FavouriteWord { get; set; }
    }
}
