using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using GroceryDal;
using GroceryDal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        public IDataResult<IList<GroceryItem>> GetAll()
        {
            IList<GroceryItem> results = _groceryRepository.GetAll();
            return new SuccessDataResult<IList<GroceryItem>>(results, Messages.GroceryListed);
        }

        public IDataResult<GroceryItem> GetByGroceryId(int groceryItemId)
        {
            return new SuccessDataResult<GroceryItem>(_groceryRepository.Get(p => p.Id == groceryItemId));
        }

        public IResult AddGrocery(GroceryItem groceryItem)
        {
            _groceryRepository.Add(groceryItem);
            return new Result(true);
        }

        public IResult UpdateProduct(GroceryItem groceryItem)
        {
            _groceryRepository.Update(groceryItem);
            return new Result(true);
        }
    }
}
