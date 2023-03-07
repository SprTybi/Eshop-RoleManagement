using Security.DataAccessServiceContract.Repositories;
using Security.Domain.BaseModel;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.User;
using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
       
        private readonly SecurityContext db;
        public UserRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(UserAddModel model)
        {
            OperationResult op = new OperationResult("Add", "Users");
            try
            {
                var u = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Mobile = model.Mobile,
                    IsEmailActivated = model.IsEmailActivated,
                    UserName = model.UserName,
                    Password = model.Password,
                    RoleID = model.RoleID,
                };
                db.Users.Add(u);
                db.SaveChanges();
                op.ToSuccess(u.UserID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }
            return op;
        }

        public OperationResult Delete(int Id)
        {
            OperationResult op = new OperationResult("Remove", "Users", Id);
            {
                try
                {
                    var u = db.Users.FirstOrDefault(x => x.UserID == Id);
                    db.Users.Remove(u);
                    db.SaveChanges();
                    op.ToSuccess(Id, "Delete Successfully!");
                }
                catch (Exception ex)
                {
                    op.ToFail("Delete Failed" + ex.Message);
                }
                return op;
            }
        }

        public User Get(int Id)
        {
            return db.Users.FirstOrDefault(x => x.UserID == Id);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList()
;
        }

        public List<UserListItem> Search(UserSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Users select item;
            if (!string.IsNullOrEmpty(sm.UserName))
            {
                q = q.Where(x => x.UserName.StartsWith(sm.UserName));
            }
            if (!string.IsNullOrEmpty(sm.LastName))
            {
                q = q.Where(x => x.LastName.StartsWith(sm.LastName));
            }
            if (!string.IsNullOrEmpty(sm.FirstName))
            {
                q = q.Where(x => x.FirstName.StartsWith(sm.FirstName));
            }
            if (!string.IsNullOrEmpty(sm.Mobile))
            {
                q = q.Where(x => x.Mobile.StartsWith(sm.Mobile));
            }
            if (sm.RoleID == -1)
            {
                sm.RoleID = null;
            }
            if (sm.RoleID != null)
            {
                q = q.Where(x => x.RoleID == sm.RoleID);
            }

            RecordCount = q.Count();
            return q.Select(x => new UserListItem
            {
                UserID = x.UserID,
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                Mobile = x.Mobile,
                FirstName = x.FirstName,
                LastName = x.LastName,
                RoleName = x.Role.RoleName
            }).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(UserUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Users");
            try
            {
                var u = db.Users.FirstOrDefault(x => x.UserID == model.UserID);
                u.UserName = model.UserName;
                u.FirstName = model.FirstName;
                u.Email = model.Email;
                u.LastName = model.LastName;
                u.Mobile = model.Mobile;
                u.Password = model.Password;
                u.IsEmailActivated = model.IsEmailActivated;
                u.RoleID = model.RoleID;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed!" + ex.Message);
            }
            return op;
        }

        public bool ExistUserName(string userName)
        {
            return db.Users.Any(x => x.UserName == userName);
        }

        public List<RoleDrp> RoleDrp()
        {
            var q = from item in db.Roles select item;
            return q.Select(x => new RoleDrp
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();
        }

        public bool ExistUserName(string userName, int userId)
        {
            return db.Users.Any(x=>x.UserName == userName && x.UserID == userId);
        }
    }
}
