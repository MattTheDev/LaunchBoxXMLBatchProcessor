using System.Drawing;
using System.Windows.Forms;

namespace XmlImageProcessor;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        settingsToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        helpToolStripMenuItem = new ToolStripMenuItem();
        aboutToolStripMenuItem = new ToolStripMenuItem();
        
        lblXmlPath = new Label();
        txtXmlPath = new TextBox();
        btnBrowseXml = new Button();
        lblImagePath = new Label();
        txtImagePath = new TextBox();
        btnBrowseImage = new Button();
        picImagePreview = new PictureBox();
        lblOutputPath = new Label();
        txtOutputPath = new TextBox();
        btnBrowseOutput = new Button();
        btnProcess = new Button();
        progressBar = new ProgressBar();
        lblProgress = new Label();
        txtLog = new TextBox();
        lblLog = new Label();
        lblStats = new Label();
        openFileDialog = new OpenFileDialog();
        folderBrowserDialog = new FolderBrowserDialog();
        SuspendLayout();
        
        // Menu Strip
        menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(900, 28);
        menuStrip.TabIndex = 0;
        
        // File Menu
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(46, 24);
        fileToolStripMenuItem.Text = "&File";
        
        // Settings Menu Item
        settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        settingsToolStripMenuItem.Size = new Size(145, 26);
        settingsToolStripMenuItem.Text = "&Settings...";
        settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
        
        // Separator
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(142, 6);
        
        // Exit Menu Item
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(145, 26);
        exitToolStripMenuItem.Text = "E&xit";
        exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
        
        // Help Menu
        helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
        helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        helpToolStripMenuItem.Size = new Size(55, 24);
        helpToolStripMenuItem.Text = "&Help";
        
        // About Menu Item
        aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        aboutToolStripMenuItem.Size = new Size(133, 26);
        aboutToolStripMenuItem.Text = "&About...";
        aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
        
        // lblXmlPath
        lblXmlPath.AutoSize = true;
        lblXmlPath.Location = new Point(12, 45);
        lblXmlPath.Name = "lblXmlPath";
        lblXmlPath.Size = new Size(80, 20);
        lblXmlPath.TabIndex = 1;
        lblXmlPath.Text = "XML File:";
        
        // txtXmlPath
        txtXmlPath.Location = new Point(98, 42);
        txtXmlPath.Name = "txtXmlPath";
        txtXmlPath.Size = new Size(500, 27);
        txtXmlPath.TabIndex = 2;
        
        // btnBrowseXml
        btnBrowseXml.Location = new Point(604, 41);
        btnBrowseXml.Name = "btnBrowseXml";
        btnBrowseXml.Size = new Size(75, 29);
        btnBrowseXml.TabIndex = 3;
        btnBrowseXml.Text = "Browse";
        btnBrowseXml.UseVisualStyleBackColor = true;
        btnBrowseXml.Click += btnBrowseXml_Click;
        
        // lblImagePath
        lblImagePath.AutoSize = true;
        lblImagePath.Location = new Point(12, 85);
        lblImagePath.Name = "lblImagePath";
        lblImagePath.Size = new Size(105, 20);
        lblImagePath.TabIndex = 4;
        lblImagePath.Text = "Source Image:";
        
        // txtImagePath
        txtImagePath.Location = new Point(123, 82);
        txtImagePath.Name = "txtImagePath";
        txtImagePath.Size = new Size(475, 27);
        txtImagePath.TabIndex = 5;
        txtImagePath.TextChanged += txtImagePath_TextChanged;
        
        // btnBrowseImage
        btnBrowseImage.Location = new Point(604, 81);
        btnBrowseImage.Name = "btnBrowseImage";
        btnBrowseImage.Size = new Size(75, 29);
        btnBrowseImage.TabIndex = 6;
        btnBrowseImage.Text = "Browse";
        btnBrowseImage.UseVisualStyleBackColor = true;
        btnBrowseImage.Click += btnBrowseImage_Click;
        
        // picImagePreview
        picImagePreview.BorderStyle = BorderStyle.FixedSingle;
        picImagePreview.Location = new Point(695, 42);
        picImagePreview.Name = "picImagePreview";
        picImagePreview.Size = new Size(180, 135);
        picImagePreview.SizeMode = PictureBoxSizeMode.Zoom;
        picImagePreview.TabIndex = 16;
        picImagePreview.TabStop = false;
        picImagePreview.BackColor = Color.LightGray;
        
        // lblOutputPath
        lblOutputPath.AutoSize = true;
        lblOutputPath.Location = new Point(12, 125);
        lblOutputPath.Name = "lblOutputPath";
        lblOutputPath.Size = new Size(102, 20);
        lblOutputPath.TabIndex = 7;
        lblOutputPath.Text = "Output Folder:";
        
        // txtOutputPath
        txtOutputPath.Location = new Point(120, 122);
        txtOutputPath.Name = "txtOutputPath";
        txtOutputPath.Size = new Size(478, 27);
        txtOutputPath.TabIndex = 8;
        
        // btnBrowseOutput
        btnBrowseOutput.Location = new Point(604, 121);
        btnBrowseOutput.Name = "btnBrowseOutput";
        btnBrowseOutput.Size = new Size(75, 29);
        btnBrowseOutput.TabIndex = 9;
        btnBrowseOutput.Text = "Browse";
        btnBrowseOutput.UseVisualStyleBackColor = true;
        btnBrowseOutput.Click += btnBrowseOutput_Click;
        
        // btnProcess
        btnProcess.BackColor = Color.LightGreen;
        btnProcess.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        btnProcess.Location = new Point(12, 190);
        btnProcess.Name = "btnProcess";
        btnProcess.Size = new Size(863, 45);
        btnProcess.TabIndex = 10;
        btnProcess.Text = "Process XML and Copy Images";
        btnProcess.UseVisualStyleBackColor = false;
        btnProcess.Click += btnProcess_Click;
        
        // progressBar
        progressBar.Location = new Point(12, 255);
        progressBar.Name = "progressBar";
        progressBar.Size = new Size(863, 23);
        progressBar.TabIndex = 11;
        
        // lblProgress
        lblProgress.AutoSize = true;
        lblProgress.Location = new Point(12, 290);
        lblProgress.Name = "lblProgress";
        lblProgress.Size = new Size(124, 20);
        lblProgress.TabIndex = 12;
        lblProgress.Text = "Ready to process...";
        
        // lblLog
        lblLog.AutoSize = true;
        lblLog.Location = new Point(12, 325);
        lblLog.Name = "lblLog";
        lblLog.Size = new Size(82, 20);
        lblLog.TabIndex = 13;
        lblLog.Text = "Process Log:";
        
        // txtLog
        txtLog.Font = new Font("Consolas", 9F);
        txtLog.Location = new Point(12, 348);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Both;
        txtLog.Size = new Size(863, 200);
        txtLog.TabIndex = 14;
        txtLog.WordWrap = false;
        
        // lblStats
        lblStats.AutoSize = true;
        lblStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStats.Location = new Point(142, 290);
        lblStats.Name = "lblStats";
        lblStats.Size = new Size(0, 20);
        lblStats.TabIndex = 15;
        
        // openFileDialog
        openFileDialog.Filter = "XML files (*.xml)|*.xml|Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
        
        // folderBrowserDialog
        folderBrowserDialog.Description = "Select output folder";
        
        // Form1
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 570);
        Controls.Add(picImagePreview);
        Controls.Add(lblStats);
        Controls.Add(txtLog);
        Controls.Add(lblLog);
        Controls.Add(lblProgress);
        Controls.Add(progressBar);
        Controls.Add(btnProcess);
        Controls.Add(btnBrowseOutput);
        Controls.Add(txtOutputPath);
        Controls.Add(lblOutputPath);
        Controls.Add(btnBrowseImage);
        Controls.Add(txtImagePath);
        Controls.Add(lblImagePath);
        Controls.Add(btnBrowseXml);
        Controls.Add(txtXmlPath);
        Controls.Add(lblXmlPath);
        Controls.Add(menuStrip);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MainMenuStrip = menuStrip;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "LaunchBox XML Processor - Background Image Manager";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem settingsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    
    private Label lblXmlPath;
    private TextBox txtXmlPath;
    private Button btnBrowseXml;
    private Label lblImagePath;
    private TextBox txtImagePath;
    private Button btnBrowseImage;
    private PictureBox picImagePreview;
    private Label lblOutputPath;
    private TextBox txtOutputPath;
    private Button btnBrowseOutput;
    private Button btnProcess;
    private ProgressBar progressBar;
    private Label lblProgress;
    private TextBox txtLog;
    private Label lblLog;
    private Label lblStats;
    private OpenFileDialog openFileDialog;
    private FolderBrowserDialog folderBrowserDialog;
}
