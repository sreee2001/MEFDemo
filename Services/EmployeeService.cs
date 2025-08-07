using Interfaces.Entities;
using Interfaces.Services;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Services
{
    public abstract class EmployeeService : IEmployeeService
    {
        List<IBaseEntity> employees = new List<IBaseEntity>();


        public void AddEmployee(int Id, string Name)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("Employee ID must be greater than zero.", nameof(Id));
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Employee name cannot be null or empty.", nameof(Name));
            }

            // Check if an employee with the same ID already exists
            foreach (var employee in employees)
            {
                if (((IHaveId)employee).Id == Id)
                {
                    return;
                }
            }

            employees.Add(new Entity 
            {
                Id = Id,
                Name = Name
            });
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            else
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
        }

        public IEnumerable<IBaseEntity> GetAllEmployees()
        {
            return employees;
        }

        public IBaseEntity GetEmployeeById(int id)
        {
            foreach (var employee in employees)
            {
                if (((IHaveId)employee).Id == id)
                {
                    return employee;
                }
            }
            throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }

        public void UpdateEmployee(int Id, string Name)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (((IHaveId)employees[i]).Id == Id)
                {
                    employees[i].Name = Name;
                    return;
                }
            }
            throw new KeyNotFoundException($"Employee with ID {Id} not found.");
        }
    }
}
