using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Configuration;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;

namespace Model
{
    public class CargoesRepository : ICargoesRepository
    {
        AirplanesContext context;

        private static string connectionStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        public CargoesRepository()
        {
            context = new AirplanesContext(connectionStr);
        }
        public void Add(ref Cargo item)
        {
            DAL.Cargoes cargoDB = Mapper.Map<DAL.Cargoes>(item);
            context.Cargoes.Add(cargoDB);
            context.SaveChanges();
            context.Entry(cargoDB);
            item.CargoID = cargoDB.CargoID;
        }

        public IEnumerable<Cargo> GetAll()
        {
            return context.Cargoes.ToArray().Select(cargo => Mapper.Map<Model.Cargo>(cargo));
        }

        public void Update(Cargo item)
        {
            DAL.Cargoes cg = context.Cargoes.First(c=>c.CargoID==item.CargoID);
            cg.CargoType = item.CargoType;
            cg.Destination = item.Destination;
            cg.Weight = item.Weight;
            context.SaveChanges();
        }

        //public async Task<IEnumerable<Cargo>> GetAirplaneItemsAsync(int airplaneID)
        //{
        //    await context.Cargoes.LoadAsync();
        //    //context.Cargoes.Load();
        //    return context.Airplane.ToArray().First(a => a.AirplaneID == airplaneID).Cargoes.Select(c => new Model.Cargo()
        //    {
        //        CargoID = c.CargoID,
        //        CargoType = c.CargoType,
        //        Destination = c.Destination,
        //        Weight = c.Weight
        //    });
        //}

        public IEnumerable<Cargo> GetAirplaneItems(int airplaneID)
        {
            return context.Airplane.ToArray()
                .First(a => a.AirplaneID == airplaneID)
                .Cargoes.Select(cargo => Mapper.Map<Model.Cargo>(cargo));
        }

        public void Remove(Cargo itemToDelete)
        {
            context.Cargoes.Remove(context.Cargoes.First(cr=>cr.CargoID==itemToDelete.CargoID));
            context.SaveChanges();
        }
    }
}
