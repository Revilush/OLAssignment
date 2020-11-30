using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLAssignment.BizRepository
{
    public interface IBizRepository<TEntity, in TPk> where TEntity : class
    {
        List<TEntity> GetData();
        TEntity GetData(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        bool Delete(TPk id);
    }

}