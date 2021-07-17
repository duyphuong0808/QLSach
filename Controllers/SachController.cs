using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLSach.Controllers
{
    public class SachController : ApiController
    {
        [HttpGet]
        public List<DBSach> GetSachists()
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.DBSaches.ToList();
        }

        [HttpGet]
        public DBSach GetSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.DBSaches.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public bool InsertNewSach(string Title, string Content, string AuthorName, int Price)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                DBSach sach = new DBSach();
                sach.Title = Title;
                sach.Content = Content;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                db.DBSaches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpPut]
        public bool UpdateSach(int Id, string Title, string Content, string AuthorName, int Price)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                //lấy food tồn tại ra
                DBSach sach = db.DBSaches.FirstOrDefault(x => x.Id == Id);
                if (sach == null) return false;//không tồn tại false
                sach.Title = Title;
                sach.Content = Content;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                db.SubmitChanges();//xác nhận chỉnh sửa
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete]
        public bool DeleteFood(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            //lấy food tồn tại ra
            DBSach sach = db.DBSaches.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.DBSaches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
}
