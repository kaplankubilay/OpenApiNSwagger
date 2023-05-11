using Core.Utilities.Results;
using GroceryDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGroceryService
    {
        IDataResult<IList<GroceryItem>> GetAll();
        IDataResult<GroceryItem> GetByGroceryId(int groceryItemId);
        IResult AddGrocery(GroceryItem groceryItem);
        IResult UpdateProduct(GroceryItem groceryItem);
    }
}
