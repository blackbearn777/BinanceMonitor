using BinanceMonitor.Core.Repositories;
using BinanceMonitor.Core.Services;
using BinanceMonitor.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace BinanceMonitor.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {

            Mvx.IoCProvider.RegisterType<ApplicationContext>(() => new ApplicationContext());
            Mvx.IoCProvider.RegisterType<SymbolRepository>(() => new SymbolRepository());
            Mvx.IoCProvider.RegisterSingleton<BinanceApiService>(new BinanceApiService());

            var binanceApiService = Mvx.IoCProvider.Resolve<BinanceApiService>();
            var symbolRepo = Mvx.IoCProvider.Resolve<SymbolRepository>();
            if (symbolRepo.GetAllSymbols().Count == 0)
            {
                symbolRepo.AddSymbols(binanceApiService.GetListOfAllCurrency().Result.symbols);
            }
            RegisterAppStart<MainViewModel>();
        }
    }
}
