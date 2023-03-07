using Security.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Base
{
    public interface IBaseRepository<TModel, TKey, TUpdateModel, TAddModel>
    {
        TModel Get(TKey Id);
        List<TModel> GetAll();
        OperationResult Add(TAddModel model);
        OperationResult Update(TUpdateModel model);
        OperationResult Delete(TKey Id);
    }
}
