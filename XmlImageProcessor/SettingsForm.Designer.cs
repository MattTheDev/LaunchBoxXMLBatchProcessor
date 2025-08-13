using System.Drawing;
using System.Windows.Forms;

namespace XmlImageProcessor;

partial class SettingsForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        tabControl = new TabControl();
        tabDefaultPaths = new TabPage();
        tabBehavior = new TabPage();
        
        // Default specific file paths
        lblDefaultXmlPath = new Label();
        txtDefaultXmlPath = new TextBox();
        btnBrowseXmlPath = new Button();
        lblDefaultImagePath = new Label();
        txtDefaultImagePath = new TextBox();
        btnBrowseImagePath = new Button();
        lblDefaultOutputPath = new Label();
        txtDefaultOutputPath = new TextBox();
        btnBrowseOutputPath = new Button();
        
        // Default directories
        lblDefaultXmlDirectory = new Label();
        txtDefaultXmlDirectory = new TextBox();
        btnBrowseXmlDirectory = new Button();
        lblDefaultImageDirectory = new Label();
        txtDefaultImageDirectory = new TextBox();
        btnBrowseImageDirectory = new Button();
        
        // Behavior settings
        chkRememberLastPaths = new CheckBox();
        
        // Buttons
        btnOK = new Button();
        btnCancel = new Button();
        btnReset = new Button();
        
        lblNote = new Label();
        
        SuspendLayout();
        
        // Tab Control
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(8, 8);
        tabControl.Size = new Size(584, 380);
        
        // Default Paths Tab
        tabDefaultPaths.Text = "Default Paths";
        tabDefaultPaths.UseVisualStyleBackColor = true;
        
        // Default XML File Path
        lblDefaultXmlPath.Text = "Default XML File:";
        lblDefaultXmlPath.Location = new Point(10, 15);
        lblDefaultXmlPath.Size = new Size(120, 23);
        
        txtDefaultXmlPath.Location = new Point(140, 12);
        txtDefaultXmlPath.Size = new Size(350, 27);
        
        btnBrowseXmlPath.Text = "Browse";
        btnBrowseXmlPath.Location = new Point(500, 11);
        btnBrowseXmlPath.Size = new Size(75, 29);
        btnBrowseXmlPath.Click += btnBrowseXmlPath_Click;
        
        // Default Image File Path
        lblDefaultImagePath.Text = "Default Image File:";
        lblDefaultImagePath.Location = new Point(10, 55);
        lblDefaultImagePath.Size = new Size(120, 23);
        
        txtDefaultImagePath.Location = new Point(140, 52);
        txtDefaultImagePath.Size = new Size(350, 27);
        
        btnBrowseImagePath.Text = "Browse";
        btnBrowseImagePath.Location = new Point(500, 51);
        btnBrowseImagePath.Size = new Size(75, 29);
        btnBrowseImagePath.Click += btnBrowseImagePath_Click;
        
        // Default Output Path
        lblDefaultOutputPath.Text = "Default Output Folder:";
        lblDefaultOutputPath.Location = new Point(10, 95);
        lblDefaultOutputPath.Size = new Size(120, 23);
        
        txtDefaultOutputPath.Location = new Point(140, 92);
        txtDefaultOutputPath.Size = new Size(350, 27);
        
        btnBrowseOutputPath.Text = "Browse";
        btnBrowseOutputPath.Location = new Point(500, 91);
        btnBrowseOutputPath.Size = new Size(75, 29);
        btnBrowseOutputPath.Click += btnBrowseOutputPath_Click;
        
        // Default XML Directory
        lblDefaultXmlDirectory.Text = "Default XML Directory:";
        lblDefaultXmlDirectory.Location = new Point(10, 145);
        lblDefaultXmlDirectory.Size = new Size(120, 23);
        
        txtDefaultXmlDirectory.Location = new Point(140, 142);
        txtDefaultXmlDirectory.Size = new Size(350, 27);
        
        btnBrowseXmlDirectory.Text = "Browse";
        btnBrowseXmlDirectory.Location = new Point(500, 141);
        btnBrowseXmlDirectory.Size = new Size(75, 29);
        btnBrowseXmlDirectory.Click += btnBrowseXmlDirectory_Click;
        
        // Default Image Directory
        lblDefaultImageDirectory.Text = "Default Image Directory:";
        lblDefaultImageDirectory.Location = new Point(10, 185);
        lblDefaultImageDirectory.Size = new Size(120, 23);
        
        txtDefaultImageDirectory.Location = new Point(140, 182);
        txtDefaultImageDirectory.Size = new Size(350, 27);
        
        btnBrowseImageDirectory.Text = "Browse";
        btnBrowseImageDirectory.Location = new Point(500, 181);
        btnBrowseImageDirectory.Size = new Size(75, 29);
        btnBrowseImageDirectory.Click += btnBrowseImageDirectory_Click;
        
        // Note
        lblNote.Text = "Note: Specific file paths take precedence over directories. Use {USERNAME} placeholder for user-specific paths.";
        lblNote.Location = new Point(10, 230);
        lblNote.Size = new Size(565, 40);
        lblNote.ForeColor = Color.Gray;
        
        // Add controls to Default Paths tab
        tabDefaultPaths.Controls.AddRange(new Control[] {
            lblDefaultXmlPath, txtDefaultXmlPath, btnBrowseXmlPath,
            lblDefaultImagePath, txtDefaultImagePath, btnBrowseImagePath,
            lblDefaultOutputPath, txtDefaultOutputPath, btnBrowseOutputPath,
            lblDefaultXmlDirectory, txtDefaultXmlDirectory, btnBrowseXmlDirectory,
            lblDefaultImageDirectory, txtDefaultImageDirectory, btnBrowseImageDirectory,
            lblNote
        });
        
        // Behavior Tab
        tabBehavior.Text = "Behavior";
        tabBehavior.UseVisualStyleBackColor = true;
        
        // Remember Last Paths
        chkRememberLastPaths.Text = "Remember last used paths";
        chkRememberLastPaths.Location = new Point(10, 15);
        chkRememberLastPaths.Size = new Size(200, 24);
        chkRememberLastPaths.Checked = true;
        
        tabBehavior.Controls.Add(chkRememberLastPaths);
        
        // Add tabs to control
        tabControl.TabPages.Add(tabDefaultPaths);
        tabControl.TabPages.Add(tabBehavior);
        
        // Bottom buttons
        btnOK.Text = "OK";
        btnOK.Location = new Point(350, 400);
        btnOK.Size = new Size(75, 30);
        btnOK.DialogResult = DialogResult.OK;
        btnOK.Click += btnOK_Click;
        
        btnCancel.Text = "Cancel";
        btnCancel.Location = new Point(435, 400);
        btnCancel.Size = new Size(75, 30);
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Click += btnCancel_Click;
        
        btnReset.Text = "Reset";
        btnReset.Location = new Point(10, 400);
        btnReset.Size = new Size(75, 30);
        btnReset.Click += btnReset_Click;
        
        // Form properties
        Text = "Settings - LaunchBox XML Processor";
        Size = new Size(620, 480);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        
        Controls.AddRange(new Control[] { tabControl, btnOK, btnCancel, btnReset });
        
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TabControl tabControl;
    private TabPage tabDefaultPaths;
    private TabPage tabBehavior;
    
    private Label lblDefaultXmlPath;
    private TextBox txtDefaultXmlPath;
    private Button btnBrowseXmlPath;
    private Label lblDefaultImagePath;
    private TextBox txtDefaultImagePath;
    private Button btnBrowseImagePath;
    private Label lblDefaultOutputPath;
    private TextBox txtDefaultOutputPath;
    private Button btnBrowseOutputPath;
    private Label lblDefaultXmlDirectory;
    private TextBox txtDefaultXmlDirectory;
    private Button btnBrowseXmlDirectory;
    private Label lblDefaultImageDirectory;
    private TextBox txtDefaultImageDirectory;
    private Button btnBrowseImageDirectory;
    private Label lblNote;
    
    private CheckBox chkRememberLastPaths;
    
    private Button btnOK;
    private Button btnCancel;
    private Button btnReset;
}