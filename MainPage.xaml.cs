using Microsoft.Maui.Controls;
using Module05_Exercise01.ViewModel;

namespace Module05_Exercise01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new EmployeeViewModel();
        }
    }
}
