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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void CategoryDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void CategoryUpdate(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void ContactAdd(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(p=>p.ContactID==id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
