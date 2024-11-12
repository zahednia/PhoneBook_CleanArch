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

namespace UI_winForm.Forms
{
    public partial class frmAddContact : Form
    {
        private readonly IAddNewContactService addNewContactService;

        public frmAddContact(IAddNewContactService addNewContactService)
        {
            InitializeComponent();
            this.addNewContactService = addNewContactService;
        }

        private void frmAddContact_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = addNewContactService.Execute(new AddNewContactDto
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
