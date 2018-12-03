using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFForBD
{
    class WCFForBD
    {
        
        public static void CreateNews(string title, DateTime date, string textContent)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.News.Where(c => c.Date == date && c.Title == title).ToList();
                if (search.Count == 0)
                {
                    News newNews = new News
                    {
                        Title = title,
                        Date = date,
                        TextContent = textContent
                    };
                    ctx.News.Add(newNews);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая новость '" + title + "' добавлена");
                }
                else
                {
                    Console.WriteLine("Такая новость уже существует");
                }
            }
        }

        public static void CreateCategory(string title)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.Category.Where(c => c.CatName == title).ToList();
                if (search.Count == 0)
                {
                    Category newCat = new Category
                    {
                        CatName = title
                    };
                    ctx.Category.Add(newCat);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая категория '" + title + "' добавлена");
                }
                else
                {
                    Console.WriteLine("Такая новость уже существует");
                }
            }
        }

        public static void CreateCategoryForNews(int idCat, int idNews)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat && c.IdNews == idNews).ToList();
                if(search.Count == 0)
                {
                    CategoryOfNews newSvazka = new CategoryOfNews
                    {
                        IdNews = idNews,
                        IdCategory = idCat
                    };
                    ctx.CategoryOfNews.Add(newSvazka);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая связка 'idNews = " + idNews +" idCategory =  "+ idCat + "' добавлена");
                }
                else
                {
                    Console.WriteLine("Такая связка уже существует");
                }
            }
        }

        public static void DeleteCategoryForNews(int idCat, int idNews)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat && c.IdNews == idNews).ToList();
                if (search.Count != 0)
                {
                    foreach(var item in search)
                    {
                        ctx.CategoryOfNews.Remove(item);
                        ctx.SaveChanges();
                        Console.WriteLine("Связка удалена");
                    }                    
                }
                else
                {
                    Console.WriteLine("Такой связки не существует");
                }
            }
        }

        public static void DeleteCategoryForNews(int idNews)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.CategoryOfNews.Where(c => c.IdNews == idNews).ToList();
                if (search.Count != 0)
                {
                    foreach (var item in search)
                    {
                        ctx.CategoryOfNews.Remove(item);
                        ctx.SaveChanges();
                        //Console.WriteLine("Связка удалена");
                    }
                }
                else
                {
                    //Console.WriteLine("Такой связки не существует");
                }
            }
        }
        public static void DeleteCategoryFromAllNews(int idCat)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat).ToList();
                if (search.Count != 0)
                {
                    foreach (var item in search)
                    {
                        ctx.CategoryOfNews.Remove(item);
                        ctx.SaveChanges();
                        //Console.WriteLine("Связка удалена");
                    }
                }
                else
                {
                    //Console.WriteLine("Такой связки не существует");
                }
            }
        }

        public static void DeleteCategory(string nameCat)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.Category.Where(c => c.CatName == nameCat).ToList();
                if (search.Count != 0)
                {
                    foreach (var item in search)
                    {
                        DeleteCategoryFromAllNews(item.IdCategories);
                        ctx.Category.Remove(item);
                        ctx.SaveChanges();
                        Console.WriteLine("Категория удалена");
                    }
                }
                else
                {
                    Console.WriteLine("Такой категории не существует");
                }
            }
        }

        public static void DeleteNews(string title, DateTime date)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.News.Where(c => c.Title == title && c.Date == date).ToList();
                if (search.Count != 0)
                {                    
                    foreach (var item in search)
                    {
                        DeleteCategoryForNews(item.Id_news);
                        ctx.News.Remove(item);
                        ctx.SaveChanges();
                        Console.WriteLine("Новость удалена");
                    }
                }
                else
                {
                    Console.WriteLine("Такой новости не существует");
                }
            }
        }

        public static void SelectNewsFromCategory(string nameCat)
        {
            using (var ctx = new NewsEntities())
            {
                var cat = ctx.Category.Where(c => c.CatName == nameCat).ToList();
                if (cat.Count != 0)
                {
                    var idCat = cat[0].IdCategories;
                    //создание массива классов
                    var newsFromCat = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat).ToList();
                    foreach(var newFromCat in newsFromCat)
                    {
                        var news = ctx.News.Where(c => c.Id_news == newFromCat.IdNews).FirstOrDefault();
                        //вывод в класс
                        Console.WriteLine("Заголовок: " + news.Title + " Дата " + news.Date + " Содержимое" + news.TextContent);
                    }
                }
                else
                {
                    Console.WriteLine("Такой категории не существует существует");
                }

            }
        }

        public static void SelectAllNews()
        {
            using (var ctx = new NewsEntities())
            {
                var news = ctx.News.ToList();
                if (news.Count != 0)
                {
                    //создание массива класса категории                   
                    foreach (var onenew in news)
                    {
                        //вывод в класс
                        Console.WriteLine("Заголовок: " + onenew.Title + " Дата " + onenew.Date + " Содержимое" + onenew.TextContent);
                    }
                }
            }
        }

        public static void SelectAllCategory()
        {
            using (var ctx = new NewsEntities())
            {
                var cats = ctx.Category.ToList();
                if (cats.Count != 0)
                {                    
                    //создание массива класса категории                   
                    foreach (var cat in cats)
                    {                       
                        //вывод в класс
                        Console.WriteLine("Название категории: " + cat.CatName);
                    }
                }
            }
        }


        public static void Main(string[] args)
        {
            CreateNews("Your dig is very big", new DateTime(2018, 10, 25), "Fat mam");
            CreateNews("Your dig is very Bbig", new DateTime(2018, 10, 25), "Fat mam");
            CreateNews("Your dig is very bigG", new DateTime(2018, 10, 25), "Fat mam");
            CreateNews("Your dig is very Bbig", new DateTime(2018, 11, 25), "Fat mam");
            CreateNews("Your dig is very bigG", new DateTime(2018, 10, 15), "Fat mam");
            CreateCategory("Roflan");
            CreateCategory("Roflan1");
            CreateCategory("Roflan2");
            CreateCategory("Roflan3");
            CreateCategoryForNews(0, 1);
            CreateCategoryForNews(0, 2);
            CreateCategoryForNews(0, 3);
            CreateCategoryForNews(0, 4);
            //CreateCategoryForNews(1, 5);
            //DeleteCategoryForNews(0, 0);
            DeleteCategory("Roflan1");
            //DeleteNews("Your dig is very big", new DateTime(2018, 10, 25));
            //SelectNewsFromCategory("Roflan");
            //SelectAllCategory();
            SelectNewsFromCategory("Roflan");
            Console.WriteLine("-----------------------------------");
            SelectAllNews();
        }
    }
}
