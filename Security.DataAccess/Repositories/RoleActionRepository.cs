using Security.DataAccessServiceContract.Repositories;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.Role;
using Security.Domain.DTO.RoleAction;
using Security.Domain.Models;
using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class RoleActionRepository : IRoleActionRepository
    {
        private readonly SecurityContext db;
        public RoleActionRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(RoleActionAddModel model)
        {
            OperationResult op = new OperationResult("Add", "RoleActions");
            try
            {
                var ra = new RoleAction
                {
                    ProjectActionID = model.ProjectActionID,
                    HasPermission = model.HasPermission,
                    RoleID = model.RoleID,
                };
                db.RoleActions.Add(ra);
                db.SaveChanges();
                op.ToSuccess(ra.RoleActionID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }
            return op;
        }

        public RoleAction Get(int id)
        {
            return db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
        }

        public List<RoleAction> GetAll()
        {
            return db.RoleActions.ToList();
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", "RoleActions");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == id);
                db.RoleActions.Remove(ra);
                db.SaveChanges();
                op.ToSuccess(ra.RoleActionID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToSuccess("Add Failed" + ex.Message);
            }
            return op;
        }

        public List<RoleActionListItem> Search(RoleActionSearchModel sm, out int RecordCount)
        {
            var q = from item in db.RoleActions select item;

            if (!string.IsNullOrEmpty(sm.RoleName))
            {
                q = q.Where(x => x.Role.RoleName.StartsWith(sm.RoleName));
            }
            if (!string.IsNullOrEmpty(sm.ProjectActionName))
            {
                q = q.Where(x => x.ProjectAction.ProjectActionName.StartsWith(sm.ProjectActionName));
            }


            RecordCount = q.Count();
            return q.Select(x => new RoleActionListItem
            {
                RoleActionID = x.RoleActionID,
                HasPermission = x.HasPermission,
                RoleName = x.Role.RoleName,
                ProjectActionName = x.ProjectAction.ProjectActionName,
                ProjectControllerName = x.ProjectAction.ProjectController.ProjectControllerName,

            }
            ).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(RoleActionUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "RoleActions");
            try
            {
                var ra = db.RoleActions.FirstOrDefault(x => x.RoleActionID == model.RoleActionID);


                ra.HasPermission = model.HasPermission;
                ra.RoleID = model.RoleID;
                ra.ProjectActionID = model.ProjectActionID;
                db.SaveChanges();
                op.ToSuccess(ra.RoleActionID, "Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed " + ex.Message);
            }
            return op;
        }

        public List<RoleDrp> RoleDrps()
        {
            var q = from item in db.Roles select item;
            return q.Select(x => new RoleDrp
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();
        }

        public List<ProjectActionDrop> ProjectActionDrops()
        {
            var q = from item in db.projectActions select item;
            return q.Select(x => new ProjectActionDrop
            {
                ProjectActionID = x.ProjectActionID,
                ProjectActionName = x.ProjectActionName
            }).ToList();
        }
    }
}
