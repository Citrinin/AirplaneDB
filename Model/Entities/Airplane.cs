using GalaSoft.MvvmLight;

namespace Model
{
    public class Airplane:ViewModelBase
    {

        private int airplaneID;

        public int AirplaneID
        {
            get { return airplaneID; }
            set { Set(nameof(AirplaneID), ref airplaneID, value); }
        }

        private string modelName;

        public string ModelName
        {
            get { return modelName; }
            set { Set(nameof(ModelName), ref modelName, value); }
        }

        private float maxCargo;

        public float MaxCargo
        {
            get { return maxCargo; }
            set { Set(nameof(MaxCargo),ref maxCargo, value); }
        }

        private int  maxPassengers;

        public int  MaxPassengers
        {
            get { return maxPassengers; }
            set { Set(nameof(MaxPassengers),ref maxPassengers,value); }
        }

        private float fuelTank;

        public float FuelTank
        {
            get { return fuelTank; }
            set {Set(nameof(FuelTank), ref fuelTank, value); }
        }


    }
}
