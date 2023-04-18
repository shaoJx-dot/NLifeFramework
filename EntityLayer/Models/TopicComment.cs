using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class TopicComment
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public int? TopicID { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? UserID { get; set; }
        public int? Floors { get; set; }

    }
}
