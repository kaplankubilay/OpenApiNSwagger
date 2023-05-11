using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.DataAccess.IEntityRepository;

namespace GroceryDal.Abstract
{
    public interface IGroceryRepository : IEntityRepository<GroceryItem>
    {
    }
}
