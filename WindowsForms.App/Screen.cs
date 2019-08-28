using System.Threading;
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
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            using (var process = new Processor("Loading Customers").CanBeCanceled(cancellationTokenSource))
            {
                var filterResponse = process.Process(() => CustomerLogic.FilterAsync(SearchTextBox.Text, token));
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

            using (var process = new Processor("Adding Customers"))
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