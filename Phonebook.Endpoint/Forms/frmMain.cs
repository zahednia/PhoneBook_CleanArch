using ApplicationPhoneBook.Services.AddNewContact;
using ApplicationPhoneBook.Services.DeleteContact;
using ApplicationPhoneBook.Services.GetlistContact;
using PersistencePhoneBook.Context;
using Phonebook.Endpoint;
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
        private readonly IGetlistContactService getlistContactService;
        private readonly IDeleteContactService deleteContactService;

        public frmMain(IGetlistContactService getlistContactService
            , IDeleteContactService deleteContactService)
        {
            InitializeComponent();
            this.getlistContactService = getlistContactService;
            this.deleteContactService = deleteContactService;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            var listContact = getlistContactService.Execute();

            SettingGridview(listContact);

            this.Cursor = Cursors.Default;

        }

        private void SettingGridview(List<ContactListDto> listContact)
        {
            dataGridView1.DataSource = listContact;
            dataGridView1.Columns[0].HeaderText = "شناسه";
            dataGridView1.Columns[1].HeaderText = "نام";
            dataGridView1.Columns[2].HeaderText = "شماره تلفن";

            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            var listContacts = getlistContactService.Execute(txtSearchKey.Text);
            SettingGridview(listContacts);
            this.Cursor = Cursors.Default;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = deleteContactService.Execute(Id);

            if (result.IsSuccess == true)
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmMain_Load(null, null);
            }
            else
            {
                MessageBox.Show(result.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void ShowDetail()
        {
            //var Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //frmDetailContact frmDetailContact = new frmDetailContact(Id);
            //frmDetailContact.ShowDialog();
        }

        private void frmMain_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            //IAddNewContactService addNew =
            //    new AddNewContactService(new DatabaseContext());
            var serviceAdd = (IAddNewContactService)Program.ServiceProvider.GetService(typeof(IAddNewContactService));

            frmAddContact frmAddContact = new frmAddContact(serviceAdd);
            frmAddContact.ShowDialog();
            frmMain_Load(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var Id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            frmEdit frmEdit = new frmEdit(Id);
            frmEdit.ShowDialog();
            frmMain_Load(null, null);
        }
    }
}
