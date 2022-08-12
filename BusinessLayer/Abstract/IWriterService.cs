using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        void WriterProfileUpdate(Writer writer);
        List<Writer> GetWiriterByID(int id);
    }
}
