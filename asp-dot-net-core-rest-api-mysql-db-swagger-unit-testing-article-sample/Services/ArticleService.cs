using ArticleSampleAPI.Data;
using ArticleSampleAPI.Models;

namespace ArticleSampleAPI.Services
{
    public class ArticleService : IArticleService
    {

        public AppDb Db { get; }
        public ArticleService(AppDb db)
        {
            Db = db;
        }

        public async Task<List<Articles>> GetAllAsync()
        {
            await Db.Connection.OpenAsync();
            var query = new ArticlesQuery(Db);
            var result = await query.GetAllAsync();
            return result;

        }

        public async Task SaveAsync(Articles newArticle)
        {
            await Db.Connection.OpenAsync();
            newArticle.Db = Db;
            await newArticle.InsertAsync();
        }

        public async Task PutOne(Articles newArticle)
        {
            await newArticle.UpdateAsync();
        }

        public async Task<Articles> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ArticlesQuery(Db);
            var result = await query.FindOneAsync(id);
            return result;
        }

        public async Task DeleteOne(Articles article)
        {
            await article.DeleteAsync();
        }
    }
}
