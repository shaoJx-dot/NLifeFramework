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
    public class TopicService : ServiceBaseExtension<Topic>
    {
        private readonly TopicRepository _topicRepository;
        public TopicService(TopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public bool Exist(string Name)
        {
            return false;
        }

        public Topic Add(Topic topic)
        {
            IDbTransaction tran = this.DBSession.Begin();
            this.Insert(topic, tran);
            this.DBSession.Commit();
            
            return topic;
        }

        public TopicEntity Find(int ID)
        {
            //IEnumerable<Users> list1 = this.GetList(new { Name = sName }).DefaultIfEmpty<Users>();

            //var list = this.LambdaQuery()
            //                  .Where(p => p.ID == ID);
            //Topic topic = list.ToList().FirstOrDefault();

            return _topicRepository.GetTopicByID(ID);

        }

        public IEnumerable<TopicEntity> FindByUser(int userID)
        {
            return _topicRepository.GetTopicUser(userID);
        }

        public IEnumerable<Topic> FindALL()
        {
            return _topicRepository.GetTopicAll();
            //IEnumerable<Users> list1 = this.GetList(new { Name = sName }).DefaultIfEmpty<Users>();
            //var list = this.LambdaQuery()
            //                  .OrderBy(p =>p.CreateTime);
            //return list.ToList();
        }
        public IEnumerable<Topic> GetPage(int startline, int endline)
        {
            return _topicRepository.RangeQuery(startline,endline);
        }
        public int GetRecord()
        {
            return _topicRepository.QueryDataCount();
        }
    }
}
