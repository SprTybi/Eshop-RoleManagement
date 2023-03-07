using System.Collections.Generic;
using Shopping.DomainModel.BaseModel;

namespace Shopping.DataAcceServiceContract.Base
{
  public interface IBaseRepository<TModel,TKey,TUpdateModel,TAddModel>
  {
      TModel Get(TKey id);
      List<TModel> GetAll();
      OperationResult Delete(TKey id);
      OperationResult Update(TUpdateModel model);
      OperationResult Add(TAddModel model);


  }
}
