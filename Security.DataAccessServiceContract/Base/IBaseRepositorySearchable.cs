using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Base
{

   public interface IBaseRepositorySearchable <TModel,TKEY,TSearchModel,TListItem,TUpdateModel,TAddModel>:IBaseRepository<TModel,TKEY, TUpdateModel, TAddModel>
   {
       List<TListItem> Search(TSearchModel sm, out int RecordCount);
   }
}
