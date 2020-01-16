using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoAlbum
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
		public App()
		{
			Languages.Add(new CultureInfo("en-US"));
			Languages.Add(new CultureInfo("ru-RU"));
			Languages.Add(new CultureInfo("uk-UA"));
		}

		public static List<CultureInfo> Languages { get; private set; } = new List<CultureInfo>();
		public static CultureInfo Language
		{
			get => System.Threading.Thread.CurrentThread.CurrentUICulture;
			set
			{
				if (value == null) throw new ArgumentNullException("value");
				if (value == System.Threading.Thread.CurrentThread.CurrentUICulture) return;

				// Change app language.
				System.Threading.Thread.CurrentThread.CurrentUICulture = value;

				// Create ResourceDictionary for new culture
				ResourceDictionary dict = new ResourceDictionary();

				switch (value.Name)
				{
					case "ru-RU":
						dict.Source = new Uri($"Localization/Lang.{value.Name}.xaml", UriKind.Relative);
						break;
					case "uk-UA":
						dict.Source = new Uri($"Localization/Lang.{value.Name}.xaml", UriKind.Relative);
						break;
					default:
						dict.Source = new Uri("Localization/Lang.xaml", UriKind.Relative);
						break;
				}

				// Remove old ResourceDictionary and add new.
				ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
											  where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
											  select d).FirstOrDefault();
				if (oldDict != null)
				{
					int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
					Application.Current.Resources.MergedDictionaries.Remove(oldDict);
					Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
				}
				else
				{
					Application.Current.Resources.MergedDictionaries.Add(dict);
				}
			}
		}
	}
}
