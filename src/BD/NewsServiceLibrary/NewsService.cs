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

        public void CreateNewWithCat(LibNews news,string[] categoryes)
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
                        temp.IdCat = cat.IdCategories;
                        temp.NameCat = cat.CatName;
                        list.Add(temp);
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
                LibNews temp = new LibNews();
                var news = ctx.News.ToList();
                if (news.Count != 0)
                {
                    //создание массива класса категории                   
                    foreach (var onenew in news)
                    {
                        temp.Title = onenew.Title;
                        temp.TextContent = onenew.TextContent;
                        temp.ReleaseDate = onenew.Date;
                        list.Add(temp);
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
                LibNews temp = new LibNews();
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
                        temp.Title = news.Title;
                        temp.TextContent = news.TextContent;
                        temp.ReleaseDate = news.Date;
                        list.Add(temp);
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
    }
}
