using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Tags
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }

    }
}
