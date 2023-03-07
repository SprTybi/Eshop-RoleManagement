using Security.DataAccessServiceContract.Repositories;
using Security.Domain.DTO.ProjectAction;
using Security.Domain.DTO.ProjectController;
using Security.Domain.Models;
using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{
    public class ProjectActionRepository : IProjectActionRepository
    {

        private readonly SecurityContext db;
        public ProjectActionRepository(SecurityContext db)
        {
            this.db = db;
        }

        public OperationResult Add(ProjectActionAddModel model)
        {
            OperationResult op = new OperationResult("Add", "ProjectActions");
            {
                try
                {
                    var pa = new ProjectAction
                    {
                        ProjectActionName = model.ProjectActionName,
                        PersianTitle = model.PersianTitle,
                        ProjectControllerID = model.ProjectControllerID
                    };
                    db.Add(pa);
                    db.SaveChanges();
                    op.ToSuccess(pa.ProjectActionID, "Add Successfully!!!!!!!!!");

                }
                catch (Exception ex)
                {

                    op.ToFail("Add Failed :(" + ex.Message);

                }
                return op;
            };
        }

        public ProjectAction Get(int id)
        {
            return db.projectActions.FirstOrDefault(x => x.ProjectActionID == id);
        }

        public List<ProjectAction> GetAll()
        {
            return db.projectActions.ToList();
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Remove", "ProjectActions", id);
            {
                try
                {
                    var pa = db.projectActions.FirstOrDefault(x => x.ProjectActionID == id);
                    db.projectActions.Remove(pa);
                    db.SaveChanges();
                    op.ToSuccess(id, "Remove Successfully");
                }
                catch (Exception ex)
                {

                    op.ToFail(id, "Delete Failed!" + ex.Message);
                }
                return op;
            }

        }


        public List<ProjectActionListItem> Search(ProjectActionSearchModel sm, out int RecordCount)
        {
            var q = from item in db.projectActions select item;
            if (!string.IsNullOrEmpty(sm.ProjectActionName))
            {
                q = q.Where(x => x.ProjectActionName.StartsWith(sm.ProjectActionName));
            }
            if (sm.ProjectControllerID == -1)
            {
                sm.ProjectControllerID = null;
            }
            if (sm.ProjectControllerID != null)
            {
                q = q.Where(x => x.ProjectController.ProjectControllerID == sm.ProjectControllerID);
            }
            if (!string.IsNullOrEmpty(sm.PersianTitle))
            {
                q = q.Where(x => x.PersianTitle.StartsWith(sm.PersianTitle));
            }
            RecordCount = q.Count();
            return q.Select(x => new ProjectActionListItem
            {
                ProjectActionName = x.ProjectActionName,
                ProjectActionID = x.ProjectActionID,
                PersianTitle = x.PersianTitle,
                ProjectControllerName = x.ProjectController.ProjectControllerName
            }
            ).OrderByDescending(x => x.ProjectActionID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(ProjectActionUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "ProjectActions");
            try
            {
                var pa = Get(model.ProjectActionID);
                pa.ProjectActionName = model.ProjectActionName;
                pa.PersianTitle = model.PersianTitle;


                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed!" + ex.Message);
            }
            return op;
        }

        public bool ExistProjectActionName(string ProjectActionName)
        {
            return db.projectActions.Any(x => x.ProjectActionName == ProjectActionName);
        }

        public List<ProjectControllerDrop> PcDrops()
        {
            var q = from item in db.projectControllers select item;
            return q.Select(x => new ProjectControllerDrop
            {
                ProjectControllerID = x.ProjectControllerID,
                ProjectControllerName = x.ProjectControllerName
            }).ToList();

        }

        public bool ExistProjectActionName(string ProjectActionName, int ProjectActionId)
        {
            return db.projectActions.Any(x => x.ProjectActionName == ProjectActionName && x.ProjectActionID == ProjectActionId);
        }

        public bool ExistProjectActionNameInController(int ControllerId, string ProjectActionName)
        {
            return db.projectControllers.Any(x=>x.ProjectControllerID == ControllerId && x.ProjectActions.Any(x=>x.ProjectActionName == ProjectActionName));
        }

        public int GetProjectControllerId(string controller)
        {
            var q = db.projectControllers.FirstOrDefault(x => x.ProjectControllerName == controller);
            return q.ProjectControllerID;
        }
        public string GetProjectControllerById(int controllerId)
        {
            var q = db.projectControllers.FirstOrDefault(x => x.ProjectControllerID == controllerId);
            return q.ProjectControllerName;
        }

        public bool ExistController(int ControllerId)
        {
            return db.projectControllers.Any(x => x.ProjectControllerID == ControllerId);

        }
    }
}
