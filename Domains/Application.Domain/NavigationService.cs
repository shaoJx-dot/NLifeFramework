using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Domain
{
    public class NavigationService : ServiceBaseExtension<Navigation>
    {
        private static MenuClassDictionary menuClassDictionary = new MenuClassDictionary();

        public NavigationService()
        {
            InitMenu();
        }

        public IEnumerable<Navigation> FindList()
        {
            //IEnumerable<Users> list1 = this.GetList(new { Name = sName }).DefaultIfEmpty<Users>();
            var list = this.LambdaQuery().OrderBy(p => new { p.Sort });
            Navigation navigation = list.ToList().FirstOrDefault();

            return list.ToList();
        }

        public static MenuClassDictionary GetCurrent(int index)
        {
            InitMenu();
            switch (index)
            {
                case 0:
                    menuClassDictionary.Index = "active";
                    break;
                case 1:
                    menuClassDictionary.Focus = "active";
                    break;
                case 2:
                    menuClassDictionary.Case = "active";
                    break;
                case 3:
                    menuClassDictionary.Ranklist = "active";
                    break;
                case 4:
                    menuClassDictionary.Misc = "active";
                    break;
                default:
                    break;
            }

            return menuClassDictionary;
        }

        public static void InitMenu()
        {
            menuClassDictionary.Index = "noactive";
            menuClassDictionary.Focus = "noactive";
            menuClassDictionary.Case = "noactive";
            menuClassDictionary.Ranklist = "noactive";
            menuClassDictionary.Misc = "noactive";
        }
    }
}
