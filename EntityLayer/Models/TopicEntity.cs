using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class TopicEntity : Topic
    {
        public TopicEntity()
        {
            this.TagsList = new List<Tags>();
            this.TopicCommentList = new List<TopicComment>();
        }
        public Users UsersEntity { get; set; }
        public Category CategoryEntity { get; set; }
        public List<Tags> TagsList { get; set; }
        public List<TopicComment> TopicCommentList { get; set; }

        
    }
}
