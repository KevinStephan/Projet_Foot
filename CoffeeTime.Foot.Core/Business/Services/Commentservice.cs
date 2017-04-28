using CoffeeTime.Foot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Foot.Core.Business.Services
{
    class Commentservice: BaseService
    {
        public Comment GetById(int Id)
        {
            return DataModel.Comments.Where(o => o.Id == Id).FirstOrDefault();
        }

        public List<Comment> GetAll()
        {
            List<Comment> listComments = (from o in DataModel.Comments select o).ToList();
            return listComments;
        }

        public Comment Create(string text, int UserId, int ArticleId)
        {
            Comment comment = new Comment()
            {
                Text = text,
                UserId = UserId,
                ArticleId = ArticleId,
                Date = DateTime.Now,
            };
            DataModel.Comments.Add(comment);
            DataModel.SaveChanges();
            return comment;
        }

        public Comment Update(int id, string text, int UserId, int ArticleId)
        {
            Comment comment = GetById(id);
            comment.Text = text;
            comment.UserId = UserId;
            comment.ArticleId = ArticleId;
            try
            {
                DataModel.SaveChanges();
                return comment;
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            Comment comment = GetById(id);
            DataModel.Comments.Remove(comment);
            DataModel.SaveChanges();
        }
    }
}
