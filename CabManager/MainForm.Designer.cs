namespace CabManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialogCabSelect = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewFiles = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialogSelectExtractFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogFileSelect = new System.Windows.Forms.OpenFileDialog();
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.buttonInsertFiles = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yenidenAdlandırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dışarıÇıkartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBarFiles = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).BeginInit();
            this.PanelMenu.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.BackColor = System.Drawing.Color.White;
            this.textBoxFilePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxFilePath.Enabled = false;
            this.textBoxFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFilePath.ForeColor = System.Drawing.Color.White;
            this.textBoxFilePath.Location = new System.Drawing.Point(0, 566);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(1032, 24);
            this.textBoxFilePath.TabIndex = 0;
            // 
            // dataGridViewFiles
            // 
            this.dataGridViewFiles.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFiles.GridColor = System.Drawing.Color.White;
            this.dataGridViewFiles.Location = new System.Drawing.Point(0, 83);
            this.dataGridViewFiles.Name = "dataGridViewFiles";
            this.dataGridViewFiles.RowTemplate.ContextMenuStrip = this.contextMenuStripFile;
            this.dataGridViewFiles.Size = new System.Drawing.Size(1032, 507);
            this.dataGridViewFiles.TabIndex = 2;
            this.dataGridViewFiles.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewFiles_CellMouseDown);
            this.dataGridViewFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewFiles_DragDrop);
            this.dataGridViewFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewFiles_DragEnter);
            this.dataGridViewFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewFiles_MouseDown);
            this.dataGridViewFiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridViewFiles_MouseMove);
            this.dataGridViewFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridViewFiles_MouseUp);
            // 
            // openFileDialogFileSelect
            // 
            this.openFileDialogFileSelect.FileName = "openFileDialog1";
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.DodgerBlue;
            this.PanelMenu.Controls.Add(this.buttonExtract);
            this.PanelMenu.Controls.Add(this.buttonInsertFiles);
            this.PanelMenu.Controls.Add(this.buttonOpen);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(1032, 83);
            this.PanelMenu.TabIndex = 6;
            // 
            // buttonExtract
            // 
            this.buttonExtract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExtract.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonExtract.Enabled = false;
            this.buttonExtract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExtract.Image = global::CabManager.Properties.Resources.extract_love;
            this.buttonExtract.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonExtract.Location = new System.Drawing.Point(194, 0);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(97, 83);
            this.buttonExtract.TabIndex = 6;
            this.buttonExtract.Text = "Dosyaları Çıkart";
            this.buttonExtract.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // buttonInsertFiles
            // 
            this.buttonInsertFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInsertFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonInsertFiles.Enabled = false;
            this.buttonInsertFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsertFiles.Image = global::CabManager.Properties.Resources._1444330017_archive_insert_directory;
            this.buttonInsertFiles.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonInsertFiles.Location = new System.Drawing.Point(97, 0);
            this.buttonInsertFiles.Name = "buttonInsertFiles";
            this.buttonInsertFiles.Size = new System.Drawing.Size(97, 83);
            this.buttonInsertFiles.TabIndex = 8;
            this.buttonInsertFiles.Text = "Dosya Ekle";
            this.buttonInsertFiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonInsertFiles.UseVisualStyleBackColor = true;
            this.buttonInsertFiles.Click += new System.EventHandler(this.buttonInsertFiles_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpen.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Image = global::CabManager.Properties.Resources.open_folder_yellow__1_;
            this.buttonOpen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonOpen.Location = new System.Drawing.Point(0, 0);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(97, 83);
            this.buttonOpen.TabIndex = 7;
            this.buttonOpen.Text = "Aç";
            this.buttonOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dışarıÇıkartToolStripMenuItem,
            this.toolStripSeparator1,
            this.silToolStripMenuItem,
            this.yenidenAdlandırToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.ShowImageMargin = false;
            this.contextMenuStripFile.Size = new System.Drawing.Size(130, 82);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.silToolStripMenuItem.Text = "Sil";
            // 
            // yenidenAdlandırToolStripMenuItem
            // 
            this.yenidenAdlandırToolStripMenuItem.Name = "yenidenAdlandırToolStripMenuItem";
            this.yenidenAdlandırToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.yenidenAdlandırToolStripMenuItem.Text = "İsmi Değiştir";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // dışarıÇıkartToolStripMenuItem
            // 
            this.dışarıÇıkartToolStripMenuItem.Name = "dışarıÇıkartToolStripMenuItem";
            this.dışarıÇıkartToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.dışarıÇıkartToolStripMenuItem.Text = "Dışarı Çıkart";
            // 
            // progressBarFiles
            // 
            this.progressBarFiles.Location = new System.Drawing.Point(215, 286);
            this.progressBarFiles.Name = "progressBarFiles";
            this.progressBarFiles.Size = new System.Drawing.Size(599, 23);
            this.progressBarFiles.TabIndex = 8;
            this.progressBarFiles.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1032, 590);
            this.Controls.Add(this.progressBarFiles);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.dataGridViewFiles);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cab Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFiles)).EndInit();
            this.PanelMenu.ResumeLayout(false);
            this.contextMenuStripFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialogCabSelect;
        private System.Windows.Forms.DataGridView dataGridViewFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelectExtractFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialogFileSelect;
        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Button buttonInsertFiles;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem dışarıÇıkartToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yenidenAdlandırToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBarFiles;
    }
}

