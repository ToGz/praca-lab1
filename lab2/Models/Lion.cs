using lab2.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class Lion : BaseDbModel, IAnimal
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Annotations))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Weight", ResourceType = typeof(Resources.Annotations))]
        [Range(1, 100, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort Weight { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 50, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort Age { get; set; }

        [Display(Name = "Coloration", ResourceType = typeof(Resources.Annotations))]
        public Coloration Coloration { get; set; }

        [Display(Name = "TailLength", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 50, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort TailLength { get; set; }
    }

    public enum Coloration
    {
        White,
        Black,
        LightBrown,
        DarkBrown
    }
}
