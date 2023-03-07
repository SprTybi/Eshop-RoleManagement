using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.DataAcceServiceContract.Repositories;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;

namespace Shopping.DataAccess.Repositories
{
    public class SupplierRepository:ISupplierRepository
    {
        private  Supplier ToSupplierModel(SupplierAddUpdateModel model)
        {
            Supplier s = new Supplier
            {
                Grade = model.Grade
                ,SupplierID = model.SupplierID
                ,SupplierName = model.SupplierName
                ,Tel = model.Tel
            };
            return s;
        }
        private readonly DomainModel.Models.EshopMashtiHasanContext db;

        public SupplierRepository(EshopMashtiHasanContext db)
        {
            this.db = db;
        }
        public Supplier Get(int id)
        {
            return db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public OperationResult Delete(int id)
        {
            OperationResult op = new OperationResult("Delete", "Supplier", id);

            try
            {
                var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == id);
                db.Suppliers.Remove(sup);
                db.SaveChanges();
                op.ToSuccess("Delete Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Delete Failed " + ex.Message);
            }

            return op;
        }

        public OperationResult Update(SupplierAddUpdateModel model)
        {
            OperationResult op = new OperationResult("Update", "Supplier", model.SupplierID);

            try
            {
                var sup = db.Suppliers.FirstOrDefault(x => x.SupplierID == model.SupplierID);
                sup.Grade = model.Grade;
                sup.SupplierName = model.SupplierName;
                sup.Tel = model.Tel;
                db.SaveChanges();
                op.ToSuccess("Update Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Update Failed " + ex.Message);
            }

            return op;
        }

        public OperationResult Add(SupplierAddUpdateModel model)
        {
            OperationResult op = new OperationResult("Add", "Supplier");

            try
            {
                var s = this.ToSupplierModel(model);
                db.Suppliers.Add(s);
                db.SaveChanges();
                op.ToSuccess(s.SupplierID,"Add Successfully");
            }
            catch (Exception ex)
            {
                op.ToFail("Add Failed " + ex.Message);
            }

            return op;
        }

        public List<SupplierListItem> Search(SupplierSearchModel sm, out int RecordCount)
        {
            var q = from item in db.Suppliers select new SupplierListItem {
                    SupplierID = item.SupplierID
                    ,Grade = item.Grade
                    ,ProductCount = item.Products.Count
                    ,SupplierName = item.SupplierName
                    ,Tel = item.Tel
            }
            ;
            if (!string.IsNullOrEmpty(sm.Tel))
            {
                q = q.Where(x => x.Tel.Contains(sm.Tel));
            }
            if (!string.IsNullOrEmpty(sm.SupplierName))
            {
                q = q.Where(x => x.SupplierName.StartsWith(sm.SupplierName));
            }
            RecordCount=q.Count();
            if (sm.PageSize == 0)
                sm.PageSize = 20;
            return q.OrderByDescending(x => x.SupplierID).Skip(sm.PageIndex * sm.PageSize).Take(sm.PageSize).ToList();

        }

        public bool hasProduct(int SupplierID)
        {
            return db.Products.Any(x => x.SupplierID == SupplierID);
        }

        public bool ExistSupplierName(string SupplierName)
        {
            return db.Suppliers.Any(x => x.SupplierName == SupplierName);
        }

        public bool ExistSupplierName(string SupplierName, int SupplierID)
        {
            return db.Suppliers.Any(x => x.SupplierName == SupplierName && x.SupplierID!=SupplierID);

        }
    }
}
