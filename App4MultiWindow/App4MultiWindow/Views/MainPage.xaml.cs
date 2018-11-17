using App4MultiWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App.Shared;
using App4MultiWindow.Views;

namespace App4MultiWindow
{
    public partial class MainPage : ContentPage, INav
    {
        public MainPage()
        {
            InitializeComponent();
            AppContainer.Instance.Register<INav>(this);
            AppContainer.Instance.Register<INext>(new SecondPageView());
            //BindingContext = new MainPageViewModel(Navigation);
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
