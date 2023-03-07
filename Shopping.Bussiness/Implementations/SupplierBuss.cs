using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.BussinessServiceContract.BussinessModel.Supplier;
using Shopping.BussinessServiceContract.Services;
using Shopping.DataAcceServiceContract.Repositories;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;

namespace Shopping.Bussiness.Implementations
{
    public class SupplierBuss :ISupplierBuss
    {
        private readonly ISupplierRepository repo;

        DomainModel.DTO.Supplier.SupplierAddUpdateModel ToDataAccessModel(BussinessServiceContract.BussinessModel.Supplier.SupplierAddEditViewModel sup)
        {
            DomainModel.DTO.Supplier.SupplierAddUpdateModel r = new DomainModel.DTO.Supplier.SupplierAddUpdateModel
            {
                Grade = sup.Grade
                ,SupplierID = sup.SupplierID
                ,SupplierName = sup.SupplierName
                ,Tel = sup.Tel
            };
            return r;
        }
        public SupplierBuss(ISupplierRepository repo)
        {
            this.repo = repo;
        }
        public OperationResult RegisterSupplier(BussinessServiceContract.BussinessModel.Supplier.SupplierAddEditViewModel sup)
        {
            if (repo.ExistSupplierName(sup.SupplierName))
            {
                return new OperationResult("Register", "Supplier").ToFail("SupplierName Already Exist");
            }

            var s = ToDataAccessModel(sup);
            return repo.Add(s);
        }

       

        public OperationResult UpdateSupplier(SupplierAddEditViewModel sup)
        {
            if (repo.ExistSupplierName(sup.SupplierName,sup.SupplierID))
            {
                return new OperationResult("Update", "Supplier").ToFail("SupplierName Already Exist");

            }

            var s = ToDataAccessModel(sup);
            return repo.Update(s);
        }

        public OperationResult RemoveSupplier(int SupplierID)
        {
            if (repo.hasProduct(SupplierID))
            {
                return new OperationResult("RemoveSupplier", "Supplier").ToFail("Supplier Has Product");

            }
           return repo.Delete(SupplierID);
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public SupplierAddEditViewModel GetSupplier(int SupplierID)
        {
            DomainModel.Models.Supplier s = repo.Get(SupplierID);
            var supvm = new SupplierAddEditViewModel
            {
                SupplierID = s.SupplierID
                ,Grade = s.Grade
                ,SupplierName = s.SupplierName
                ,Tel = s.Tel
            };
            return supvm;

        }

        public List<SupplierListItem> Search(SupplierSearchModel search, out int RecordCount)
        {
            return repo.Search(search, out RecordCount);
        }
    }
}
