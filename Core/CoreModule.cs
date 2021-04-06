using Autofac;
using Core.Interfaces.UseCases.BookUseCases;
using Core.Interfaces.UseCases.UserUseCases;
using Core.UseCases.BookUseCases;
using Core.UseCases.UserUseCases;

namespace Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // User
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();

            // Book
            builder.RegisterType<CreateBookUseCase>().As<ICreateBookUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateBookUseCase>().As<IUpdateBookUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllBooksUseCase>().As<IGetAllBooksUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetBookByIdUseCase>().As<IGetBookByIdUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteBookUseCase>().As<IDeleteBookUseCase>().InstancePerLifetimeScope();

            //Subscription
            builder.RegisterType<CreateBookSubscriptionUseCase>().As<ICreateBookSubscriptionUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RemoveBookSubscriptionUseCase>().As<IRemoveBookSubscriptionUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<GetBookSubscriptionsUseCase>().As<IGetBookSubscriptionsUseCase>().InstancePerLifetimeScope();

            // Repositories


        }
    }
}
