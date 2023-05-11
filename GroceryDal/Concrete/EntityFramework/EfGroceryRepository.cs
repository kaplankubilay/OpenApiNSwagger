using Core.DataAccess.EntityFramework;
using GroceryDal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryDal.Concrete.EntityFramework
{
    public class EfGroceryRepository : EfEntityRepositoryBase<GroceryItem,GroceryDbCotext>,IGroceryRepository
    {
    }
}
