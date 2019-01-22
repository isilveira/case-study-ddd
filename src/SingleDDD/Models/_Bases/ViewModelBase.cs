using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleDDD.Models.Bases
{
    public abstract class ViewModelBase
    {
    }
    public abstract class ViewModelBase<T>
    {
        public abstract T Extract();
    }

}
