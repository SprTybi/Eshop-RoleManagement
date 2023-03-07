using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.BussinessServiceContract.BussinessModel.Supplier;
using Shopping.DomainModel.BaseModel;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;

namespace Shopping.BussinessServiceContract.Services
{
    public interface ISupplierBuss
    {
        OperationResult RegisterSupplier(SupplierAddEditViewModel sup);
        OperationResult UpdateSupplier(SupplierAddEditViewModel sup);
        OperationResult RemoveSupplier(int SupplierID);
        List<Supplier> GetAll();
        SupplierAddEditViewModel GetSupplier(int SupplierID);
        List<SupplierListItem> Search(SupplierSearchModel search,out int RecordCount);


    }
}
