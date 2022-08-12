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
    public class NotificationService : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationService(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void TDelete(Notification t)
        {
            _notificationDal.Delete(t);
        }

        public Notification TGetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> TGetList()
        {
            return _notificationDal.GetList();
        }

        public void TInsert(Notification t)
        {
            _notificationDal.Add(t);
        }

        public void TUpdate(Notification t)
        {
            _notificationDal.Update(t);
        }
    }
}
