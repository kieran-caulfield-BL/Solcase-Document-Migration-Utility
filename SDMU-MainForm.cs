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

    public partial class SDMU : Form
    {
        public string SelectedMatter { get; private set; }
        public int SelectedMatterIndex { get; private set; }

        public SDMU()
        {
            InitializeComponent();

            //Set AutoGenerateColumns False
            dataGridView1.AutoGenerateColumns = false;

            // create data grid headers, the data grid is 1000 width
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "DATE-INSERTED";
            dataGridView1.Columns[0].HeaderText = "Date Inserted";
            dataGridView1.Columns[0].DataPropertyName = "DATE-INSERTED";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].Name = "HST-DESCRIPTION";
            dataGridView1.Columns[1].HeaderText = "Description";
            dataGridView1.Columns[1].DataPropertyName = "HST-DESCRIPTION";
            dataGridView1.Columns[1].Width = 400;

            dataGridView1.Columns[2].Name = "PROPOSED-FILE-NAME";
            dataGridView1.Columns[2].HeaderText = "Proposed File Name";
            dataGridView1.Columns[2].DataPropertyName = "PROPOSED-FILE-NAME";
            dataGridView1.Columns[2].Width = 500;

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

            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string fileXML = fileName;

                try
                {
                    // Bind out dataset to the xml file
                    Globals.solcaseDocs = new DataSet();
                    Globals.solcaseDocs.ReadXml(fileXML);
                    // create a new dataset table "SolDoc" column to generate the proposed file name if not exists
                    if (!Globals.solcaseDocs.Tables["SolDoc"].Columns.Contains("PROPOSED-FILE-NAME"))
                    {
                        Globals.solcaseDocs.Tables["SolDoc"].Columns.Add("PROPOSED-FILE-NAME", typeof(String));
                    }
                    // Now populate the new column
                    foreach (DataRow row in Globals.solcaseDocs.Tables["SolDoc"].Rows)
                    {
                        row["PROPOSED-FILE-NAME"] = FileNameCorrector.ToValidFileName(row["HST-DESCRIPTION"].ToString() + "." + row["EXTENSION"].ToString());
                    }

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

            } // if open file dialog result is OK
        }

        private void treeViewClientMatters_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            SelectedMatter = e.Node.Text;
            SelectedMatterIndex = e.Node.Index;

            //populate data grid using selected Matter
            if (e.Node.Level != 0) {
                txtBxMatterDescription.Text = Globals.solcaseDocs.Tables["Matter"].Rows[SelectedMatterIndex]["MAT-DESCRIPTION"].ToString();
                Globals.solcaseDocs.Tables["SolDoc"].DefaultView.RowFilter = string.Empty;
                Globals.solcaseDocs.Tables["SolDoc"].DefaultView.RowFilter = "Matter_Id = " + SelectedMatterIndex;

                BindingSource newMatterDocs = new BindingSource
                { DataSource = Globals.solcaseDocs.Tables["SolDoc"].DefaultView };

                dataGridView1.DataSource = newMatterDocs;
            } else
            {
                txtBxMatterDescription.Text = "";
            }

        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            // clear the text box for copy output
            tboxCopy.Clear();

            // get the target directory
            // Prepare a dummy string, this would appear in the dialog
            string dummyFileName = "Save Here";
            string savePath = "";

            //string sourceServer = "C:\\Users\\caulf\\OneDrive\\WorkFiles\\development\\SourceFolder\\";
            // Feed the dummy name to the save dialog
            saveFileDialog1.FileName = dummyFileName;
            saveFileDialog1.Filter = "Directory | directory";
            saveFileDialog1.Title = "Select directory to save files to.";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
            }

            // create a dictionary of source and target pair filepaths for the copy
            Dictionary<string, string> dictCopy = new Dictionary<string, string>();

            if (Globals.solcaseDocs.Tables["SolDoc"].DefaultView.Count > 0)
            {
                foreach (DataRowView row in Globals.solcaseDocs.Tables["SolDoc"].DefaultView)
                {
                    //create the source uri path from row fields
                    String sourceFilePath = row["DOS-PATH"].ToString() + row["SUB-PATH"].ToString() + row["DOCUMENT-NAME"].ToString();
                    String targetFilePath = savePath + "\\" + row["PROPOSED-FILE-NAME"].ToString();
                    dictCopy.Add(sourceFilePath, targetFilePath);
                }
            }

            double fileBlocks = 100.0;
            tboxCopy.AppendText("Starting copy ...");
            tboxCopy.AppendText(Environment.NewLine);

            string progressText = await Copier.CopyFiles(dictCopy, prog => fileBlocks = prog);

            tboxCopy.AppendText(progressText);
        }

    }

    public static class Globals
    {
        public static DataSet solcaseDocs { get; set; }

        static Globals()
        {
            // initialize MyData property in the constructor with static methods
            solcaseDocs = new DataSet();
        }
    }

    public static class FileNameCorrector
    {
        private static HashSet<char> invalid = new HashSet<char>(Path.GetInvalidFileNameChars());

        public static string ToValidFileName(this string name, char replacement = '\0')
        {
            var builder = new StringBuilder();
            foreach (var cur in name)
            {
                if (cur > 31 && cur < 128 && !invalid.Contains(cur))
                {
                    builder.Append(cur);
                }
                else if (replacement != '\0')
                {
                    builder.Append(replacement);
                }
            }

            // replace ".pdf.pdf"
            builder.Replace(".pdf.pdf", ".pdf");

            return builder.ToString();
        }
    }

    public static class Copier
    {
        public static async Task<string> CopyFiles(Dictionary<string, string> files, Action<double> progressCallback)
        {
            long total_size = files.Keys.Select(x => new FileInfo(x).Length).Sum();

            long total_read = 0;

            double progress_size = 1000.0;

            string progressText = "";

            foreach (var item in files)
            {
                long total_read_for_file = 0;

                var from = item.Key;
                var to = item.Value;

                progressText = progressText + "Copy " + from.ToString() + " to " + to.ToString() + Environment.NewLine;

                using (var outStream = new FileStream(to, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    using (var inStream = new FileStream(from, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        try
                        {
                            await CopyStream(inStream, outStream, x =>
                            {
                                total_read_for_file = x;
                                progressCallback(((total_read + total_read_for_file) / (double)total_size) * progress_size);
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                    }
                }

                total_read += total_read_for_file;

            }
            return progressText;
        }

        public static async Task CopyStream(Stream from, Stream to, Action<long> progress)
        {
            int buffer_size = 10240;

            byte[] buffer = new byte[buffer_size];

            long total_read = 0;

            while (total_read < from.Length)
            {
                int read = await from.ReadAsync(buffer, 0, buffer_size);

                await to.WriteAsync(buffer, 0, read);

                total_read += read;

                progress(total_read);
            }
        }

    }

}
