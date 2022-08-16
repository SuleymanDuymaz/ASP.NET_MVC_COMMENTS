using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingdal = headingDal;
        }
        public Heading GetById(int id)
        {
            return _headingdal.Get(p=>p.HeadingID==id);
        }
        

        public List<Heading> GetList()
        {   
            return _headingdal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingdal.List(p=>p.WriterID==id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingdal.Add(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            
            _headingdal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }

        

       

       
    }
}
