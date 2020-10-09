using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kelasys.esr.contrats {
    public interface ICrud<T> {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<bool> Delete(int id);
        Task<T> Create(T t);
        Task<bool> Update(T t);
    }
}
