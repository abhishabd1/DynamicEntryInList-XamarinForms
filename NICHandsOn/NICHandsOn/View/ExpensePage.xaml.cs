
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
    public partial class ExpensePage : ContentPage
    {
     //   public ObservableCollection<AddRecrod> ListAdd = new ObservableCollection<AddRecrod>();
        EntryViewModel evm;
        int i = 0;
        string value = "";


        string ID;
        string NAME;
        string DEPARTMENT;

        
        public ExpensePage(Employee e)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            evm = new EntryViewModel();
            ID = e.EmployeeId;
            NAME = e.Name;
            DEPARTMENT = e.Department;
          //  ListAdd = evm.EntryAdd;

        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            i++;
            AddRecrod obj1 = new AddRecrod();
            obj1.ID = i;
            obj1.TextValue = value;
            evm.EntryAdd.Add(obj1);
            expense.ItemsSource = evm.EntryAdd.ToList();


        }

        private async void BtnShow_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("EMP_ID", ID);
            Preferences.Set("EMP_NAME", NAME);
            Preferences.Set("EMP_DEPAT", DEPARTMENT);
            await Navigation.PushAsync(new View.DetailPage(evm));
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entrysender = (Entry)sender;
            var text = ((Entry)sender).Text;
            int EntryID = 0;
            var enterdata = entrysender?.BindingContext as AddRecrod;
            if (enterdata != null)
            {
                EntryID = enterdata.ID;
            }

            evm.EntryAdd.Where(a => a.ID == EntryID).ToList().ForEach(x =>
            {
                x.ID = EntryID;
                x.TextValue = text;

            });
        }
        





    }

}