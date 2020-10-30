using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Xml;
using System.Windows.Forms.VisualStyles;
using System.Globalization;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Solcase_Document_Migration_Utility
{

    public partial class SDMU : MetroForm
    {
        public string SelectedMatter { get; private set; }
        public int SelectedMatterIndex { get; private set; }

        public delegate void CheckBoxHeaderClickHandler(CheckBoxHeaderCellEventArgs e);

        public SDMU()
        {
            InitializeComponent();


            // populate the URL link to the solcase web page
            metroLink1.Text = ConfigurationManager.ConnectionStrings["GetXMLFile"].ConnectionString;
            //metroLink1.Show();

            //Set AutoGenerateColumns False
            dataGridView1.AutoGenerateColumns = false;

            // check box
            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            var checkheader = new CheckBoxHeaderCell();
            checkheader.OnCheckBoxHeaderClick += checkheader_OnCheckBoxHeaderClick;
            col1.HeaderCell = checkheader;

            dataGridView1.Columns.Add(col1);

            dataGridView1.ColumnCount = 8;

            // create data grid headers, the data grid is 1000 width

            dataGridView1.Columns[1].Name = "DATE-INSERTED";
            dataGridView1.Columns[1].HeaderText = "Date";
            dataGridView1.Columns[1].DataPropertyName = "DATE-INSERTED-FORMATTED";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;

            dataGridView1.Columns[2].Name = "HST-DESCRIPTION";
            dataGridView1.Columns[2].HeaderText = "Description";
            dataGridView1.Columns[2].DataPropertyName = "HST-DESCRIPTION";
            dataGridView1.Columns[2].Width = 400;

            dataGridView1.Columns[3].Name = "PROPOSED-FILE-NAME";
            dataGridView1.Columns[3].HeaderText = "Proposed File Name";
            dataGridView1.Columns[3].DataPropertyName = "PROPOSED-FILE-NAME";
            dataGridView1.Columns[3].Width = 450;

            dataGridView1.Columns[4].Name = "DOS-PATH";
            dataGridView1.Columns[4].HeaderText = "DOS Path";
            dataGridView1.Columns[4].DataPropertyName = "DOS-PATH";
            dataGridView1.Columns[4].Visible = false;

            dataGridView1.Columns[5].Name = "SUB-PATH";
            dataGridView1.Columns[5].HeaderText = "SUB Path";
            dataGridView1.Columns[5].DataPropertyName = "SUB-PATH";
            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Columns[6].Name = "DOCUMENT-NAME";
            dataGridView1.Columns[6].HeaderText = "Document Name";
            dataGridView1.Columns[6].DataPropertyName = "DOCUMENT-NAME";
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.Columns[7].Name = "ATTACHMENTS";
            dataGridView1.Columns[7].HeaderText = "Attachments";
            dataGridView1.Columns[7].DataPropertyName = "ATTACHMENTS";
            dataGridView1.Columns[7].Width = 50;

        }


        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited
            // to true.
        
            //Call the Process.Start method to open the default browser
            //with a URL:
            System.Diagnostics.Process.Start(ConfigurationManager.ConnectionStrings["GetXMLFile"].ConnectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void checkheader_OnCheckBoxHeaderClick(CheckBoxHeaderCellEventArgs e)
        {
            dataGridView1.BeginEdit(true);
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[0].Value = e.IsChecked;
            }
            dataGridView1.EndEdit();

        }

        public class CheckBoxHeaderCellEventArgs : EventArgs
        {
            private bool _isChecked;
            public bool IsChecked
            {
                get { return _isChecked; }
            }

            public CheckBoxHeaderCellEventArgs(bool _checked)
            {
                _isChecked = _checked;

            }

        }

        class CheckBoxHeaderCell : DataGridViewColumnHeaderCell
        {
            Size checkboxsize;
            bool ischecked;
            Point location;
            Point cellboundsLocation;
            CheckBoxState state = CheckBoxState.UncheckedNormal;

            public event CheckBoxHeaderClickHandler OnCheckBoxHeaderClick;

            public CheckBoxHeaderCell()
            {
                location = new Point();
                cellboundsLocation = new Point();
                ischecked = false;
            }

            // http://dotnetvisio.blogspot.com/2015/08/create-select-all-checkbox-column.html
            protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
            {
                /* Make a condition to check whether the click is fired inside a checkbox region */
                Point clickpoint = new Point(e.X + cellboundsLocation.X, e.Y + cellboundsLocation.Y);

                if ((clickpoint.X > location.X && clickpoint.X < (location.X + checkboxsize.Width)) && (clickpoint.Y > location.Y && clickpoint.Y < (location.Y + checkboxsize.Height)))
                {
                    ischecked = !ischecked;
                    if (OnCheckBoxHeaderClick != null)
                    {
                        OnCheckBoxHeaderClick(new CheckBoxHeaderCellEventArgs(ischecked));
                        this.DataGridView.InvalidateCell(this);
                    }
                }
                base.OnMouseClick(e);
            }

            protected override void Paint(Graphics graphics, Rectangle clipBounds,
                 Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText,
                DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle
                advancedBorderStyle, DataGridViewPaintParts paintParts)
            {

                base.Paint(graphics, clipBounds, cellBounds, rowIndex, dataGridViewElementState,
               value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

                checkboxsize = CheckBoxRenderer.GetGlyphSize(graphics, CheckBoxState.UncheckedNormal);
                location.X = cellBounds.X + (cellBounds.Width / 2 - checkboxsize.Width / 2);
                location.Y = cellBounds.Y + (cellBounds.Height / 2 - checkboxsize.Height / 2);
                cellboundsLocation = cellBounds.Location;

                if (ischecked)
                    state = CheckBoxState.CheckedNormal;
                else
                    state = CheckBoxState.UncheckedNormal;

                CheckBoxRenderer.DrawCheckBox(graphics, location, state);


            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {            
            openFileDialog1.DefaultExt = "xml";
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            openFileDialog1.Title = "Select a Solcase Docs Migration File";
            openFileDialog1.FileName = "";

            string userProfileFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string DownloadsFolder = Path.Combine(userProfileFolder,"Downloads");

            openFileDialog1.InitialDirectory = DownloadsFolder.ToString();

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog

            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                string fileXML = fileName;

                try
                {
                    // Bind our dataset to the xml file
                    Globals.solcaseDocs = new DataSet();
                    Globals.solcaseDocs.ReadXml(fileXML);

                    // create a new dataset table "SolDoc" column to generate the proposed file name if not exists
                    if (!Globals.solcaseDocs.Tables["SolDoc"].Columns.Contains("PROPOSED-FILE-NAME"))
                    {
                        Globals.solcaseDocs.Tables["SolDoc"].Columns.Add("PROPOSED-FILE-NAME", typeof(String));
                    }
                    // create a new dataset table "SolDoc" column to capture the number of attachments in an email
                    if (!Globals.solcaseDocs.Tables["SolDoc"].Columns.Contains("ATTACHMENTS"))
                    {
                        Globals.solcaseDocs.Tables["SolDoc"].Columns.Add("ATTACHMENTS", typeof(int)).DefaultValue = 0;
                    }
                    
                    // create a new dataset table "SolDoc" column to generate the date inserted formatted if not exists
                    if (!Globals.solcaseDocs.Tables["SolDoc"].Columns.Contains("DATE-INSERTED-FORMATTED"))
                    {
                        Globals.solcaseDocs.Tables["SolDoc"].Columns.Add("DATE-INSERTED-FORMATTED", typeof(DateTime));
                    }
                    // Now populate the new column(s)
                    foreach (DataRow row in Globals.solcaseDocs.Tables["SolDoc"].Rows)
                    {
                        try
                        {
                            row["DATE-INSERTED-FORMATTED"] = DateTime.ParseExact(row["DATE-INSERTED"].ToString(),"dd-MM-yyyy",CultureInfo.InvariantCulture);
                        } 
                        catch (FormatException)
                        {
                            row["DATE-INSERTED-FORMATTED"] = DateTime.Today;
                        }

                        // 07 Aug: Added unique HISTORY NO as many files have the same name and they get overwriiten!
                        row["PROPOSED-FILE-NAME"] = FileNameCorrector.ToValidFileName(row["HST-DESCRIPTION"].ToString().Trim()+ "." + row["HISTORY-NO"].ToString() + "." + row["EXTENSION"].ToString());

                        // [ATTACHMENTS] is not filled here, as will require remote access to file (see later)
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

        private int getNumberOfAttachments(string email)
        {
            // this needs outlook installed!
            var outlook = Globals.Outlook;
            var item = (MailItem)outlook.CreateItemFromTemplate(email, Type.Missing);
            return item.Attachments.Count;
            //return 1;
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

                // format the dates

                BindingSource newMatterDocs = new BindingSource
                { DataSource = Globals.solcaseDocs.Tables["SolDoc"].DefaultView };

                dataGridView1.DataSource = newMatterDocs;

                dataGridView1.Columns[0].DefaultCellStyle.Format = "d"; // Short date

                // set the count of all files imported
                txtBoxImportTotal.Text = newMatterDocs.Count.ToString();

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
            
            //String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String path = "E:\\SDMU";
            Globals.savePath = Path.Combine(path, Globals.solcaseDocs.Tables["Client"].Rows[0]["CL-CODE"].ToString(),treeViewClientMatters.SelectedNode.Text);
            Globals.attachmentsPath = Path.Combine(Globals.savePath, "Attachments");

            try
            {
                // ... If the directory doesn't exist, create it.
                if (!Directory.Exists(Globals.savePath))
                {
                    Directory.CreateDirectory(Globals.savePath);
                }
                if (!Directory.Exists(Globals.attachmentsPath))
                {
                    Directory.CreateDirectory(Globals.attachmentsPath);
                }
            }
            catch (System.Exception)
            {
                tboxCopy.AppendText("Unable to create directory: " + Globals.savePath.ToString());
                tboxCopy.AppendText(Environment.NewLine);
                return;
            }

            //string sourceServer = "C:\\Users\\caulf\\OneDrive\\WorkFiles\\development\\SourceFolder\\";
            // Feed the dummy name to the save dialog
            saveFileDialog1.FileName = dummyFileName;
            saveFileDialog1.Filter = "Directory | directory";
            saveFileDialog1.Title = "Select directory to save files to.";


            // create a dictionary of source and target pair filepaths for the copy
            // annotate as true if the value is a msg file with attachments
            Dictionary<string, Tuple<bool,string>> dictCopy = new Dictionary<string, Tuple<bool,string>>();

            // keep a note of the last DOS Path , to raise exception.
            string dosPath = "";

            // count the number of checked lines
            Globals.checkedTotal = 0;

            // extract only the checked grid items
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if(cell.Value!=null && (bool) cell.Value == true)
                {
                    dosPath = row.Cells["DOS-PATH"].Value.ToString();
                    String sourceFilePath = row.Cells["DOS-PATH"].Value.ToString() + row.Cells["SUB-PATH"].Value.ToString() + row.Cells["DOCUMENT-NAME"].Value.ToString();
                    String targetFileName = row.Cells["PROPOSED-FILE-NAME"].Value.ToString();
                    int sourceFilePathLength = sourceFilePath.Length;
                    int targetFileNamePathLength = targetFileName.Length;

                    // 250 is the max size of path + filename so reduce the file name if needed 

                    int totalPathLength = sourceFilePathLength + targetFileNamePathLength;

                    if (totalPathLength > 250) {
                        targetFileName = targetFileName.Substring(0, 249 - sourceFilePathLength);
                    }
                    
                    String targetFilePath = Path.Combine(Globals.savePath,targetFileName);
                    dictCopy.Add(sourceFilePath, new Tuple<bool, string>(false, targetFilePath));
                    Globals.checkedTotal += 1;
                    
                }
            }

            // update the text box fo number of lines selected
            txtBoxSelectedTotal.Text = Globals.checkedTotal.ToString();
            // update the progress bar size 
            progressBar1.Maximum = Globals.checkedTotal;

            double fileBlocks = 100.0;
            tboxCopy.AppendText("Starting copy ...");
            tboxCopy.AppendText(Environment.NewLine);
            tboxCopy.AppendText("Target Directory is: " + Globals.savePath.ToString());
            tboxCopy.AppendText(Environment.NewLine);

            progressBar1.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;

            });

            string progressText = "";
            tboxCopy.Clear();

            try
            {
                progressText = await Copier.CopyFiles(progress, dictCopy, prog => fileBlocks = prog);

                tboxCopy.AppendText(progressText);
                tboxCopy.AppendText("File Transfer Completed.");

                txtBoxCopyTotal.Text = Directory.GetFiles(Globals.savePath, "*.*", SearchOption.TopDirectoryOnly).Length.ToString();
            } catch (System.Exception ex)
            {
                tboxCopy.AppendText(Environment.NewLine);
                tboxCopy.AppendText("Exception Raised - Unable to copy files from: " + dosPath);
                tboxCopy.AppendText(Environment.NewLine);
                tboxCopy.AppendText(ex.Message);
                tboxCopy.AppendText(Environment.NewLine);
            }
            finally
            {
                //tboxCopy.AppendText(progressText);
                //tboxCopy.AppendText("File Transfer Halted.");

                txtBoxCopyTotal.Text = Directory.GetFiles(Globals.savePath, "*.*", SearchOption.TopDirectoryOnly).Length.ToString();
            }

        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            // find where the matter files have been saved

            if (Globals.savePath == null)
            {
                // use the grid matter number to regenerate the path
                //String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Change 30/10/2020 - Redirect to E drive
                String path = "E:\\SDMU";
                Globals.savePath = Path.Combine(path, Globals.solcaseDocs.Tables["Client"].Rows[0]["CL-CODE"].ToString(), treeViewClientMatters.SelectedNode.Text);
                Globals.attachmentsPath = Path.Combine(Globals.savePath, "Attachments");
            }
            
            // Unpack attachments to msg files

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;

                String fileSuffix = Path.GetExtension(row.Cells["PROPOSED-FILE-NAME"].Value.ToString());

                if (cell.Value != null && (bool)cell.Value == true && fileSuffix == ".msg")
                {
                    // Inspect if this is a msg with attachments
                    String sourceCopiedFileName = Path.Combine(Globals.savePath, row.Cells["PROPOSED-FILE-NAME"].Value.ToString());

                    var outlook = Globals.Outlook;

                    int attachmentsCount = 0;

                    try
                    {
                        var item = (MailItem)outlook.CreateItemFromTemplate(sourceCopiedFileName, Type.Missing);
                        attachmentsCount = item.Attachments.Count;

                        row.Cells["ATTACHMENTS"].Value = attachmentsCount.ToString();

                        if (attachmentsCount > 0)
                        {

                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            tboxCopy.AppendText(Environment.NewLine);
                            tboxCopy.AppendText("Extracting Attachments.");

                            String targetDirPath = Path.Combine(Globals.attachmentsPath, Path.GetFileNameWithoutExtension(sourceCopiedFileName).Trim());
                            // ... If the directory doesn't exist, create it.
                            if (!Directory.Exists(targetDirPath))
                            {
                                Directory.CreateDirectory(targetDirPath);
                            }

                            // Extract all attachments
                            for (int i = 1; i < item.Attachments.Count + 1; i++)
                            {

                                String targetFilePath = Path.Combine(targetDirPath, item.Attachments[i].FileName);
                                item.Attachments[i].SaveAsFile(targetFilePath);
                                //Globals.checkedTotal += 1;

                                tboxCopy.AppendText(Environment.NewLine);
                                tboxCopy.AppendText(targetFilePath);
                            }

                        }
                    }
                    catch (System.InvalidCastException ex)
                    {
                        attachmentsCount = 0;
                        tboxCopy.AppendText(Environment.NewLine);
                        tboxCopy.AppendText(ex.Message);

                    }
                    catch (System.Exception ex)
                    {
                        tboxCopy.AppendText(Environment.NewLine);
                        tboxCopy.AppendText(ex.Message);
                    }
                }
            }

            tboxCopy.AppendText(Environment.NewLine);
            tboxCopy.AppendText("Email Attachements processed.");
        }
    }

    public static class Globals
    {
        public static DataSet solcaseDocs { get; set; }

        public static Microsoft.Office.Interop.Outlook.Application Outlook { get; set; }

        public static string savePath { get; set; }

        public static string attachmentsPath { get; set; }

        public static int checkedTotal { get; set; }

        static Globals()
        {
            // initialize MyData property in the constructor with static methods
            solcaseDocs = new DataSet();

            // Email object
            Outlook = new Microsoft.Office.Interop.Outlook.Application();

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
            builder.Replace("&amp;", "and");

            return builder.ToString();
        }
    }

    public static class Copier
    {
        public static async Task<string> CopyFiles(IProgress<int> progress,Dictionary<string, Tuple<bool,string>> files, Action<double> progressCallback)
        {
            long total_size = files.Keys.Select(x => new FileInfo(x).Length).Sum();

            long total_read = 0;

            int progressPercent = 0;

            
            int progressIncrement = 1; // bar size is set in treeViewClientMatters_AfterSelect_1

            string progressText = "";

            foreach (var item in files)
            {
                long total_read_for_file = 0;
                progressPercent += progressIncrement;

                var from = item.Key;
                var to = item.Value.Item2;
                //TODO : check if this is a *.msg with more than 0 attachments, set as Tuple item1 (true false)
                var attachments = item.Value.Item1;

                progressText = progressText + "Copy from: " + from.ToString() + Environment.NewLine;
                progressText = progressText + "Copy to  : " + to.ToString() + Environment.NewLine;

                using (var outStream = new FileStream(to, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    using (var inStream = new FileStream(from, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        try
                        {
                            await CopyStream(inStream, outStream, x =>
                            {
                                total_read_for_file = x;
                                progressCallback(((total_read + total_read_for_file) / (double)total_size) * 1);
                            });

                        }
                        catch (System.Exception ex)
                        {
                            progressText = progressText + ex.Message + Environment.NewLine;
                            progressText = progressText + "Failed to copy from  : " + from.ToString() + Environment.NewLine;
                            progressText = progressText + "to  : " + to.ToString() + Environment.NewLine;

                            continue;
                        }

                    }
                }

                File.SetCreationTime(to.ToString(), File.GetCreationTime(from.ToString()));
                File.SetLastWriteTime(to.ToString(), File.GetLastWriteTime(from.ToString()));

                total_read += total_read_for_file;

                progress.Report(progressPercent);

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
