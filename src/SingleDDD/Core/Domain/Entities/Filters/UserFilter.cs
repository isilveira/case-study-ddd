using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Core.Domain.Entities.Filters
{
    public class UserFilter
    {
        public string Email { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? RegistrationDateFrom { get; set; }
        public DateTime? RegistrationDateUntil { get; set; }
        public bool? Actives { get; set; }
        public DateTime? DeactivationDate { get; set; }
        public DateTime? DeactivationDateFrom { get; set; }
        public DateTime? DeactivationDateUntil { get; set; }
    }
}
