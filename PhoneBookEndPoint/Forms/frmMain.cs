
using ApplicationPhoneBook.Services.AddNewContact;
using PhoneBookEndPoint;
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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void SettingGridview()
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            frmDetailContact frmDetailContact= new frmDetailContact();
            frmDetailContact.ShowDialog();
        }

        private void ShowDetail()
        {

        }

        private void frmMain_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            var serviceadd = (IAddNewService)Program.ServiceProvider.GetService(typeof(IAddNewService));
            frmAddContact frmAddContact = new frmAddContact(serviceadd);
            frmAddContact.ShowDialog();
            frmMain_Load(null, null );
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEdit frmEdit = new frmEdit();
            frmEdit.ShowDialog();
        }
    }
}
