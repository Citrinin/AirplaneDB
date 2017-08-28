using GalaSoft.MvvmLight;
using System.Configuration;
using Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace labka8.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        IAirplaneRepository apRepository;
        ICargoesRepository crRepository;

        List<Action> actions = new List<Action>();
        private ObservableCollection<Airplane> airplaneCollection;

        public ObservableCollection<Airplane> AirplaneCollection
        {
            get { return airplaneCollection; }
            set { Set(() => AirplaneCollection, ref airplaneCollection, value); }
        }

        private ObservableCollection<Cargo> airplaneCargoes;

        public ObservableCollection<Cargo> AirplaneCargoes
        {
            get { return airplaneCargoes; }
            set { Set(() => AirplaneCargoes, ref airplaneCargoes, value); }
        }

        public MainViewModel(IAirplaneRepository apRepository, ICargoesRepository crRepository)
        {
            this.apRepository = apRepository;
            this.crRepository = crRepository;
            this.AirplaneCollection = new ObservableCollection<Airplane>(apRepository.GetAll());
            this.AirplaneCargoes = new ObservableCollection<Cargo>();
            //??
            Action actAddNewAirplane = () =>
             {
                 AddAirplaneDialog addAirplne = new AddAirplaneDialog();
                 if (addAirplne.ShowDialog() == true)
                 {
                     Airplane ap = new Airplane()
                     {
                         ModelName = addAirplne.ModelName,
                         MaxPassengers = addAirplne.MaxPassengers,
                         MaxCargo = addAirplne.MaxCargo,
                         FuelTank = addAirplne.FuelTank
                     };
                     apRepository.Add(ref ap);
                     this.AirplaneCollection.Add(ap);
                 }
             };
            actions.Add(actAddNewAirplane);
            this.AddNewAirplaneCommand = new RelayCommand(actAddNewAirplane);
            ////////commands
            this.DGSelectionChanged = new RelayCommand(() =>
            {
                if (ActiveAirplane != null)
                {
                    AirplaneCargoes = new ObservableCollection<Cargo>(this.crRepository.GetAirplaneItems(ActiveAirplane.AirplaneID));
                }
                //AirplaneCargoes = new ObservableCollection<Cargo>(this.crRepository.GetAirplaneItemsAsync(ActiveAirplane.AirplaneID).Result);
            });



            this.DeleteAirplaneCommand = new RelayCommand(() =>
            {
                apRepository.Remove(ActiveAirplane);
                AirplaneCollection.Remove(ActiveAirplane);
                DGSelectionChanged.Execute(null);
                AirplaneCargoes.Clear();

            });
            this.DeleteCargoCommand = new RelayCommand(() =>
            {
                if (ActiveAirplane != null && ActiveCargo != null)
                {
                    crRepository.Remove(ActiveCargo);
                    DGSelectionChanged.Execute(null);
                }
            }/*,()=>ActiveAirplane!=null&&ActiveCargo!=null*/); //почему не работает?
            this.AddNewCargoCommand = new RelayCommand(() =>
            {
                if (ActiveAirplane != null)
                {
                    AddCargoDialog acd = new AddCargoDialog();
                    if (acd.ShowDialog() == true)
                    {
                        Cargo newCargo = new Cargo()
                        {
                            CargoType = acd.CargoType,
                            Destination = acd.Destination,
                            Weight = acd.Weight,
                            AirplaneID = ActiveAirplane.AirplaneID
                        };
                        crRepository.Add(ref newCargo);
                        DGSelectionChanged.Execute(null);
                    }
                }
            });
            this.UpdateAirplaneCommand = new RelayCommand(() =>
            {
                if (ActiveAirplane != null)
                {
                    AddAirplaneDialog updAirplaneDialog = new AddAirplaneDialog(ActiveAirplane);
                    if (updAirplaneDialog.ShowDialog() == true)
                    {
                        ActiveAirplane.ModelName = updAirplaneDialog.ModelName;
                        ActiveAirplane.MaxCargo = updAirplaneDialog.MaxCargo;
                        ActiveAirplane.MaxPassengers = updAirplaneDialog.MaxPassengers;
                        ActiveAirplane.FuelTank = updAirplaneDialog.FuelTank;
                        apRepository.Update(ActiveAirplane);
                    }
                }
            });
            this.UpdateCargoCommand = new RelayCommand(() =>
            {
                if (ActiveAirplane != null && activeCargo != null)
                {
                    AddCargoDialog updCargoDialog = new AddCargoDialog(activeCargo);
                    if (updCargoDialog.ShowDialog() == true)
                    {
                        ActiveCargo.CargoType = updCargoDialog.CargoType;
                        ActiveCargo.Destination = updCargoDialog.Destination;
                        ActiveCargo.Weight = updCargoDialog.Weight;
                        crRepository.Update(ActiveCargo);
                    }
                }
            });
            FilterAirplaneCommand = new RelayCommand(() =>
            {
                AirplaneCollection = new ObservableCollection<Airplane>(apRepository.GetAirplanesByModelName(AirplaneSearchString));
            });
        }

        public RelayCommand DGSelectionChanged { get; set; }
        public RelayCommand AddNewAirplaneCommand { get; set; }
        public RelayCommand AddNewCargoCommand { get; set; }
        public RelayCommand DeleteAirplaneCommand { get; set; }
        public RelayCommand DeleteCargoCommand { get; set; }
        public RelayCommand UpdateAirplaneCommand { get; set; }
        public RelayCommand UpdateCargoCommand { get; set; }
        public RelayCommand FilterAirplaneCommand { get; set; }

        private Airplane activeAirplane;
        public Airplane ActiveAirplane
        {
            get { return activeAirplane; }
            set { Set(() => ActiveAirplane, ref activeAirplane, value); }
        }
        private Cargo activeCargo;

        public Cargo ActiveCargo
        {
            get { return activeCargo; }
            set { Set(() => ActiveCargo, ref activeCargo, value); }
        }

        private string airplaneSearchString;

        public string AirplaneSearchString
        {
            get { return airplaneSearchString; }
            set { Set(() => AirplaneSearchString, ref airplaneSearchString, value); }
        }

    }
}