using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICustomerService customerService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
          

            _rentalDal.Add(rental);

            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult();
        }

        public IResult RulesForDateAdding(Rental rental)
        {
            var result = BusinessRules.Run(
               CheckIfRentDateIsBeforeToday(rental.RentDate),
               CheckIfReturnDateIsBeforeRentDate(rental.ReturnDate, rental.RentDate),
               CheckIfThisCarIsAlreadyRentedInSelectedDateRange(rental),
             
               CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(rental),
               CheckIfThisCarHasBeenReturned(rental));

            if (result != null)
            {
                return result;
            }
            return new SuccessResult("Ödeme sayfasına yönlendiriliyorsunuz.");
        }

    
        

        private IResult CheckIfRentDateIsBeforeToday(DateTime rentDate)
        {
            if (rentDate.Date < DateTime.Now.Date)
            {
                return new ErrorResult(Messages.KiralamaTarihiBugundenOnceOlamaz);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsRentedAtALaterDateWhileReturnDateIsNull(Rental rental)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == rental.CarId
            && rental.ReturnDate == null
            && r.RentDate.Date > rental.RentDate.Date
            );

            if (result != null)
            {
                return new ErrorResult(Messages.AracIadeTarihBosBirakilamaz);
            }

            return new SuccessResult();
        }

        private IResult CheckIfThisCarHasBeenReturned(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.AracGeriGetirilmedi);
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.AracKiralamaTarihiDahaDolmadi);
                }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rental rental)
        {
            var result = _rentalDal.Get(r =>
            r.CarId == rental.CarId
            && (r.RentDate.Date == rental.RentDate.Date
            || (r.RentDate.Date < rental.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > rental.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult(Messages.AracZatenKiralanmisDurumda);
            }
            return new SuccessResult();
        }

    }
}

