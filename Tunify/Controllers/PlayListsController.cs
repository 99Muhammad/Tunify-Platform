using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Interfaces;

namespace Tunify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        private readonly IPlayList _context;

        public PlayListsController(IPlayList context)
        {
            _context = context;
        }

        // GET: api/PlayLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayList>>> GetPlayList()
        {
            return await _context.GetAllPlayLists();
        }

        // GET: api/PlayLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayList>> GetPlayListByID(int id)
        {
            return await _context.GetPlayListById(id);
        }

        // PUT: api/PlayLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayList(int id, PlayList playList)
        {
            var updatePlayList = await _context.UpdatePlayList(id, playList);
            return Ok(updatePlayList);
        }

        // POST: api/PlayLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayList>> PostPlayList(PlayList playList)
        {
            var newPlayList = await _context.CreatePlayList(playList);
            return Ok(newPlayList);
        }

        // DELETE: api/PlayLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            var deletedPlayList = _context.DeletePlayList(id);
            return Ok(deletedPlayList);
        }

       
    }

    /*
       // GET: api/Employees
        [Route("/employees/GetAllEmployees")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
        {
          return  await _employee.GetAllEmployees();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            
            return await _employee.GetEmployeeById(id); 
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            var updateEmployee = await _employee.UpdateEmployee(id, employee);
            return Ok(updateEmployee);
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var newEmployee =  await _employee.CreateEmployee(employee);
            return Ok(newEmployee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deletedEmployee = _employee.DeleteEmployee(id);
            return Ok(deletedEmployee);
        }

     */
}
