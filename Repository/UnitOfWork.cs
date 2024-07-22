using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        private BookStoreContext _context;
        private GenericRepository<Book> _book;
        private GenericRepository<Press> _press;

        public UnitOfWork(BookStoreContext context)
        {
            _context = context;
        }

        public GenericRepository<Book> BookRepository
        {
            get
            {
                if (_book == null)
                {
                    this._book = new GenericRepository<Book>(_context);
                }
                return _book;
            }
        }
        public GenericRepository<Press> PressRepository
        {
            get
            {
                if (this._press == null)
                {
                    this._press = new GenericRepository<Press>(_context);
                }
                return _press;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
