using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cargo:ViewModelBase
    {
        private int cargoID;

        public int CargoID
        {
            get { return cargoID; }
            set {Set(nameof(CargoID),ref cargoID,value); }
        }

        private string cargoType;

        public string CargoType
        {
            get { return cargoType; }
            set { Set(nameof(CargoType),ref cargoType, value); }
        }

        private string destination;

        public string Destination
        {
            get { return destination; }
            set { Set(nameof(Destination),ref destination,value); }
        }

        private float weight;

        public float Weight
        {
            get { return weight; }
            set { Set(nameof(Weight),ref weight,value); }
        }

        private int airplaneID;

        public int AirplaneID
        {
            get { return airplaneID; }
            set { Set(() => AirplaneID, ref airplaneID, value); }
        }
    }
}
