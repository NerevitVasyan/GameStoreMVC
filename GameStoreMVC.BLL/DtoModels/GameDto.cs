using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.BLL.DtoModels
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public ProducerDto Producer { get; set; }
    }
}
