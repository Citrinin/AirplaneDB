using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ICargoesRepository:IBaseRepository<Cargo>
    {

        //Task<IEnumerable<Cargo>> GetAirplaneItemsAsync(int airplaneID);
        IEnumerable<Cargo> GetAirplaneItems(int airplaneID);
    }

}
