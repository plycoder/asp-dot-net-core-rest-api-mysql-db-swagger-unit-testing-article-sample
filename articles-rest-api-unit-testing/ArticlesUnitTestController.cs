using ArticleSampleAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticleSampleAPI.Models;
using articles_rest_api_unit_testing.MockData;
using ArticleSampleAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ArticleSampleAPI.Services;

namespace articles_rest_api_unit_testing
{
    public class ArticlesUnitTestController
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            /// Arrange
            var articleService = new Mock<IArticleService>();
            articleService.Setup(_ => _.GetAllAsync()).ReturnsAsync(ArticleMockData.GetArticles());
            var sut = new ArticlesController(articleService.Object);

            /// Act
            var result = (OkObjectResult)await sut.GetAllAsync();


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            var articleService = new Mock<IArticleService>();
            articleService.Setup(_ => _.GetAllAsync()).ReturnsAsync(ArticleMockData.GetEmptyArticles());
            var sut = new ArticlesController(articleService.Object);

            /// Act
            var result = (NoContentResult)await sut.GetAllAsync();


            /// Assert
            result.StatusCode.Should().Be(204);
            articleService.Verify(_ => _.GetAllAsync(), Times.Exactly(1));
        }

        [Fact]
        public async Task SaveAsync_ShouldCall_IArticleService_SaveAsync_AtleastOnce()
        {
            /// Arrange
            var articleService = new Mock<IArticleService>();
            var newArticle = ArticleMockData.NewArticles();
            var sut = new ArticlesController(articleService.Object);

            /// Act
            var result = await sut.SaveAsync(newArticle);

            /// Assert
            articleService.Verify(_ => _.SaveAsync(newArticle), Times.Exactly(1));
        }

    }
}