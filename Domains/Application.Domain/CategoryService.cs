using System;
using System.Linq;
using Models;
using Component.Core;
using System.Data;
using System.Collections.Generic;


namespace Application.Domain
{
    /// <summary>
    /// Users：服务访问对象
    /// </summary>
    public class CategoryService : ServiceBaseExtension<Category>
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool Exist(string Name)
        {
            return false;
        }

        public Category Add(Category category)
        {
            IDbTransaction tran = this.DBSession.Begin();
            this.Insert(category, tran);
            this.DBSession.Commit();
            
            return category;
        }

        public Category Find(string enName)
        {
            //var list = this.LambdaQuery()
            //                  .Where(p => p.EnName == enName).ToList().FirstOrDefault<Category>();

            //return list;
            return null;
        }

        public IEnumerable<Category> Find(int userID)
        {
            var list = this.LambdaQuery()
                              .Where(p => p.UserID == userID);

            return list.ToList();
        }

        public IEnumerable<Topic> GetPage(string enName, int startline, int endline)
        {
            return _categoryRepository.RangeQuery(enName, startline, endline);
        }
        public int GetRecord(string enName)
        {
            return _categoryRepository.QueryDataCount(enName);
        }

    }
}
