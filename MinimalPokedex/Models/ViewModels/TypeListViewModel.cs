using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Models.ViewModels
{
    public class TypeListViewModel
    {
        public IQueryable<Type> Types { get; set; }
    }
}
