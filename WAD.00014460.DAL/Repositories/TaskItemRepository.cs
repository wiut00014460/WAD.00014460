using Microsoft.EntityFrameworkCore;
using WAD._00014460.Data;
using WAD._00014460.Interfaces;
using WAD._00014460.Models;

namespace WAD._00014460.Repositories
{
    public class TaskItemRepository : ITaskRepository
    {
        private readonly AppDBContext _context;

        public TaskItemRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.Include(t => t.Category).ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            return await _context.TaskItems.Include(t => t.Category).SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await _context.SaveChangesAsync();
        }
    }

}
