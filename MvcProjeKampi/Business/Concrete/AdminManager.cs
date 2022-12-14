using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AboutDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AboutUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Add(admin);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
