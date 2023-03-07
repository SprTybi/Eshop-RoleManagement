using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SecurityContext db;
        public AccountRepository(SecurityContext db)
        {
            this.db = db;
        }

        public bool checkIfUserHasAccess(CheckPermission permission)
        {
            var q = from u in db.Users
                    join r in db.Roles on u.RoleID equals r.RoleID
                    join ra in db.RoleActions on r.RoleID equals ra.RoleID
                    join ac in db.projectActions on ra.ProjectActionID equals ac.ProjectActionID
                    join co in db.projectControllers on ac.ProjectController equals co

                    select new
                    {
                        co.ProjectControllerName,
                        ac.ProjectActionName
                        ,
                        u.UserName
                        ,
                        ra.HasPermission
                    };
            var result = q.First(x =>
            x.UserName == permission.UserName && x.ProjectActionName == permission.ActionName &&
                x.ProjectControllerName == permission.Controller);
            if (result == null)
            {
                return false;
            }

            return result.HasPermission;
        }

        public User GetFullInfo(string Username)
        {
            return db.Users.FirstOrDefault(x => x.UserName == Username);
        }

        public UserInfo GetUserInf(string Username)
        {
            var q = from r in db.Roles
                    join u in db.Users
 on r.RoleID equals u.RoleID
                    where u.UserName == Username || u.Email == Username
                    select new UserInfo
                    {
                        FullName = u.LastName + u.FirstName
                ,
                        RoleID = u.RoleID
                ,
                        RoleName = r.RoleName
                ,
                        UserName = u.UserName
                ,
                        UserID = u.UserID,
                        Mobile = u.Mobile,
                        Email = u.Email,
                    };
            return q.FirstOrDefault();
        }

        public OperationResult RegisterNewUser(User u)
        {
            OperationResult op = new OperationResult("Register New User", "User");
            try
            {
                if (u.RoleID == 0)
                {
                    u.RoleID = 1;
                }
                db.Users.Add(u);
                db.SaveChanges();
                op.ToSuccess(u.UserID, "User Registered Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Registeration Failed   " + ex.Message);
            }
            return op;
        }
    }
}

