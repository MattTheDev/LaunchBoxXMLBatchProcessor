using System.Windows.Forms;

namespace XmlImageProcessor;

public partial class SettingsForm : Form
{
    private AppSettings settings;
    
    public SettingsForm(AppSettings appSettings)
    {
        InitializeComponent();
        settings = appSettings;
        LoadSettings();
    }

    private void LoadSettings()
    {
        txtDefaultXmlPath.Text = settings.DefaultXmlPath;
        txtDefaultImagePath.Text = settings.DefaultImagePath;
        txtDefaultOutputPath.Text = settings.DefaultOutputPath;
        txtDefaultXmlDirectory.Text = settings.DefaultXmlDirectory;
        txtDefaultImageDirectory.Text = settings.DefaultImageDirectory;
        chkRememberLastPaths.Checked = settings.RememberLastPaths;
    }

    private void SaveSettings()
    {
        settings.DefaultXmlPath = txtDefaultXmlPath.Text;
        settings.DefaultImagePath = txtDefaultImagePath.Text;
        settings.DefaultOutputPath = txtDefaultOutputPath.Text;
        settings.DefaultXmlDirectory = txtDefaultXmlDirectory.Text;
        settings.DefaultImageDirectory = txtDefaultImageDirectory.Text;
        settings.RememberLastPaths = chkRememberLastPaths.Checked;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        SaveSettings();
        settings.Save();
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void btnBrowseXmlPath_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog
        {
            Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*",
            Title = "Select Default XML File"
        };
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtDefaultXmlPath.Text = openFileDialog.FileName;
        }
    }

    private void btnBrowseImagePath_Click(object sender, EventArgs e)
    {
        using var openFileDialog = new OpenFileDialog
        {
            Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*",
            Title = "Select Default Image File"
        };
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtDefaultImagePath.Text = openFileDialog.FileName;
        }
    }

    private void btnBrowseOutputPath_Click(object sender, EventArgs e)
    {
        using var folderBrowserDialog = new FolderBrowserDialog
        {
            Description = "Select Default Output Folder"
        };
        
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            txtDefaultOutputPath.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void btnBrowseXmlDirectory_Click(object sender, EventArgs e)
    {
        using var folderBrowserDialog = new FolderBrowserDialog
        {
            Description = "Select Default XML Directory"
        };
        
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            txtDefaultXmlDirectory.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void btnBrowseImageDirectory_Click(object sender, EventArgs e)
    {
        using var folderBrowserDialog = new FolderBrowserDialog
        {
            Description = "Select Default Image Directory"
        };
        
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            txtDefaultImageDirectory.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Reset all settings to defaults?", "Confirm Reset", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            settings = new AppSettings();
            LoadSettings();
        }
    }
}