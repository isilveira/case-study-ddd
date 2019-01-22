using SingleDDD.Core.Domain.Entities.Filters;
using SingleDDD.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Models.UserViewModels
{
    public class GetUserViewModel : ViewModelBase<UserFilter>
    {
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? RegistrationDateFrom { get; set; }
        public DateTime? RegistrationDateUntil { get; set; }
        public bool? Actives { get; set; }
        public DateTime? DeactivationDate { get; set; }
        public DateTime? DeactivationDateFrom { get; set; }
        public DateTime? DeactivationDateUntil { get; set; }

        public GetUserViewModel()
        {

        }

        public override UserFilter Extract()
        {
            return new UserFilter
            {
                Email = Email,
                RegistrationDate = RegistrationDate,
                RegistrationDateFrom = RegistrationDateFrom,
                RegistrationDateUntil = RegistrationDateUntil,
                Actives = Actives,
                DeactivationDate = DeactivationDate,
                DeactivationDateFrom = DeactivationDateFrom,
                DeactivationDateUntil = DeactivationDateUntil
            };
        }
    }
}
