using DataAccess.Concrete.Repositories;
using Entity.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.EntityFramework
{
    public class EfImageFileDal:GenericRepository<ImageFile>,IImageFileDal
    {
    }
}
