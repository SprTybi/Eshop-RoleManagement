using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.DataAcceServiceContract.Base;
using Shopping.DomainModel.DTO.Supplier;
using Shopping.DomainModel.Models;

namespace Shopping.DataAcceServiceContract.Repositories
{
    public interface ISupplierRepository:IBaseRespositorySearchable<Supplier,int,SupplierSearchModel,SupplierListItem,SupplierAddUpdateModel,SupplierAddUpdateModel>
    {
        bool hasProduct(int SupplierID);
        bool ExistSupplierName(string SupplierName);
        bool ExistSupplierName(string SupplierName,int SupplierID);

    }
}
