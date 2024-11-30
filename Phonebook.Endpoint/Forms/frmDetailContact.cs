using ApplicationPhoneBook.Services.ShowDetail;
using System;
using System.Windows.Forms;

namespace UI_winForm.Forms
{
    public partial class frmDetailContact : Form
    {
        private readonly iShowDetailService iShowDetail;
        private readonly int contactId;

        public frmDetailContact(iShowDetailService iShowDetail, int contactId)
        {
            InitializeComponent();
            this.iShowDetail = iShowDetail;
            this.contactId = contactId;
        }

        private void frmDetailContact_Load(object sender, EventArgs e)
        {
            var contact = iShowDetail.ShowDetail(new ShowDetailDto(), contactId);
            if (contact.IsSuccess == false)
            {
                MessageBox.Show(contact.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblId.Text = contact.Data.Id.ToString();
            lblName.Text = contact.Data.Name;
            lblLastName.Text = contact.Data.LastName;
            lblCompany.Text = contact.Data.Company;
            lblPhoneNumber.Text = contact.Data.PhoneNumber;
            rtxtDes.Text = contact.Data.Description;
            lblCreatetAt.Text = contact.Data.CreateAt.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblPhoneNumber_Click(object sender, EventArgs e)
        {

        }
    }
}
