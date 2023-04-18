using System;
using System.Linq;
using Models;
using Component.Core;
using System.Data;


namespace Application.Domain
{
    /// <summary>
    /// Users：服务访问对象
    /// </summary>
    public class UsersService : ServiceBaseExtension<Users>
    {
        private readonly UsersRepository _UsersRepository;
        //private UserInfoService _userInfoService;

        public String Str = Guid.NewGuid().ToString("N");

        //public UsersService(UsersRepository usersRepository, UserInfoService userInfoService)
        public UsersService(UsersRepository usersRepository)
        {
            _UsersRepository = usersRepository;
            //_userInfoService = userInfoService;

            //UsersEntity u = new UsersEntity();
            //UserInfoEntity ui = new UserInfoEntity();
            //using (HY.DataAccess.Transactions.TransactionScope tranScope = new HY.DataAccess.Transactions.TransactionScope())
            //{
            //    this.Insert(u);
            //    _userInfoService.Insert(ui);
            //    tranScope.Complete();
            //}



            //IDbTransaction tran = this.DBSession.Begin();
            //this.Insert(u,tran);
            //_userInfoService.Insert(ui,tran);
            //tran.Commit();


        }

        public bool Exist(string Name)
        {
            return false;
        }

        public Users Add(Users users)
        {
            IDbTransaction tran = this.DBSession.Begin();
            this.Insert(users, tran);
            this.DBSession.Commit();
            
            return users;
        }
        public bool Update(Users users)
        {
            IDbTransaction tran = this.DBSession.Begin();
            bool isSuccess = this.Update(users, tran);
            this.DBSession.Commit();

            return isSuccess;
        }

        public Users Find(string sName)
        {
            //IEnumerable<Users> list1 = this.GetList(new { Name = sName }).DefaultIfEmpty<Users>();
            var list = this.LambdaQuery()
                              .Where(p => p.Name == sName );
            Users users = list.ToList().FirstOrDefault();

            return users;
        }
        

    }
}
