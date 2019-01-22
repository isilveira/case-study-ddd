using SingleDDD.Core.Domain.Entities;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Contexts;
using SingleDDD.Core.Domain.Interfaces.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Core.Infrastructures.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ISingleDDDContext Context {get;set;}
        public UserRepository(ISingleDDDContext context)
        {
            Context = context;
        }

        public void Insert(User user)
        {
            Context.Users.Add(user);
        }

        public void Delete(User user)
        {
            Context.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public List<User> GetByRange(int pageSize, int pageNumber)
        {
            return Context.Users.Skip(pageSize * pageNumber).Take(pageSize).ToList();
        }

        public User GetByID(long id)
        {
            return Context.Users.SingleOrDefault(x => x.UserID == id);
        }

        public int SaveContext()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveContextAsync()
        {
            return Context.SaveChangesAsync();
        }

        public bool ExistUserWithEmail(string email, long? id = null)
        {
            var query = Context.Users.Where(x => x.Email == email);

            if (id.HasValue)
            {
                query = query.Where(x => x.UserID != id.Value);
            }

            return query.Any();
        }
    }
}
