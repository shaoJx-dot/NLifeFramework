using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class CategoryEntity : Category
    {
        public CategoryEntity()
        {
            this.TopicList = new List<Topic>();
        }
        public Users UsersEntity { get; set; }
        public List<Topic> TopicList { get; set; }

        
    }
}
