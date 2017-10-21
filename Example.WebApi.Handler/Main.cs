using Example.DataAccessLayer;
using System.Windows.Forms;

namespace Example.WebApi.Handler
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private async void btnGet_Click(object sender, System.EventArgs e)
        {
            var handler = new Responsible.Handler.WebApi.Handler("http://localhost:53558/");
            var getPersonResponse = await handler.GetAsync<Person>("People/1");
            Responsible.Handler.Winforms.Handler.HandleResponse("Loading Person", getPersonResponse);
            if (getPersonResponse.Success)
            {
                MessageBox.Show($"Name: {getPersonResponse.Value.Fullname}", "Loading Person", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
