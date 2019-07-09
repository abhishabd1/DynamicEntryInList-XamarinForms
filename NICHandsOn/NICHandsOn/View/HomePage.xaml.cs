using NICHandsOn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NICHandsOn.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public Employee _emp;
        public HomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _emp = new Employee();
          
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
           
            _emp.EmployeeId = EntryId.Text;
            _emp.Name = EntryName.Text;
            _emp.Department = EntryDepart.Text;
            Navigation.PushAsync(new View.ExpensePage(_emp));
        }
    }
}