using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Solcase_Document_Migration_Utility
{

    public static class Globals
    {
        public static DataSet solcaseDocs { get; set; }

        static Globals()
        {
            // initialize MyData property in the constructor with static methods
            solcaseDocs = new DataSet();
        }
    }

    public partial class SDMU : Form
    {
        public string SelectedMatter { get; private set; }
        public int SelectedMatterIndex { get; private set; }

        public SDMU()
        {
            InitializeComponent();

            //Set AutoGenerateColumns False
            dataGridView1.AutoGenerateColumns = false;

            // create data grid gheaders
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "DATE-INSERTED";
            dataGridView1.Columns[0].HeaderText = "Date Inserted";
            dataGridView1.Columns[0].DataPropertyName = "DATE-INSERTED";

            dataGridView1.Columns[1].Name = "HST-DESCRIPTION";
            dataGridView1.Columns[1].HeaderText = "Description";
            dataGridView1.Columns[1].DataPropertyName = "HST-DESCRIPTION";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {

            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.Title = "Select a Solcase Docs Migration File";
            openFileDialog1.FileName = "";

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog

            string fileName = openFileDialog1.FileName;
            string fileXML = fileName;

            try
            {
                Globals.solcaseDocs.ReadXml(fileXML);
                //bind tree view
                if (Globals.solcaseDocs.Tables.Count > 0)
                {
                    treeViewClientMatters.Nodes.Clear();

                    TreeNode root = new TreeNode(Globals.solcaseDocs.Tables["Client"].Rows[0]["CL-CODE"].ToString());
                    treeViewClientMatters.Nodes.Add(root);
                    treeViewClientMatters.SelectedNode = root;

                    foreach (DataRow row in Globals.solcaseDocs.Tables["Matter"].Rows)
                    {
                        TreeNode matterNode = new TreeNode(row["MT-CODE"].ToString());

                        treeViewClientMatters.SelectedNode.Nodes.Add(matterNode);

                    }

                    // set text box for client
                    txtBxClientName.Text = Globals.solcaseDocs.Tables["Client"].Rows[0]["CL-NAME"].ToString();

                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void treeViewClientMatters_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            SelectedMatter = e.Node.Text;
            SelectedMatterIndex = e.Node.Index;

            if (e.Node.Level != 0) {
                txtBxMatterDescription.Text = Globals.solcaseDocs.Tables["Matter"].Rows[SelectedMatterIndex]["MAT-DESCRIPTION"].ToString();
                Globals.solcaseDocs.Tables["SolDoc"].DefaultView.RowFilter = "Matter_Id = " + SelectedMatterIndex;
                dataGridView1.DataSource = Globals.solcaseDocs.Tables["SolDoc"].DefaultView;
            } else
            {
                txtBxMatterDescription.Text = "";
            }

            //populate data grid using selected Matter
            //Globals.solcaseDocs.Tables[2].DefaultView.RowFilter = "MT-CODE = " + SelectedMatter;
        }
    }
}
