using System.Linq.Expressions;
using WAD._00014460.Models;

namespace WAD._00014460.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem> GetByIdAsync(int id);
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem entity);
        Task UpdateAsync(TaskItem entity);
        Task DeleteAsync(int id);
    }
}
