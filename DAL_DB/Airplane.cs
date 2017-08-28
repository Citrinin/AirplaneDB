namespace DAL_DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Airplane")]
    public partial class Airplane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airplane()
        {
            Cargoes = new HashSet<Cargoes>();
        }

        public int AirplaneID { get; set; }

        [Required]
        [StringLength(20)]
        public string ModelName { get; set; }

        public float MaxCargo { get; set; }

        public int MaxPassengers { get; set; }

        public float FuelTank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cargoes> Cargoes { get; set; }
    }
}
