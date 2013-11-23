using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DotNetOpenAuth.OAuth;
using EConnectApi.Definitions;
using EConnectApi;
using EConnectDocEx.Properties;


namespace EConnectDocEx
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm mySettingsForm = new SettingsForm();

            mySettingsForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBoxeConnect myAboutBoxeConnect = new AboutBoxeConnect();

            myAboutBoxeConnect.ShowDialog();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            var doc = new SendDocument()
            {
                DocumentTemplateId = "GLDT9223370666504283001RA000000006DTP2000001",
                Subject = "Afas test factuur",
                Recipient = "thieme@selmit.nl",
                RecipientEmailId = "thieme@selmit.nl",
                Payload = XElement.Parse(System.IO.File.ReadAllText(@"C:\Users\Thieme\Documents\SelmIT\eVerbinding\EConnectApi\Test files\UBLWITHATTACHEMENT.txt")),
                DocumentAsFile = new DocumentAsFile() { FileContents = "T3JkZXIgRGV0YWlscyBmb3IgUGFydG5lcldvcmxkIExpY2Vuc2U=", FileName = "order.txt" }
            };
            //Columns.Add(new Columns() doc.DocumentAsFile.FileName)
            //dataGridView1.Columns.Add(new DataGridViewColumn() { }, )
            var list = new[] {doc};
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = list;
            //dataGridView1.Show();
            using (var client = new EConnectClient("thieme@selmit.nl"))
            {
                var res1 = client.SendDocument(doc);
                //var res2 = client.SendDocument(doc);
            }
        }
    }
}
