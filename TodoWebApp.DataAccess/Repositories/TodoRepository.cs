using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoWebApp.DataAccess.Abstracion;
using TodoWebApp.Domain;

namespace TodoWebApp.DataAccess.Repositories
{
    public class TodoRepository : IRepository<Todo>
    {

        private readonly TodoWebAppDbContext _dbContext;

        public TodoRepository(TodoWebAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Todo> GetAll()
        {
            return _dbContext.Todos.ToList();
        }

        public Todo GetById(int id)
        {
            return _dbContext.Todos.FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Todo entity)
        {
            _dbContext.Todos.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Todo entity)
        {
            var item = GetById(entity.Id);
            if(item != null)
            {
                _dbContext.Todos.Update(entity);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _dbContext.Todos.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
