using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterService : IWriterService
    {
        IWriterDal _writerDal;

        public WriterService(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetWiriterByID(int id)
        {
            return _writerDal.GetListAll(x=>x.ID==id);
        }

        public void TDelete(Writer t)
        {
            _writerDal.Delete(t);
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> TGetList()
        {
            return _writerDal.GetList();
        }

        public void TInsert(Writer t)
        {
            _writerDal.Add(t);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }

        public void WriterProfileUpdate(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
