using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewsServiceLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface INewsService
    {
        [OperationContract]
        void CreateNews(LibNews news);

        [OperationContract]
        void CreateCategory(string title);

        [OperationContract]
        void CreateCategoryForNews(int idCat, int idNews);

        [OperationContract]
        void DeleteCategoryForNews(int idCat, int idNews);

        [OperationContract]
        void DeleteCategorysForNews(int idNews);

        [OperationContract]
        void DeleteCategoryFromAllNews(int idCat);

        [OperationContract]
         void DeleteCategory(string nameCat);

        [OperationContract]
        void DeleteNews(string title, DateTime date);

        [OperationContract]
        List<LibNews> SelectNewsFromCategory(string nameCat);

        [OperationContract]
        List<LibNews> SelectAllNews();

        [OperationContract]
        List<LibCategory> SelectAllCategory();

        [OperationContract]
       void Test();
        [OperationContract]
        void CreateNewWithCat(LibNews news, string[] categoryes);

        //[OperationContract]
        //News GetDataUsingDataContract(News composite);

        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "NewsServiceLibrary.ContractType".
    [DataContract]
    public class LibNews
    {

        string title;
        DateTime releaseDate;
        string textContent;
        int refIdRest = -1;
        //List<LibCategory> categoties = new List<LibCategory>();

        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [DataMember]
        public string TextContent
        {
            get { return textContent; }
            set { textContent = value; }
        }

        [DataMember]
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        //[DataMember]
        //public List<LibCategory> Categoties
        //{
        //    get { return categoties; }
        //    set { categoties = value; }
        //}

        [DataMember]
        public int RefIdRest
        {
            get { return refIdRest; }
            set { refIdRest = value; }
        }
    }

    [DataContract]
    public class LibCategory
    {
        int idCat;
        string nameCat;

        [DataMember]
        public int IdCat
        {
            get { return idCat; }
            set { idCat = value; }
        }

        [DataMember]
        public string NameCat
        {
            get { return nameCat; }
            set { nameCat = value; }
        }
    }
}
