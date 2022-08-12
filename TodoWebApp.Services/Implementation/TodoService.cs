using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApp.DataAccess.Abstracion;
using TodoWebApp.Domain;
using TodoWebApp.Services.Abstraction;

namespace TodoWebApp.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<Todo> _todoRepository;
        public TodoService(IRepository<Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<Todo> GetAll()
        {
            return _todoRepository.GetAll();
        }

        public Todo GetById(int id)
        {
            var item = _todoRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Item with Id: {id} does not exist");
            }
            return item;
        }

        public int Create(Todo model)
        {
            if (String.IsNullOrEmpty(model.Text))
            {
                throw new Exception("Text field cannot be empty");
            }
            Todo newTodo = new Todo(model.Text);
            _todoRepository.Insert(model);
            return model.Id;
        }

        public void Edit(int id, Todo model)
        {
            if (String.IsNullOrEmpty(model.Text))
            {
                throw new Exception("Text field cannot be empty");
            }
            Todo todo = _todoRepository.GetById(id);
            if (todo == null)
            {
                throw new Exception($"Item with Id: {id} does not exist");
            }
            todo.Update(model);
            _todoRepository.Update(todo);
        }
        public void Delete(int id)
        {
            Todo item = _todoRepository.GetById(id);
            if (item == null)
            {
                throw new Exception($"Item with id: {id} does not exist");
            }
            _todoRepository.DeleteById(id);
        }

    }
}
