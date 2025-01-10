using Odev.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Services.DbServices
{
    public abstract class BaseServices
    {
        public BaseServices(OdevUnitOfWork unitOfWork)
        { }
    }
}
