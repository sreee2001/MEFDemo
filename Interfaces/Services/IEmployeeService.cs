
using Interfaces.Entities;
using System.Collections.Generic;

namespace Interfaces.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets the employee by ID.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <returns>The employee entity.</returns>
        IBaseEntity GetEmployeeById(int id);
        /// <summary>
        /// Gets all employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        IEnumerable<IBaseEntity> GetAllEmployees();
        /// <summary>
        /// Adds a new employee.
        /// </summary>
        /// <param name="employee">The employee entity to add.</param>
        void AddEmployee(int Id, string Name);
        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="employee">The employee entity to update.</param>
        void UpdateEmployee(int Id, string Name);
        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        /// <param name="id">The employee ID to delete.</param>
        void DeleteEmployee(int id);
    }
}
