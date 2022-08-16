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
    public class ContentManager : IContentService
    {

        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        
        public void ContentAdd(Content content)
        {
            _contentDal.Add(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(p=>p.ContentID==id);
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(p=>p.HeadingID==id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(p => p.WriterID == id);
        }
    }
}
