using SingleDDD.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Core.Domain.Interfaces.Services
{
    public interface IUserDomainService
    {
        User CreateUser(string nome, string password);
        User UpdateUser(long id, string nome, string password);
        User Activate(long id);
        User Deactivate(long id);
    }
}
