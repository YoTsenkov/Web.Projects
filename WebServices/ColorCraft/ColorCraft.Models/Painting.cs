namespace ColorCraft.Models
{
    using System.Collections.Generic;
    using System.Collections;
    using System.Runtime.Serialization;

    [KnownType(typeof(ICollection))]
    public class Painting
    {
        private ICollection<Color> colors;

        public Painting()
        {
            this.colors = new HashSet<Color>();
        }

        public int Id { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Color> Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
            }
        }
    }
}
