namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cargoes
    {
        [Key]
        public int CargoID { get; set; }

        [Required]
        [StringLength(50)]
        public string CargoType { get; set; }

        [Required]
        [StringLength(50)]
        public string Destination { get; set; }

        public float Weight { get; set; }

        public int AirplaneID { get; set; }

        public virtual Airplane Airplane { get; set; }
    }
}
