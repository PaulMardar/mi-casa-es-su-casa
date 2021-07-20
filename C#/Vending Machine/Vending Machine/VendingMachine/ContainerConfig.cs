using Autofac;
using iQuest.VendingMachine.Authentication;
using iQuest.VendingMachine.Model.Pay;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.PresentationLayer.Pay;
using iQuest.VendingMachine.Repo;
using iQuest.VendingMachine.UseCases;
using System.Configuration;
using System.Reflection;

namespace iQuest.VendingMachine
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlServerRepository>()
                .As<IProductRepository>()
                .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["sqlServer"].ConnectionString);

            builder.RegisterType<MainView>().As<IMainView>();
            builder.RegisterType<LoginView>().As<ILoginView>();

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().SingleInstance();

            builder.RegisterType<CashPaymentView>().As<ICashPaymentView>();
            builder.RegisterType<CardPaymentView>().As<ICardPaymentView>();

            builder.RegisterType<CashPayment>().As<IPaymentAlgorithm>();
            builder.RegisterType<CardPayment>().As<IPaymentAlgorithm>();

            builder.RegisterType<ShelfView>().As<IShelfView>();

            builder.RegisterType<BuyView>().As<IBuyView>();
            builder.RegisterType<DispenseView>().As<IDispenseView>();

            Assembly paymentAlgorithmAssembly = typeof(IPaymentAlgorithm).Assembly;
            builder.RegisterAssemblyTypes(paymentAlgorithmAssembly).As<IPaymentAlgorithm>();

            Assembly useCasesAssembly = typeof(IUseCase).Assembly;
            builder.RegisterAssemblyTypes(useCasesAssembly).As<IUseCase>();

            builder.RegisterType<PaymentUseCase>().As<IPaymentUseCase>();

            builder.RegisterType<VendingMachineApplication>().As<IVendingMachineApplication>();

            return builder.Build();
        }

    }
}
