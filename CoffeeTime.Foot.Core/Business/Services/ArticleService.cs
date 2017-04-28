using CoffeeTime.Foot.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTime.Foot.Core.Business.Services
{
    public class ArticleService : BaseService
    {
        public Article GetById(int Id)
        {
            return DataModel.Articles.Where(o => o.Id == Id).FirstOrDefault();
        }

        public List<Article> GetAll()
        {
            List<Article> listArticles = (from o in DataModel.Articles select o).ToList();
            return listArticles;
        }

        public Article Create(string title, string text, int userId)
        {
            Article article = new Article()
            {
                Title = title,
                Text = text,
                CreationDate = DateTime.Now,
                UserId = userId
            };
            DataModel.Articles.Add(article);
            DataModel.SaveChanges();
            return article;
        }

        public Article Update(int id, string title, string text)
        {
            Article article = GetById(id);
            article.Title = title;
            article.Text = text;
            try
            {
                DataModel.SaveChanges();
                return article;
            }
            catch (InvalidOperationException ex)
            {
                //log.ErrorFormat("Error while Updating consommable category : {0}", ex.Message);
                return null;
            }
        }

        public void Delete(int id)
        {
            //if (log.IsDebugEnabled)
            //{
            //    log.Debug("Deleting a consommable category.");
            //}
            Article article = GetById(id);
            DataModel.Articles.Remove(article);
            DataModel.SaveChanges();
        }
    }
}
