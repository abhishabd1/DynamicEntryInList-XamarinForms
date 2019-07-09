using Newtonsoft.Json;
using NICHandsOn.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NICHandsOn.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        EntryViewModel obj = new EntryViewModel();
        public ObservableCollection<AddRecrod> ListAdd = new ObservableCollection<AddRecrod>();
       


           
        public DetailPage(EntryViewModel obj)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

           ListAdd = obj.EntryAdd;
           

            lblemid.Text = Preferences.Get("EMP_ID", "ID");
            lblname.Text = Preferences.Get("EMP_NAME", "NAME");
            lbldepart.Text = Preferences.Get("EMP_DEPAT", "DEPARTMENT");
            
                ExpeseList.ItemsSource = ListAdd;
           
            
        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.HomePage());
        }

        
        
    }
}