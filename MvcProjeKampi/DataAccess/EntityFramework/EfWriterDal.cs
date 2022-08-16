using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;
using DataAccess.Abstract;


namespace DataAccess.EntityFramework
{
    public class EfWriterDal:GenericRepository<Writer>,IWriterDal
    {
    }
}
