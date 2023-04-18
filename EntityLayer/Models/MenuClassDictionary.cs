using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MenuClassDictionary
    {
        public string Index { get; set; }
        public string Focus { get; set; }
        public string Case { get; set; }
        public string Ranklist { get; set; }
        public string Misc { get; set; }
    }

    [Serializable]
    public class Navigation
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int? Sort { get; set; }

    }
}
