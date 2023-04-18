using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Topic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Pic { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? ReplyTime { get; set; }
        public int? ReplyCount { get; set; }
        public string Face { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public int? CategoryID { get; set; }
        public int? State { get; set; }
        
    }
}
