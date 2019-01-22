using SingleDDD.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Models.UserViewModels
{
    public class PostUserViewModel: ViewModelBase
    {
        public string email { get; set; }
        public string password { get; set; }
        public PostUserViewModel()
        {

        }
    }
}
