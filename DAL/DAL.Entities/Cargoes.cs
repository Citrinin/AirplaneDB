

using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Cargoes
    {
        [Key]
        public int CargoID { get; set; }
        public string CargoType { get; set; }
        public string Destination { get; set; }
        public float Weight { get; set; }
        //ссылка на самолет 
        public int AirplaneID { get; set; }
        public Airplane Airplane { get; set; }
    }
}