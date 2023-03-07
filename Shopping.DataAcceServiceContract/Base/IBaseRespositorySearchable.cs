using System.Collections.Generic;

namespace Shopping.DataAcceServiceContract.Base
{
   public interface IBaseRespositorySearchable <TModel,TKEY,TSearchModel,TListItem,TUpdateModel,TAddModel>:IBaseRepository<TModel,TKEY, TUpdateModel, TAddModel>
   {
       List<TListItem> Search(TSearchModel sm, out int RecordCount);
   }
}
