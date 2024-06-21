using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySlipManagement.DAL.DapperServices.Interfaces
{
    public interface IDapperServices<T>
    {
        Task<IEnumerable<T>> ReadAllAsync(T entity);
        Task<T> ReadGetByIdAsync(T entity);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> ValidateAsync(T entity);
    }
}
