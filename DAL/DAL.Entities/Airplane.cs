using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Airplane")]
    public class Airplane
    {
        public Airplane()
        {
            Cargoes = new List<Cargoes>();
        }
        public int AirplaneID { get; set; }
        public string ModelName { get; set; }
        public float MaxCargo { get; set; }
        public int MaxPassengers { get; set; }
        public float FuelTank { get; set; }
        //ссылка на грузы
        public virtual List<Cargoes> Cargoes { get; set; }
    }
}
