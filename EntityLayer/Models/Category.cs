using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public string EnName { get; set; }
        //public string Description { get; set; }
        //public int? Sort { get; set; }
        public int? UserID { get; set; }
        public DateTime? CreateTime { get; set; }

    }
}
