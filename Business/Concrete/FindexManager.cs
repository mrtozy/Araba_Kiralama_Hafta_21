using Business.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FindexManager : IFindexService
    {
        private readonly ICustomerService _customerService;
        private readonly ICarService _carService;

        public FindexManager(ICustomerService customerService, ICarService carService)
        {
            _customerService = customerService;
            _carService = carService;
        }

        public IDataResult<int> GetCustomerFindexScore(int customerId)
        {
            var customerResult = IsCustomerIdExist(customerId);
            if (customerResult.Success)
            {
                //Simulated
                Random random = new Random();
                int randomFindexScore = Convert.ToInt16(random.Next(0, 1900));
                return new SuccessDataResult<int>(randomFindexScore);
            }

            return new ErrorDataResult<int>(-1, customerResult.Message);
        }

        public IDataResult<int> GetCarMinFindexScore(int carId)
        {
            var carResult = _carService.GetById(carId);
            if (!carResult.Success)
            {
                return new ErrorDataResult<int>(-1, carResult.Message);
            }

            return new SuccessDataResult<int>(carResult.Data.FindexScore);
        }

        private IResult IsCustomerIdExist(int customerId)
        {
            var result = _customerService.GetById(customerId);
            if (result.Success)
            {
                return new SuccessResult();
            }

            return new ErrorResult(result.Message);
        }
    }
}
