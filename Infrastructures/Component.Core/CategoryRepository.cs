using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Component.Data;
using Component.Web;
using DapperExtensions;
using Component.Core.Common;
using Models;
using Dapper;
using DapperExtensions.Lambda;


namespace Component.Core
{
    /// <summary>
    /// Users：数据访问对象
    /// </summary>
    public class CategoryRepository : RepositoryBase<Category>
    {
        /// <summary>
        /// Dapper 原生用法
        /// </summary>
        public IEnumerable<TopicEntity> GetTopicUser(int userID)
        {
            using (IDbConnection conn = this.DBSession.Connection)
            { 
                DynamicParameters par = new DynamicParameters();
                string sql = @"SELECT * FROM  Topic AS A
                            Inner JOIN Category  AS B ON  A.CategoryID = B.ID
                            Inner JOIN Users  AS C ON  A.UserID = C.ID 
                            Where C.ID=@userID Order by A.CreateTime DESC";
                par.Add("userID", userID);
                IEnumerable<TopicEntity> data = conn.Query<TopicEntity, Category, Users, TopicEntity>
                (sql, (topic, category, user) =>
                {
                    topic.CategoryEntity = category;
                    topic.UsersEntity = user;
                    return topic;
                }, param: par, splitOn: "ID, ID").ToList();

                return data;
            }
        }

        public TopicEntity GetTopicByID(int topicID)
        {
            IDbConnection conn = this.DBSession.Connection;
            DynamicParameters par = new DynamicParameters();
            string sql = @"SELECT * FROM  Topic AS A with(nolock)
                        Inner JOIN Category  AS B with(nolock) ON  A.CategoryID = B.ID
                        Inner JOIN Users  AS C with(nolock) ON  A.UserID = C.ID 
                        Where A.ID=@topicID";
            par.Add("topicID", topicID);
            TopicEntity data = conn.Query<TopicEntity, Category, Users, TopicEntity>
            (sql, (topic, category, user) =>
            {
                topic.CategoryEntity = category;
                topic.UsersEntity = user;
                return topic;
            }, param: par, splitOn: "ID, ID").ToList().FirstOrDefault<TopicEntity>();

            return data;
            
        }
        
        //获取数据库中数据的总条数
        public virtual int QueryDataCount(string enName)
        {
            IDbConnection conn = this.DBSession.Connection;
            DynamicParameters par = new DynamicParameters();
            string sql = @"SELECT COUNT(A.ID)
                        FROM  Topic AS A with(nolock)
                        Inner JOIN Category  AS B with(nolock) ON  A.CategoryID = B.ID
                        Inner JOIN Users  AS C with(nolock) ON  A.UserID = C.ID
                        Where B.EnName=@enName";
            par.Add("enName", enName);
            var queryResult = conn.Query<int>(sql, par);
            if (queryResult == null || !queryResult.Any())
            {
                return 0;
            }
            return queryResult.First();
            
        }
        //enName不要
        public virtual IEnumerable<TopicEntity> RangeQuery(string enName, int startline, int endline)
        {
            if (startline <= 0)
            {
                throw new ArgumentOutOfRangeException("起始行号必须大于0");
            }
            if (endline - startline < 0)
            {
                throw new ArgumentOutOfRangeException("结束行号不得小于起始行号");
            }

            string sql = @"SELECT 
                        A.*, B.*, C.*, D.*, F.*
                        FROM 
                        (
            	            SELECT top " + (endline - startline + 1) + @" * FROM Topic with(nolock)
            	            Where ID not in (select top " + (startline - 1) + @" ID from Topic with(nolock) order by CreateTime desc) order by CreateTime desc
                        ) AS A
                        Inner JOIN Category  AS B with(nolock) ON  A.CategoryID = B.ID
                        Inner JOIN Users  AS C with(nolock) ON  A.UserID = C.ID
                        Left Join TopicComment as D with(nolock) ON A.ID = D.TopicID
                        Left Join TagRelation as E with(nolock) ON A.ID = E.TopicID
                        Left Join Tags as F with(nolock) ON F.ID = E.TagsID
                        Where B.EnName=@enName
                        Order by A.CreateTime DESC";

            
            using (IDbConnection conn = this.DBSession.Connection)
            {
                List<TopicEntity> TopicEntitys = new List<TopicEntity>();
                DynamicParameters par = new DynamicParameters();
                par.Add("enName", enName);
                IEnumerable<TopicEntity> data = conn.Query<TopicEntity, Category, Users, TopicComment, Tags, TopicEntity>
                (sql, (topic, category, user, topicComment, tags) =>
                {
                    var currentTopic = TopicEntitys.Find(x => x.ID == topic.ID);
                    if (currentTopic == null)
                    {
                        topic.CategoryEntity = category;
                        topic.UsersEntity = user;
                        if (topicComment != null)
                            topic.TopicCommentList.Add(topicComment);
                        if (tags != null)
                            topic.TagsList.Add(tags);
                        TopicEntitys.Add(topic);
                        return topic;
                    }
                    else
                    {
                        var currentComment = currentTopic.TopicCommentList.Find(x => x.ID == topicComment.ID);
                        if (currentComment == null)
                        {
                            if (topicComment != null)
                                currentTopic.TopicCommentList.Add(topicComment);
                        }

                        var currentTags = currentTopic.TagsList.Find(x => x.ID == tags.ID);
                        if (currentTags == null)
                        {
                            if (tags != null)
                                currentTopic.TagsList.Add(tags);
                        }

                        return currentTopic;
                    }

                }, param: par, splitOn: "ID, ID, ID, ID, ID").ToList();

                return TopicEntitys;
                
            }
        }

        ///////////////////////////////////
    }
}
