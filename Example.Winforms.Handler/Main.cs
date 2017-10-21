using System;
using System.Windows.Forms;
using Example.DataAccessLayer;
using ResponseHandler = Responsible.Handler.Winforms.Handler;

namespace Example.Winforms.Handler
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnAddException_Click(object sender, EventArgs e)
        {
            var addResponse = new People().AddPerson(null); //Exception response (NullRefException)
            ResponseHandler.HandleResponse("Adding Person", addResponse, true);
        }

        private void btnAddError_Click(object sender, EventArgs e)
        {
            var person = new Person() { Fullname = null };
            var addResponse = new People().AddPerson(person); //Error response (Name not provided)
            ResponseHandler.HandleResponse("Adding Person", addResponse, true);
        }

        private void btnAddOk_Click(object sender, EventArgs e)
        {
            var person = new Person() { Fullname = "Naeem Afzal" };
            var addResponse = new People().AddPerson(person); //Ok Response
            ResponseHandler.HandleResponse("Adding Person", addResponse, true);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            var loadPerson = new People().GetPerson(1);
            ResponseHandler.HandleResponse("Load Person", loadPerson); //Ok Response with a value
            if (loadPerson.Success)
            {
                var loadedPerson = loadPerson.Value; //Taking value from the response
                MessageBox.Show($@"Name: {loadedPerson?.Fullname}"); //Printing name
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateResponse = new People().UpdatePerson(new Person()); //Not implemented response
            ResponseHandler.HandleResponse("Update Person", updateResponse, true);
        }
    }
}
