﻿using Prism;
using Prism.Ioc;
using CalificarTaxis.Prism.ViewModels;
//using CalificarTaxis.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CalificarTaxis.Prism.Views;
using CalificarTaxis.Common.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CalificarTaxis.Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("TaxiMasterDetailPage/NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGeolocatorService, GeolocatorService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();

            containerRegistry.RegisterForNavigation<TaxiMasterDetailPage, TaxiMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<TaxiHistoryPage, TaxiHistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<GroupPage, GroupPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<ReportPage, ReportPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
