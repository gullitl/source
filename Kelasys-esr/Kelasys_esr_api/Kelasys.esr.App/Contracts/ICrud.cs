using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kelasys.esr.App.Contracts {
    public interface ICrud<TEntity> {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<bool> Delete(int id);
        Task<TEntity> Create(TEntity tEntity);
        Task<bool> Update(TEntity tEntity);
    }
}
