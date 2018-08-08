using System.Windows.Forms;
using WindowsForms.App.Logic;
using WindowsForms.App.Models;
using Responsible.Handler.Winforms;

namespace WindowsForms.App
{
    public partial class Screen : Form
    {
        
        public Screen()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, System.EventArgs e)
        {
            SearchCustomers();
        }

        private void SearchCustomers()
        {
            var filterResponse = CustomerLogic.Filter(SearchTextBox.Text);
            Handler.HandleResponse("Loading Customers", filterResponse);
            CustomersDataGridView.DataSource = filterResponse.Value;
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var customerToAdd = new Customer
            {
                Firstname = FirstnameTextBox.Text,
                Lastname = LastnameTextBox.Text
            };
            var addResponse = CustomerLogic.Add(customerToAdd);
            Handler.HandleResponse("Adding Customer", addResponse, true);
            if (addResponse.Success)
            {
                SearchCustomers();
            }
        }
    }
}
