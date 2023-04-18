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
    public class TopicCommentRepository : RepositoryBase<Topic>
    {        
        //获取数据库中数据的总条数
        public virtual int QueryDataCount(int TopicID)
        {
            IDbConnection conn = this.DBSession.Connection;

            DynamicParameters par = new DynamicParameters();
            string sql = @"Select COUNT(A.ID)
                            From TopicComment A with(nolock)
                            Inner JOIN Users AS B with(nolock) ON  A.UserID = B.ID
                            Where A.TopicID=@TopicID";
            
            par.Add("TopicID", TopicID);
            var queryResult = conn.Query<int>(sql, par);
            if (queryResult == null || !queryResult.Any())
            {
                return 0;
            }
            return queryResult.First();
            
        }

        public virtual IEnumerable<TopicCommentEntity> RangeQuery(int TopicID, int startline, int endline)
        {
            if (startline <= 0)
            {
                throw new ArgumentOutOfRangeException("起始行号必须大于0");
            }
            if (endline - startline < 0)
            {
                throw new ArgumentOutOfRangeException("结束行号不得小于起始行号");
            }

            
            using (IDbConnection conn = this.DBSession.Connection)
            {
                DynamicParameters par = new DynamicParameters();

                string sql = @"Select top " + (endline - startline + 1) + @"
                        A.*, B.*
                        From TopicComment A with(nolock)
                        Inner JOIN Users AS B with(nolock) ON  A.UserID = B.ID
                        Where A.ID not in (select top " + (startline - 1) + @" ID from TopicComment with(nolock) 
                        Where TopicID=@TopicID order by CreateTime, ID desc)
                        And A.TopicID=@TopicID
                        Order by A.CreateTime, A.ID DESC";
                
                par.Add("TopicID", TopicID);

                IEnumerable<TopicCommentEntity> data = conn.Query<TopicCommentEntity, Users, TopicCommentEntity>
                (sql, (topicComment, user) =>
                {
                    topicComment.UsersEntity = user;
                    return topicComment;
                }, param: par, splitOn: "ID").ToList();

                return data;
                
            }
        }

        ///////////////////////////////////
    }
}
