using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoshka.Model
{
    public class UnitOfWork : IDisposable
    {
        private ToDoContext db = new ToDoContext();
        private ToDoRepository<Users> usersRepository;
        private ToDoRepository<Tasks> tasksRepository;
        private ToDoRepository<Subtasks> subtasksRepository;
        private ToDoRepository<Attachments> attachRepository;

        public ToDoRepository<Users> Users
        {
            get
            {
                if (usersRepository == null)
                    usersRepository = new ToDoRepository<Users>(db);
                return usersRepository;
            }
        }

        public ToDoRepository<Tasks> Tasks
        {
            get
            {
                if (tasksRepository == null)
                    tasksRepository = new ToDoRepository<Tasks>(db);
                return tasksRepository;
            }
        }

        public ToDoRepository<Subtasks> Subtasks
        {
            get
            {
                if (subtasksRepository == null)
                    subtasksRepository = new ToDoRepository<Subtasks>(db);
                return subtasksRepository;
            }
        }

        public ToDoRepository<Attachments> Attachments
        {
            get
            {
                if (attachRepository == null)
                    attachRepository = new ToDoRepository<Attachments>(db);
                return attachRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
