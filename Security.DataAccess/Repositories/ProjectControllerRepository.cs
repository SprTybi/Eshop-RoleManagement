using Security.DataAccessServiceContract.Repositories;
using Security.Domain.DTO.ProjectArea;
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
    public class ProjectControllerRepository : IProjectControllerRepository
    {

        private readonly SecurityContext db;
        public ProjectControllerRepository(SecurityContext db)
        {
            this.db = db;
        }

        //private ProjectControllerListItem ToListItem(ProjectController PC)
        //{
        //    var lstitm = new ProjectControllerListItem
        //    {
        //        ProjectControllerID = PC.ProjectControllerID,
        //        ProjectControllerName = PC.ProjectControllerName,
        //        PersianTitle = PC.PersianTitle
        //    };
        //    return lstitm;
        //}

        public OperationResult Add(ProjectControllerAddModel model)
        {
            OperationResult op = new OperationResult("Add", "ProjectControllers");
            try
            {
                var PC = new ProjectController
                {
                    ProjectControllerName = model.ProjectControllerName,
                    PersianTitle = model.PersianTitle,
                    ProjectAreaID = model.ProjectAreaID
                };
                db.projectControllers.Add(PC);
                db.SaveChanges();
                op.ToSuccess(PC.ProjectControllerID, "Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }
            return op;
        }

        public bool ExitsProjectControllerName(string ProjectControllerName)
        {
            return db.projectControllers.Any(x => x.ProjectControllerName == ProjectControllerName);

        }

        public bool ExitsProjectControllerName(string ProjectControllerName, int ProjectControllerId)
        {
            return db.projectControllers.Any(x => x.ProjectControllerName == ProjectControllerName && x.ProjectControllerID == ProjectControllerId);
        }

        public ProjectController Get(int id)
        {
            return db.projectControllers.FirstOrDefault(x => x.ProjectControllerID == id);
        }

        public List<ProjectController> GetAll()
        {
            return db.projectControllers.ToList();
        }

        public List<ProjectAreaDrop> ProjectAreaDrps()
        {
            var q = from item in db.ProjectAreas select item;
            return q.Select(x => new ProjectAreaDrop
            {
                AreaName = x.AreaName,
                ProjectAreaID = x.ProjectAreaID
            }).ToList();
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", "ProjectControllers");
            try
            {
                var pc = db.projectControllers.FirstOrDefault(x => x.ProjectControllerID == id);
                db.projectControllers.Remove(pc);
                db.SaveChanges();
                op.ToSuccess(pc.ProjectControllerID, "Delete Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Delete Failed " + ex.Message);
            }
            return op;
        }

        public List<ProjectControllerListItem> Search(ProjectControllerSearchModel sm, out int RecordCount)
        {
            var q = from item in db.projectControllers select item;
            if (sm.ProjectAreaID == -1)
            {
                sm.ProjectAreaID = null;
            }

            if (sm.ProjectAreaID != null)
            {
                q = q.Where(x => x.ProjectAreaID == sm.ProjectAreaID);
            }

            if (!string.IsNullOrEmpty(sm.PersianTitle))
            {
                q = q.Where(x => x.PersianTitle.StartsWith(sm.PersianTitle));
            }

            if (!string.IsNullOrEmpty(sm.ProjectControllerName))
            {
                q = q.Where(x => x.ProjectControllerName.StartsWith(sm.ProjectControllerName));
            }

            RecordCount = q.Count();
            return q.Select(x => new ProjectControllerListItem
            {
                ProjectControllerID = x.ProjectControllerID,
                ProjectControllerName = x.ProjectControllerName,
                PersianTitle = x.PersianTitle,
                ProjectAreaName = x.ProjectArea.AreaName
            }).OrderByDescending(x => x.ProjectControllerID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(ProjectControllerUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "ProjectControllers");

            try
            {
                var pc = db.projectControllers.FirstOrDefault(x => x.ProjectControllerID == model.ProjectControllerID);
                pc.ProjectControllerName = model.ProjectControllerName;
                pc.PersianTitle = model.PersianTitle;

                db.SaveChanges();
                op.ToSuccess(pc.ProjectControllerID, "Update Successfully");

            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed " + ex.Message);
            }
            return op;
        }
    }
}

