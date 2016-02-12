namespace ColorCraft.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        private ICollection<Painting> paintings;

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public double Opacity { get; set; }
         
        public virtual ICollection<Painting> Paintings
        {
            get
            {
                return this.paintings;
            }
            set
            {
                this.paintings = value;
            }
        }

        public BrightnessLevel BrightnessLevel { get; set; }
    }
}
