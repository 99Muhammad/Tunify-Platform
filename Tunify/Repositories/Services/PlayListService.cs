using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Repositories.Services
{
    public class PlayListService : IPlayList
    {

        private readonly TunifyDbContext _context;

        public PlayListService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<PlayList> CreatePlayList(PlayList employee)
        {
            _context.PlayList.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task DeletePlayList(int id)
        {
            var getEmployee = await GetPlayListById(id);
            _context.Entry(getEmployee).State = EntityState.Deleted;
            //_context.employees.Remove(getEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlayList>> GetAllPlayLists()
        {
            var allEmployees = await _context.PlayList.ToListAsync();
            return allEmployees;
        }

        public async Task<PlayList> GetPlayListById(int employeeId)
        {
            //var emplyee = _context.employees.Where(x => x.Equals(employeeId));
            var employee = await _context.PlayList.FindAsync(employeeId);
            return employee;
        }

        public async Task<PlayList> UpdatePlayList(int id, PlayList employee)
        {
            //_context.Entry(employee).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            var exsitingEmployee = await _context.PlayList.FindAsync(id);
            exsitingEmployee = employee;
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
