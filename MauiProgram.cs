﻿using RestEase.HttpClientFactory;
using Shopping_App.RestServices;
using Shopping_App.Services;
using Shopping_App.Services.Abstractions;
using Shopping_App.ViewModels;
using Shopping_App.Views;

namespace Shopping_App;

public static class MauiProgram
{

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UsePrismApp<App>(prism =>
			{
				prism.RegisterTypes(container =>
				{
					container.Register<IShoppingCartItemService, ShoppingCartItemService>();
					container.RegisterForNavigation<ItemView, ItemViewModel>();
                })
				.ConfigureServices(service =>
				{
					service.AddRestEaseClient<IShoppingCartApiService>("http://sampleshopping.azurewebsites.net/ShoppingCart");
				})
				.OnAppStart(navigation => navigation.CreateBuilder().AddNavigationPage().AddSegment<ItemViewModel>().Navigate());
			})
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
