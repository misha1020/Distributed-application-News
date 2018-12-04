using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewsServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class NewsService : INewsService
    {
        public void CreateCategory(string title)
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

        public void CreateCategoryForNews(int idCat, int idNews)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat && c.IdNews == idNews).ToList();
                if (search.Count == 0)
                {
                    CategoryOfNews newSvazka = new CategoryOfNews
                    {
                        IdNews = idNews,
                        IdCategory = idCat
                    };
                    ctx.CategoryOfNews.Add(newSvazka);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая связка 'idNews = " + idNews + " idCategory =  " + idCat + "' добавлена");
                }
                else
                {
                    Console.WriteLine("Такая связка уже существует");
                }
            }
        }

        public void CreateNewWithCat(LibNews news, string[] categoryes)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.News.Where(c => c.Date == news.ReleaseDate.Date && c.Title == news.Title).ToList();
                if (search.Count == 0)
                {
                    News newNews = new News
                    {
                        Title = news.Title,
                        Date = news.ReleaseDate,
                        TextContent = news.TextContent
                    };
                    ctx.News.Add(newNews);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая новость '" + news.Title + "' добавлена");
                    using (var ptx = new NewsEntities())
                    {
                        SelectAllNews();
                        Console.WriteLine("Передана дата " + news.ReleaseDate.Date + " заголовок " + news.Title);
                        var idNew = ptx.News.Where(c => c.Date == news.ReleaseDate.Date && c.Title == news.Title).First().Id_news;
                        int idCateg = -1;
                        foreach (var category in categoryes)
                        {
                            var check = ctx.Category.Where(c => c.CatName == category).ToList();
                            if (check.Count == 0)
                                CreateCategory(category);
                            idCateg = ptx.Category.Where(c => c.CatName == category).FirstOrDefault().IdCategories;
                            CreateCategoryForNews(idCateg, idNew);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такая новость уже существует");
                }
            }
        }

        public void CreateNews(LibNews news)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.News.Where(c => c.Date == news.ReleaseDate.Date && c.Title == news.Title).ToList();
                if (search.Count == 0)
                {
                    News newNews = new News
                    {
                        Title = news.Title,
                        Date = news.ReleaseDate,
                        TextContent = news.TextContent
                    };
                    ctx.News.Add(newNews);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая новость '" + news.Title + "' добавлена");
                }
                else
                {
                    Console.WriteLine("Такая новость уже существует");
                }
            }
        }

        public void DeleteCategory(string nameCat)
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

        public void DeleteCategorysForNews(int idNews)
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

        public void DeleteCategoryForNews(int idCat, int idNews)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat && c.IdNews == idNews).ToList();
                if (search.Count != 0)
                {
                    foreach (var item in search)
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

        public void DeleteCategoryFromAllNews(int idCat)
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

        public void DeleteNews(string title, DateTime date)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.News.Where(c => c.Title == title && c.Date == date).ToList();
                if (search.Count != 0)
                {
                    foreach (var item in search)
                    {
                        DeleteCategorysForNews(item.Id_news);
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

        public List<LibCategory> SelectAllCategory()
        {
            List<LibCategory> list = new List<LibCategory>();
            using (var ctx = new NewsEntities())
            {
                LibCategory temp = new LibCategory();
                var cats = ctx.Category.ToList();
                if (cats.Count != 0)
                {
                    //создание массива класса категории                   
                    foreach (var cat in cats)
                    {   
                        list.Add(new LibCategory() { IdCat = cat.IdCategories, NameCat = cat.CatName });
                        //вывод в класс
                        Console.WriteLine("Название категории: " + cat.CatName);
                    }
                }
            }
            return list;
        }

        public List<LibNews> SelectAllNews()
        {
            List<LibNews> list = new List<LibNews>();
            using (var ctx = new NewsEntities())
            {                
                var news = ctx.News.ToList();
                if (news.Count != 0)
                {
                    //создание массива класса категории                   
                    foreach (var onenew in news)
                    {                        
                        list.Add(new LibNews(){ Title = onenew.Title, TextContent = onenew.TextContent, ReleaseDate = onenew.Date });
                        //вывод в класс
                        Console.WriteLine("Заголовок: " + onenew.Title + " Дата " + onenew.Date + " Содержимое" + onenew.TextContent);
                    }
                }
            }
            return list;
        }

        public List<LibNews> SelectNewsFromCategory(string nameCat)
        {
            List<LibNews> list = new List<LibNews>();
            using (var ctx = new NewsEntities())
            {
                var cat = ctx.Category.Where(c => c.CatName == nameCat).ToList();
                if (cat.Count != 0)
                {
                    var idCat = cat[0].IdCategories;
                    //создание массива классов
                    var newsFromCat = ctx.CategoryOfNews.Where(c => c.IdCategory == idCat).ToList();
                    foreach (var newFromCat in newsFromCat)
                    {
                        var news = ctx.News.Where(c => c.Id_news == newFromCat.IdNews).FirstOrDefault();
                        //вывод в класс
                        list.Add(new LibNews() { Title = news.Title, TextContent = news.TextContent, ReleaseDate = news.Date });
                        Console.WriteLine("Заголовок: " + news.Title + " Дата " + news.Date + " Содержимое" + news.TextContent);
                    }
                }
                else
                {
                    Console.WriteLine("Такой категории не существует существует");
                }

            }
            return list;
        }

        public void Test()
        {
            var a = 1;
        }

        public void CreateNewWithCatAndRest(LibNews news, string[] categoryes, string nameRest)
        {
            using (var ctx = new NewsEntities())
            {
                var search = ctx.News.Where(c => c.Date == news.ReleaseDate.Date && c.Title == news.Title).ToList();
                if (search.Count == 0)
                {
                    int idRest = -1;
                    var rests = ctx.Restorans.Where(c => c.Name == nameRest).ToList();
                    if (rests.Count != 0)
                    {
                        idRest = rests[0].Id;
                    }
                    else
                    {
                        Console.WriteLine("Ресторана не существует");
                    }

                    News newNews = new News
                    {
                        Title = news.Title,
                        Date = news.ReleaseDate,
                        TextContent = news.TextContent
                    };
                    if (idRest != -1)
                        newNews.RefIdRest = idRest;
                    ctx.News.Add(newNews);
                    ctx.SaveChanges();
                    Console.WriteLine("Новая новость '" + news.Title + "' добавлена");

                }
            }
        }

        public List<LibNews> SelectNewsFromRestoran(string nameRest)
        {
            List<LibNews> list = new List<LibNews>();
            using (var ctx = new NewsEntities())
            {
                var rests = ctx.Restorans.Where(c => c.Name == nameRest).ToList();
                if (rests.Count != 0)
                {
                    int idRest = rests[0].Id;                 
                 
                    //создание массива классов
                    var newsWithRests = ctx.News.Where(c => c.RefIdRest == idRest).ToList();
                    if (newsWithRests.Count != 0)
                    {
                        foreach (var newsWithRest in newsWithRests)
                        {
                           
                            //вывод в класс                            
                            list.Add(new LibNews() { Title = newsWithRest.Title, TextContent = newsWithRest.TextContent, ReleaseDate = newsWithRest.Date });
                            Console.WriteLine("Заголовок: " + newsWithRest.Title + " Дата " + newsWithRest.Date + " Содержимое" + newsWithRest.TextContent);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Нет ни одной новости, в которой есть ссылка на этот ресторан");
                    }                    
                }
                else
                {
                    Console.WriteLine("Не существует такого ресторана");
                }

            }
            return list;
        }
    }
}
