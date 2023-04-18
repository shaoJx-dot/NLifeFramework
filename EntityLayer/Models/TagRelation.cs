using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class TagRelation
    {
        public int ID { get; set; }
        public int? TagsID { get; set; }
        public int? TopicID { get; set; }

    }
}
