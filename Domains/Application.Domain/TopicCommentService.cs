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
    public class TopicCommentService : ServiceBaseExtension<TopicComment>
    {
        private readonly TopicCommentRepository _topicCommentRepository;
        public TopicCommentService(TopicCommentRepository topicCommentRepository)
        {
            
            this._topicCommentRepository = topicCommentRepository;
        }

        public TopicComment Add(TopicComment topicComment)
        {
            IDbTransaction tran = this.DBSession.Begin();
            this.Insert(topicComment, tran);
            this.DBSession.Commit();

            return topicComment;
        }

        public IEnumerable<TopicComment> GetPage(int TopicID, int startline, int endline)
        {
            return _topicCommentRepository.RangeQuery(TopicID, startline, endline);
        }
        public int GetRecord(int TopicID)
        {
            return _topicCommentRepository.QueryDataCount(TopicID);
        }
    }
}
