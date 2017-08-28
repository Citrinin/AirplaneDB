using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL;
using AutoMapper;
using System.Windows;

namespace Model
{
    public class AirplaneRepository : IAirplaneRepository
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        AirplanesContext context;
        public AirplaneRepository()
        {
            context = new AirplanesContext(connectionStr);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DAL.Airplane, Model.Airplane>();
                cfg.CreateMap<Model.Airplane, DAL.Airplane>();
                cfg.CreateMap<DAL.Cargoes, Model.Cargo>();
                cfg.CreateMap<Model.Cargo, DAL.Cargoes>();
            });

        }
        public void Add(ref Airplane item)
        {
            DAL.Airplane airplaneDB = Mapper.Map<DAL.Airplane>(item);
            context.Airplane.Add(airplaneDB);
            context.SaveChanges();
            item.AirplaneID = airplaneDB.AirplaneID;
        }

        public IEnumerable<Airplane> GetAirplanesByModelName(string name)
        {
            return GetAll().Where(ap => ap.ModelName.ToLower().Contains(name));
        }

        public IEnumerable<Airplane> GetAll()
        {

            return context.Airplane.ToArray().Select(airplane => Mapper.Map<Model.Airplane>(airplane));

            //foreach (DAL.Airplane item in context.Airplane)
            //{
            //    //yield return new Model.Airplane()
            //    //{
            //    //    AirplaneID = item.AirplaneID,
            //    //    FuelTank = item.FuelTank,
            //    //    MaxCargo = item.MaxCargo,
            //    //    MaxPassengers = item.MaxPassengers,
            //    //    ModelName = item.ModelName
            //    //};
            //    yield return Mapper.Map<Model.Airplane>(item);
            //}
        }


        public void Remove(Airplane itemToDelete)
        {
            context.Cargoes.RemoveRange(context.Airplane.First(ap => ap.AirplaneID == itemToDelete.AirplaneID).Cargoes);
            context.Airplane.Remove(context.Airplane.First(ap => ap.AirplaneID == itemToDelete.AirplaneID));
            context.SaveChanges();
        }

        public void Update(Airplane item)
        {
            DAL.Airplane updAP = context.Airplane.First(ap => ap.AirplaneID == item.AirplaneID);
            updAP.ModelName = item.ModelName;
            updAP.MaxCargo = item.MaxCargo;
            updAP.MaxPassengers = item.MaxPassengers;
            updAP.FuelTank = item.FuelTank;
            context.SaveChanges();
        }
    }
}
