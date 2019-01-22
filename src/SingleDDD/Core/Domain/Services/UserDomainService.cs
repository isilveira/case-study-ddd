using SingleDDD.Core.Domain.Entities;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Repositories;
using SingleDDD.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Core.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private IUserRepository UserRepository { get; set; }
        public UserDomainService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public User CreateUser(string email, string password)
        {
            var user = new User();

            user.SetData(email, password);

            IsEmailUnique(user.Email);

            return user;
        }

        public User UpdateUser(long id, string email, string password)
        {
            var user = UserRepository.GetByID(id);

            user.UpdateData(email, password);

            IsEmailUnique(user.Email, user.UserID);

            return user;
        }

        private void IsEmailUnique(string email, long? id = null)
        {
            if (UserRepository.ExistUserWithEmail(email, id))
                throw new Exception("A user already exists with this email!");
        }

        public User Activate(long id)
        {
            var user = UserRepository.GetByID(id);

            user.Activate();

            return user;
        }

        public User Deactivate(long id)
        {
            var user = UserRepository.GetByID(id);

            user.Deactivate();

            return user;
        }
    }
}
