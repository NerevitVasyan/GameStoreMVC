using GameStoreMVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.BLL.Filters
{
    public class GameFilter
    {
        public string Name { get; set; }
        public Expression<Func<Game,bool>> Expression { get; set; }
    }
}
