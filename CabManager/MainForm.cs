using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Deployment.Compression.Cab;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace CabManager
{
    public partial class MainForm : Form
    {
        IList<CabFileInfo> cabFiles;
        List<EFile> Files;
        CabInfo cab;
        bool onFileDrag;
        
        public MainForm(string file=null)
        {
            
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            if (file != null)
            {
                try
                {
                    OpenFile(file);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridViewFiles.AllowDrop = true;
            

            dataGridViewFiles.RowHeadersVisible = false;
            dataGridViewFiles.Cursor = Cursors.Hand;
            dataGridViewFiles.EnableHeadersVisualStyles = false;
            dataGridViewFiles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewFiles.ColumnHeadersHeight = 30;
            dataGridViewFiles.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewFiles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFiles.AllowUserToResizeRows = false;
            dataGridViewFiles.AllowUserToResizeColumns = false;
            dataGridViewFiles.CellBorderStyle = DataGridViewCellBorderStyle.None;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialogCabSelect.Filter = "Cab Files (*.cab) |*.cab";
            if (openFileDialogCabSelect.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialogCabSelect.FileName);
            }
        }
        public void OpenFile(string path)
        {
            textBoxFilePath.Text = path;
            cab = new CabInfo(path);
            cabFiles = cab.GetFiles();
            Files = new List<EFile>();

            string xml;

            using (StreamReader streamreader = new StreamReader(cab.OpenRead("_setup.xml"), Encoding.UTF8))
            {
                xml = streamreader.ReadToEnd();
            }



            XmlDocument setupxml = new XmlDocument();

            setupxml.LoadXml(xml);



            XmlNodeList xnList = setupxml.SelectNodes("/wap-provisioningdoc/characteristic/characteristic/characteristic");

            foreach (XmlNode xn in xnList)
            {
                foreach (XmlNode cxn in xn.ChildNodes)
                {
                    if (cxn.Attributes["type"].Value.ToString() == "Extract")
                    {
                        foreach (XmlNode xnFile in cxn.ChildNodes)
                        {
                            if (xnFile.Attributes["name"].Value.ToString() == "Source")
                            {
                                CabFileInfo cabfileinfo = cabFiles.Where(x => x.Name == xnFile.Attributes["value"].Value.ToString()).FirstOrDefault();
                                EFile file = new EFile();
                                file.Source = xnFile.Attributes["value"].Value.ToString();
                                file.FileName = xn.Attributes["type"].Value.ToString();
                                file.LastUpDate = cabfileinfo.LastWriteTime;
                                file.Lenght = cabfileinfo.Length;
                                file.FileIcon = FileIconLoader.GetFileIcon(file.FileName, false);


                                Files.Add(file);
                            }
                        }
                    }
                }
            }

            BindDataGrid();
            buttonExtract.Enabled = true;
            buttonInsertFiles.Enabled = true;
        }
        private void BindDataGrid()
        {
            dataGridViewFiles.DataSource=null;
            dataGridViewFiles.DataSource = Files;
            dataGridViewFiles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewFiles.Columns[0].Width = 20;
            dataGridViewFiles.Columns[3].DefaultCellStyle.Format = "N0";
        }
        private void dataGridViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                progressBarFiles.Maximum = files.Length;
                progressBarFiles.Value = 0;
                progressBarFiles.Visible = true;

                foreach (var filePath in files)
                {
                    InsertUpdateFileToCab(filePath);
                    progressBarFiles.Value += 1;

                }

                progressBarFiles.Visible = false;
                MessageBox.Show("Dosyaların Aktarımı Tamamlandı");
            }
        }
        private void InsertUpdateFileToCab(string filePath)
        {
            EFile file;


            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(filePath);
                file = new EFile();
                file.FileName = Path.GetFileName(filePath);
                file.Lenght = fileInfo.Length;
                file.LastUpDate = DateTime.Now;
                file.Source = "New File";
                file.FileIcon = FileIconLoader.GetFileIcon(file.FileName, false);
            }
            string temp = Path.GetTempPath() + "TempCab";
            cab.Unpack(temp);

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Path.GetTempPath() + "TempCab/_setup.xml");
            XmlNode root = xmldoc.SelectSingleNode("/wap-provisioningdoc/characteristic[@type='FileOperation']/characteristic[@translation='install']");
            //XmlNode root = xmldoc.SelectSingleNode("/wap-provisioningdoc/characteristic[@type='FileOperation']");
            

            //root.Attributes[""] = "";

            bool isExist = false;
            foreach (EFile f in Files)
            {
                if ((f.FileName.ToLower() == file.FileName.ToLower()) || (f.FileName.ToUpper() == file.FileName.ToUpper()))
                {
                    isExist = true;
                    file.Source = f.Source;

                    f.Lenght = file.Lenght;
                    f.LastUpDate = file.LastUpDate;

                    File.Copy(filePath,temp+"\\"+file.Source, true);


                }
            }

            if (!isExist)
            {
                File.Copy(filePath, temp + "\\" + file.FileName, true);

                //XmlNode node = xmldoc.CreateNode(XmlNodeType.Element, "characteristic",null);

                //XmlAttribute attr_type = xmldoc.CreateAttribute("type");
                //attr_type.Value = file.FileName;

                //XmlAttribute attr_translation = xmldoc.CreateAttribute("install");
                //attr_translation.Value = "install";

                //node.Attributes.Append(attr_type);
                //node.Attributes.Append(attr_translation);

                //root.AppendChild(node);

                //xmldoc.Save(Path.GetTempPath() + "TempCab/_setup.xml");

                Files.Add(file);
            }

            

            cab.Pack(temp, true, Microsoft.Deployment.Compression.CompressionLevel.None, null);
            
            Directory.Delete(temp,true);

            BindDataGrid();
        }
        private void dataGridViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && textBoxFilePath.Text!="")
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void buttonExtract_Click(object sender, EventArgs e)
        {
            folderBrowserDialogSelectExtractFolder.Description = "Dosyaların Çıkartılacağı Dizini Seçiniz.";
            if (textBoxFilePath.Text != null)
            {
                if (folderBrowserDialogSelectExtractFolder.ShowDialog() == DialogResult.OK)
                {
                    string directoryName = folderBrowserDialogSelectExtractFolder.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(cab.FullName);

                    CheckDirectoryForExtract(ref directoryName);

                    foreach (var file in Files)
                    {
                        Stream cabStream=cab.OpenRead(file.Source);




                        FileStream fs = File.Create(directoryName+"\\" + file.FileName);

                        byte[] buffer=new byte[cabStream.Length];
                        int read;

                        while((read=cabStream.Read(buffer,0,buffer.Length))>0){
                            fs.Write(buffer,0,read);
                        }

                        

                        fs.Close();
                        fs.Dispose();
                        cabStream.Close();
                        cabStream.Dispose();
                        
                    }

                    

                    if (MessageBox.Show("Files Has Been Extracted to Path :\n" + directoryName + "\nDo you want to open file directory ?", "Files Extracted Succesfully !", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        Process.Start(directoryName);

                    }
                    
                }
            }
            else
            {
                MessageBox.Show("First, You Must Select Cab File", "Cab File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CheckDirectoryForExtract(ref string directoryName)
        {
            if (Directory.Exists(directoryName))
            {
                directoryName += "(1)";
                CheckDirectoryForExtract(ref directoryName);
            }
            else
            {
                Directory.CreateDirectory(directoryName);
            }
        }
        private void dataGridViewFiles_MouseMove(object sender, MouseEventArgs e)
        {
            if (dataGridViewFiles.SelectedRows.Count > 0 && e.Button==MouseButtons.Left)
            {
                dataGridViewFiles.DoDragDrop(dataGridViewFiles.SelectedRows, DragDropEffects.All);
                
            }
        }
        private void dataGridViewFiles_MouseClick(object sender, MouseEventArgs e)
        {
            return;
        }
        private void dataGridViewFiles_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridViewFiles.DoDragDrop(dataGridViewFiles.SelectedRows,DragDropEffects.All);
        }
        private void dataGridViewFiles_MouseUp(object sender, MouseEventArgs e)
        {
            onFileDrag = false;
        }
        private void buttonInsertFiles_Click(object sender, EventArgs e)
        {
            openFileDialogFileSelect.Multiselect = true;
            openFileDialogCabSelect.Filter = "All Files (*.*) |*.*";

            if (openFileDialogFileSelect.ShowDialog()==DialogResult.OK)
            {
                var files = openFileDialogFileSelect.FileNames;

                progressBarFiles.Maximum = files.Length;
                progressBarFiles.Value = 0;
                progressBarFiles.Visible = true;

                foreach (var filePath in files)
                {
                    InsertUpdateFileToCab(filePath);
                    progressBarFiles.Value += 1;
                }

                progressBarFiles.Visible = false;
                MessageBox.Show("Dosyaların Aktarımı Tamamlandı");
            }
        }
        private void dataGridViewFiles_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewFiles.ClearSelection();

                dataGridViewFiles.Rows[e.RowIndex].Selected = true;
                contextMenuStripFile.Show(Cursor.Position);
            }
        }


    }
}
