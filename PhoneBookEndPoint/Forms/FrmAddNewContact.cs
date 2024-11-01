using ApplicationPhoneBook.Services.AddNewContact;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBookEndPoint.Forms
{
    public partial class FrmAddNewContact : Form
    {
        private readonly IAddNewService addNewService;

        public FrmAddNewContact(IAddNewService addNewService)
        {
            InitializeComponent();
            this.addNewService = addNewService;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = addNewService.Execute(new AddNewContactDTO
            {
                Company = txtCompany.Text,
                Description = txtDescription.Text,
                LastName = txtLastName.Text,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text
            });
            if (result.IsSuccess)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
