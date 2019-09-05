using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMVC.DAL.Entities
{
    //[Table("tbl_Games")]
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int Year { get; set; }

        public virtual Game PrevGame { get; set; }

        public virtual Producer Producer { get; set; }
    }
}
