using ArticleSampleAPI.Models;

namespace ArticleSampleAPI.Services
{
    public interface IArticleService
    {
        Task<List<Articles>> GetAllAsync();
        Task SaveAsync(Articles newArticle);
        Task<Articles> GetOne(int id);
        Task PutOne(Articles newArticle);
        Task DeleteOne(Articles article);
    }
}
