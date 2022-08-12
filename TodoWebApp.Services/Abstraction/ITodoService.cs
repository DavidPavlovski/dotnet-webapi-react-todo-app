using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApp.Domain;

namespace TodoWebApp.Services.Abstraction
{
    public interface ITodoService
    {
        List<Todo> GetAll();
        Todo GetById(int id);
        int Create(Todo model);
        void Edit(int id, Todo model);
        void Delete(int id);
    }
}
