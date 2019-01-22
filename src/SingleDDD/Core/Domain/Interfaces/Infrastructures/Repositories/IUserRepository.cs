using SingleDDD.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Core.Domain.Interfaces.Infrastructures.Repositories
{
    public interface IUserRepository
    {
        void Insert(User user);
        void Delete(User user);

        List<User> GetAll();
        List<User> GetByRange(int pageSize, int pageNumber);
        User GetByID(long id);

        int SaveContext();
        Task<int> SaveContextAsync();
        bool ExistUserWithEmail(string email, long? id = null);
    }
}
