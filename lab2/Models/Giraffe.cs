using lab2.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class Giraffe : BaseDbModel, IAnimal
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Annotations))]
        [StringLength(25)]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public string Name { get; set; }

        [Display(Name = "Weight", ResourceType = typeof(Resources.Annotations))]
        [Range(1, 1000, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort Weight { get; set; }

        [Display(Name = "Age", ResourceType = typeof(Resources.Annotations))]
        [Range(0, 50, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort Age { get; set; }

        [Display(Name = "NeckLength", ResourceType = typeof(Resources.Annotations))]
        [Range(10, 350, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public ushort NeckLength { get; set; }

        [Display(Name = "NumberOfDots", ResourceType = typeof(Resources.Annotations))]
        [Range(10, 2000, ErrorMessageResourceName = "RangeRequired", ErrorMessageResourceType = typeof(Resources.Annotations))]
        public uint NumberOfDots { get; set; }
    }
}
