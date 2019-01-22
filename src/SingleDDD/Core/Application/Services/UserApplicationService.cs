using SingleDDD.Core.Domain.Entities;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Repositories;
using SingleDDD.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Core.Application.Services
{
    public class UserApplicationService
    {
        private IUserRepository UserRepository { get; set; }
        private IUserDomainService UserDomainService { get; set; }
        public UserApplicationService(
            IUserRepository userRepository,
            IUserDomainService userDomainService
        )
        {
            UserRepository = userRepository;
            UserDomainService = userDomainService;
        }

        public User Create(string email, string password)
        {
            var user = UserDomainService.CreateUser(email, password);

            UserRepository.Insert(user);
            UserRepository.SaveContext();

            return user;
        }

        public User Update(long id, string email, string password)
        {
            var user = UserDomainService.UpdateUser(id, email, password);

            UserRepository.SaveContext();

            return user;
        }

        public void Delete(long id)
        {
            var user = UserRepository.GetByID(id);

            UserRepository.Delete(user);
            UserRepository.SaveContext();
        }

        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        public List<User> GetByRange(int pageSize, int pageNumber)
        {
            return UserRepository.GetByRange(pageSize, pageNumber);
        }

        public User GetByID(long id)
        {
            return UserRepository.GetByID(id);
        }

        internal User Activate(long id)
        {
            var user = UserDomainService.Activate(id);
            UserRepository.SaveContext();

            return user;
        }

        internal User Deactivate(long id)
        {
            var user = UserDomainService.Deactivate(id);
            UserRepository.SaveContext();

            return user;
        }
    }
}
