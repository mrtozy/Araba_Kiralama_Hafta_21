using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {

        IUserDal _userDal;
     

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
            
        }
       
        public IResult UpdateUserNames(User user)
        {
            var updatedUser = _userDal.Get(u => u.Id == user.Id);
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
            _userDal.Update(updatedUser);
            return new SuccessResult(Messages.KulaniciGuncellendi);
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }
        private IResult CheckIfUserIdExist(int userId)
        {
            var result = _userDal.GetAll(u => u.Id == userId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.KullaniciYok);
            }
            return new SuccessResult();
        }
        public IResult Delete(int userId)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(userId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var deletedUser = _userDal.Get(u => u.Id == userId);
            _userDal.Delete(deletedUser);
            return new SuccessResult(Messages.KulaniciSilindi);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Email==email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        private bool BaseCheckIfEmailExist(string userEmail)
        {
            return _userDal.GetAll(u => u.Email == userEmail).Any();
        }
        private IResult CheckIfEmailAvailable(string userEmail)
        {
            var result = BaseCheckIfEmailExist(userEmail);
            if (!result)
            {
                return new ErrorResult(Messages.EpostayaUlasilamaz);
            }
            return new SuccessResult();
        }
        public IResult Update(User user)
        {
            var rulesResult = BusinessRules.Run(CheckIfUserIdExist(user.Id)
                , CheckIfEmailAvailable(user.Email));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            _userDal.Update(user);
            return new SuccessResult(Messages.KulaniciGuncellendi);
        }
    }
}
