using App.Shared;
using App4MultiWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4MultiWindow.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)] 
	public partial class SecondPageView : ContentPage, INav, INext
	{
		public SecondPageView ()
		{
			InitializeComponent ();
            //BindingContext = new SecondPageViewModel(Navigation);
		}

        public void Pop()
        {
            Navigation.PopAsync();
        }

        public void Push(INext instance)
        {
            Navigation.PushAsync((ContentPage)instance);
        }
    }
}