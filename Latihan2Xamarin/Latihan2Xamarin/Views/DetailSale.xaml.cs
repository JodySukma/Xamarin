using Latihan2Xamarin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Latihan2Xamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailSale : ContentPage
	{
		public DetailSale (Sale sale)
		{
			InitializeComponent ();
            TitleLabel.Text = sale.Title;
            DescriptionLabel.Text = sale.Description;
            OrderDateLabel.Text = "Rp." + sale.Amount.ToString("N0", new CultureInfo("id-id"));
		}
	}
}