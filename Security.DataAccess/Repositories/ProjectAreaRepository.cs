using Security.DataAccessServiceContract.Repositories;
using Security.Domain.DTO.ProjectArea;
using Security.Domain.Models;
using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccess.Repositories
{

    public class ProjectAreaRepository : IProjectAreaRepository
    {
        private ProjectAreaListItem ToListItem(ProjectArea PArea)
        {
            var listitem = new ProjectAreaListItem
            {
                ProjectAreaID = PArea.ProjectAreaID,
                AreaName = PArea.AreaName,
                PersianTitle = PArea.PersianTitle,
            };
            return listitem;
        }
        private readonly SecurityContext db;
        public ProjectAreaRepository(SecurityContext db)
        {
            this.db = db;
        }
        public OperationResult Add(ProjectAreaAddModel model)
        {
            OperationResult op = new OperationResult("Add", "ProjectAreas");
            try
            {
                var PArea = new ProjectArea
                {
                    AreaName = model.AreaName,
                    PersianTitle = model.PersianTitle,
                };
                db.ProjectAreas.Add(PArea);
                db.SaveChanges();
                op.ToSuccess(PArea.ProjectAreaID, "Add Successfully");

            }
            catch (Exception ex)
            {

                op.ToFail("Add Failed" + ex.Message);

            }
            return op;
        }

        public ProjectArea Get(int id)
        {
            return db.ProjectAreas.FirstOrDefault(x => x.ProjectAreaID == id);

        }

        public List<ProjectArea> GetAll()
        {
            return db.ProjectAreas.ToList();
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", "ProjectActions");

            {
                try
                {
                    var PArea = db.ProjectAreas.FirstOrDefault(x => x.ProjectAreaID == id);
                    db.ProjectAreas.Remove(PArea);
                    db.SaveChanges();
                    op.ToSuccess(id, "Delete Successfully");

                }
                catch (Exception ex)
                {

                    op.ToFail("Delete Failed" + ex.Message);
                }
                return op;
            }
        }

        public List<ProjectAreaListItem> Search(ProjectAreaSearchModel sm, out int RecordCount)
        {
            var q = from item in db.ProjectAreas select item;
            if (!string.IsNullOrEmpty(sm.AreaName))
            {
                q = q.Where(x => x.AreaName.StartsWith(sm.AreaName));
            }
            if (!string.IsNullOrEmpty(sm.PersianTitle))
            {
                q = q.Where(x => x.PersianTitle.StartsWith(sm.PersianTitle));
            }
            RecordCount = q.Count();
            return q.Select(x => new ProjectAreaListItem
            {
                AreaName = x.AreaName,
                ProjectAreaID = x.ProjectAreaID,
                PersianTitle = x.PersianTitle,

            }
            ).OrderByDescending(x => x.ProjectAreaID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();
        }

        public OperationResult Update(ProjectAreaUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "ProjectAreas", model.ProjectAreaID);
            {

                try
                {
                    var PArea = Get(model.ProjectAreaID);
                    PArea.AreaName = model.AreaName;
                    PArea.PersianTitle = model.PersianTitle;
                    db.SaveChanges();
                    op.ToSuccess("Update Successfully");

                }
                catch (Exception ex)
                {

                    op.ToFail("Update Failed!" + ex.Message);
                }
                return op;
            }
        }

        public bool ExistAreaName(string AreaName)
        {
            return db.ProjectAreas.Any(x => x.AreaName == AreaName);

        }

        public bool ExistAreaName(string AreaName, int AreaId)
        {
            return db.ProjectAreas.Any(x => x.AreaName == AreaName && x.ProjectAreaID == AreaId);
        }
    }
}
