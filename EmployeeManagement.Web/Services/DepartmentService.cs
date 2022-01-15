﻿using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await httpClient.GetJsonAsync<Department>($"api/departments/{id}");
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetJsonAsync<Department[]>("api/departments");
        }
    }
}
