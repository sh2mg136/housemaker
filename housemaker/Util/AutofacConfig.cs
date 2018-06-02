using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using System.Web.Mvc;

public class AutofacConfig
{
    public static void ConfigureContainer()
    {

        // получаем экземпляр контейнера
        var builder = new ContainerBuilder();

        // регистрируем контроллер в текущей сборке
        builder.RegisterControllers(typeof(housemaker.MvcApplication).Assembly);

        // регистрируем споставление типов
        builder.RegisterType<Repository.BookRepository>().As<Repository.IRepository>();

        /*
        builder.RegisterType<Repository.BookRepository>()
            .As<Repository.IRepository>()
            .WithProperty("Context", new Repository.BookContext());
            */

        // создаем новый контейнер с теми зависимостями, которые определены выше
        var container = builder.Build();

        // установка сопоставителя зависимостей
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }

}