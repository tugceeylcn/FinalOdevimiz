using Odev.DAL.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.UnitOfWork
{
    public class OdevUnitOfWork : IDisposable
    {
        private readonly ApplicationContext _context;

        public OdevUnitOfWork()
        {
            _context = new ApplicationContext();
        }

        public ApplicationContext GetContext()
        {
            return _context;
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                var innerExceptionMessage = ex.Message;
                while (innerException != null)
                {
                    innerExceptionMessage = innerException.Message;
                    innerException = innerException.InnerException;
                }

                return 0;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
