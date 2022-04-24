using System;
using System.Windows.Forms;
using PatternRecognition.FingerprintRecognition.Applications;

namespace Dactylo
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public auth_regForm form;

        private void bases_Click(object sender, EventArgs e)
        {
            basesForm bf = new basesForm();
            bf.form = this;
            bf.Owner = this;
            bf.Show();
            Hide();
        }

        private void cards_Click(object sender, EventArgs e)
        {
            cardsForm cf = new cardsForm();
            cf.form = this;
            cf.Owner = this;
            cf.Show();
            Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
            Hide();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            users.Text = DataBank.uspos>=1 ? "Пользователи" : "Аккаунт";
        }

        private void users_Click(object sender, EventArgs e)
        {
            if (DataBank.uspos >= 1)
            {
                usersForm uf = new usersForm();
                uf.form = this;
                uf.Owner = this;
                uf.Show();
                Hide();
            }
            else
            {
                accountForm af = new accountForm();
                af.form = this;
                af.Owner = this;
                af.TopLevel = true;
                af.ShowDialog();
            }
        }

        private void fingerprintables_Click(object sender, EventArgs e)
        {
            fingerprintablesForm ff = new fingerprintablesForm();
            ff.form = this;
            ff.Owner = this;
            ff.TopLevel = true;
            ff.Show();
            Hide();
        }

        private void search_Click(object sender, EventArgs e)
        {
            FMExperimenterForm vm = new FMExperimenterForm();
            vm.form = this;
            vm.btnVisualMatch_Click(sender, e);
            Hide();
        }

        private void research_Click(object sender, EventArgs e)
        {
            FeatureDisplayForm fd = new FeatureDisplayForm();
            fd.form = this;
            fd.TopLevel = true;
            fd.Show();
            Hide();
        }
    }
}
