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
            var filterResponse = ResponsibleProcessor.Process("Loading Customers", ()=> CustomerLogic.Filter(SearchTextBox.Text), true);
            CustomersDataGridView.DataSource = filterResponse.Value;
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var customerToAdd = new Customer
            {
                Firstname = FirstnameTextBox.Text,
                Lastname = LastnameTextBox.Text
            };

            var addResponse = ResponsibleProcessor.Process("Adding Customer", ()=> CustomerLogic.Add(customerToAdd), true, true);
            if (addResponse.Success)
            {
                SearchCustomers();
            }
        }
    }
}
