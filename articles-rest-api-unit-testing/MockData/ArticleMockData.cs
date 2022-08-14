using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticleSampleAPI.Data;
using ArticleSampleAPI.Models;

namespace articles_rest_api_unit_testing.MockData
{
    public class ArticleMockData
    {
        public static List<Articles> GetArticles()
        {
            return new List<Articles>{
             new Articles{
                 Id = 1,
                 Name = "Need To Go Shopping",
                 Authors = "Muhammand Rahman, MD Abd Ar Rahman,..."
             },
             new Articles{
                 Id = 2,
                 Name = "Cook Food",
                 Authors =  "Muhammand Rahman, MD Abd Ar Rahman, Test 2,..."
             },
             new Articles{
                 Id = 3,
                 Name = "Play Games",
                 Authors =  "Muhammand Rahman, MD Abd Ar Rahman, Test 3,..."
             }
         };
        }

        public static List<Articles> GetEmptyArticles()
        {
            return new List<Articles>();
        }

        public static Articles NewArticles()
        {
            return new Articles
            {
                Id = 0,
                Name = "wash cloths",
                Authors = "Muhammand Rahman, MD Abd Ar Rahman, Test 4,..."
            };
        }
    }
}