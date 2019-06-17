using System.Windows.Forms;
using WindowsForms.App.Logic;
using WindowsForms.App.Models;
using Responsible.Handler.Winforms.Processors;

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
            using (var process = new Processor(this, "Loading Customers"))
            {
                var filterResponse = process.Process(() => CustomerLogic.Filter(SearchTextBox.Text));
                CustomersDataGridView.DataSource = filterResponse.Value;
            }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var customerToAdd = new Customer
            {
                Firstname = FirstnameTextBox.Text,
                Lastname = LastnameTextBox.Text
            };

            using (var process = new Processor(this, "Adding Customers"))
            {
                var addResponse = process.Process(() => CustomerLogic.Add(customerToAdd));
                if (addResponse.Success)
                {
                    SearchCustomers();
                }
            }
        }
    }
}