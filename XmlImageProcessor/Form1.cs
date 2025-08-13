using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;

namespace XmlImageProcessor;

public partial class Form1 : Form
{
    private AppSettings settings;
    private bool isInitializing = true;

    public Form1()
    {
        InitializeComponent();
        settings = AppSettings.Load();
        InitializeImagePreview();
        LoadDefaultPaths();
        isInitializing = false;
    }

    private void InitializeImagePreview()
    {
        // Set up the image preview with a placeholder
        picImagePreview.Image = null;
        picImagePreview.BackColor = Color.LightGray;
        
        // Add a context menu for the preview
        var contextMenu = new ContextMenuStrip();
        
        var refreshItem = new ToolStripMenuItem("Refresh Preview");
        refreshItem.Click += (s, e) => RefreshImagePreview();
        contextMenu.Items.Add(refreshItem);
        
        var clearItem = new ToolStripMenuItem("Clear Preview");
        clearItem.Click += (s, e) => ClearImagePreview();
        contextMenu.Items.Add(clearItem);
        
        picImagePreview.ContextMenuStrip = contextMenu;
    }

    private void LoadDefaultPaths()
    {
        // Load default paths from settings
        string defaultXml = settings.GetDefaultXmlPath();
        string defaultImage = settings.GetDefaultImagePath();
        string defaultOutput = settings.GetDefaultOutputPath();

        // Set default values if they exist and are valid
        if (!string.IsNullOrEmpty(defaultXml) && File.Exists(defaultXml))
        {
            txtXmlPath.Text = defaultXml;
        }
        else if (!string.IsNullOrEmpty(settings.DefaultXmlDirectory) && Directory.Exists(settings.DefaultXmlDirectory))
        {
            txtXmlPath.Text = settings.DefaultXmlDirectory;
        }

        if (!string.IsNullOrEmpty(defaultImage) && File.Exists(defaultImage))
        {
            txtImagePath.Text = defaultImage;
            // Load image preview after the control is fully initialized
            LoadImagePreview(defaultImage);
        }
        else if (!string.IsNullOrEmpty(settings.DefaultImageDirectory) && Directory.Exists(settings.DefaultImageDirectory))
        {
            txtImagePath.Text = settings.DefaultImageDirectory;
        }

        if (!string.IsNullOrEmpty(defaultOutput) && Directory.Exists(defaultOutput))
        {
            txtOutputPath.Text = defaultOutput;
        }
    }

    private void SaveLastUsedPaths()
    {
        if (settings.RememberLastPaths)
        {
            settings.LastUsedXmlPath = txtXmlPath.Text;
            settings.LastUsedImagePath = txtImagePath.Text;
            settings.LastUsedOutputPath = txtOutputPath.Text;
            settings.Save();
        }
    }

    private void txtImagePath_TextChanged(object sender, EventArgs e)
    {
        // Skip during initialization to prevent conflicts
        if (isInitializing) return;
        
        // Update preview when text changes (useful for manual entry)
        string imagePath = txtImagePath.Text;
        if (File.Exists(imagePath) && IsImageFile(imagePath))
        {
            LoadImagePreview(imagePath);
        }
        else
        {
            ClearImagePreview();
        }
    }

    private void LoadImagePreview(string imagePath)
    {
        try
        {
            // Ensure the control is available
            if (picImagePreview == null) return;
            
            // Dispose of the previous image to free memory
            if (picImagePreview.Image != null)
            {
                picImagePreview.Image.Dispose();
                picImagePreview.Image = null;
            }

            // Load the new image
            using (var originalImage = Image.FromFile(imagePath))
            {
                // Create a copy to avoid file locking issues
                picImagePreview.Image = new Bitmap(originalImage);
            }

            // Update tooltip with image information
            var fileInfo = new FileInfo(imagePath);
            string tooltip = $"File: {Path.GetFileName(imagePath)}\n" +
                           $"Size: {fileInfo.Length / 1024} KB\n" +
                           $"Dimensions: {picImagePreview.Image.Width} x {picImagePreview.Image.Height}";
            
            var toolTip = new ToolTip();
            toolTip.SetToolTip(picImagePreview, tooltip);
            
            // Log successful load for debugging
            if (!isInitializing)
            {
                LogMessage($"Image preview loaded: {Path.GetFileName(imagePath)}");
            }
        }
        catch (Exception ex)
        {
            // If image can't be loaded, show error and clear preview
            ClearImagePreview();
            if (!isInitializing)
            {
                LogMessage($"Warning: Could not load image preview for '{imagePath}': {ex.Message}");
            }
        }
    }

    private void RefreshImagePreview()
    {
        // Method to force refresh the image preview
        string imagePath = txtImagePath.Text;
        if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath) && IsImageFile(imagePath))
        {
            LoadImagePreview(imagePath);
        }
        else
        {
            ClearImagePreview();
        }
    }

    private void ClearImagePreview()
    {
        if (picImagePreview?.Image != null)
        {
            picImagePreview.Image.Dispose();
            picImagePreview.Image = null;
        }
        
        if (picImagePreview != null)
        {
            picImagePreview.BackColor = Color.LightGray;
            
            // Clear tooltip
            var toolTip = new ToolTip();
            toolTip.SetToolTip(picImagePreview, "No image selected");
        }
    }

    private bool IsImageFile(string filePath)
    {
        string[] supportedExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff" };
        string extension = Path.GetExtension(filePath).ToLowerInvariant();
        return supportedExtensions.Contains(extension);
    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var settingsForm = new SettingsForm(settings);
        if (settingsForm.ShowDialog() == DialogResult.OK)
        {
            // Reload settings and update UI
            settings = AppSettings.Load();
            isInitializing = true;
            LoadDefaultPaths();
            isInitializing = false;
        }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        SaveLastUsedPaths();
        Application.Exit();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string aboutText = "LaunchBox XML Processor\n" +
                          "Background Image Manager\n\n" +
                          "Version 1.0\n\n" +
                          "A utility for batch processing LaunchBox XML files\n" +
                          "to copy background images and update metadata.\n\n" +
                          "Open Source - Available on GitHub";
        
        MessageBox.Show(aboutText, "About LaunchBox XML Processor", 
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnBrowseXml_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
        openFileDialog.Title = "Select XML File";
        
        // Set initial directory from settings
        if (!string.IsNullOrEmpty(settings.DefaultXmlDirectory) && Directory.Exists(settings.DefaultXmlDirectory))
        {
            openFileDialog.InitialDirectory = settings.DefaultXmlDirectory;
        }
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtXmlPath.Text = openFileDialog.FileName;
        }
    }

    private void btnBrowseImage_Click(object sender, EventArgs e)
    {
        openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
        openFileDialog.Title = "Select Source Image";
        
        // Set initial directory from settings
        if (!string.IsNullOrEmpty(settings.DefaultImageDirectory) && Directory.Exists(settings.DefaultImageDirectory))
        {
            openFileDialog.InitialDirectory = settings.DefaultImageDirectory;
        }
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            txtImagePath.Text = openFileDialog.FileName;
            // Ensure the preview is loaded immediately
            LoadImagePreview(openFileDialog.FileName);
        }
    }

    private void btnBrowseOutput_Click(object sender, EventArgs e)
    {
        folderBrowserDialog.Description = "Select Output Folder";
        
        // Set initial directory from settings
        if (!string.IsNullOrEmpty(settings.DefaultOutputPath) && Directory.Exists(settings.DefaultOutputPath))
        {
            folderBrowserDialog.SelectedPath = settings.DefaultOutputPath;
        }
        
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            txtOutputPath.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private async void btnProcess_Click(object sender, EventArgs e)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(txtXmlPath.Text) || !File.Exists(txtXmlPath.Text))
        {
            MessageBox.Show("Please select a valid XML file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtImagePath.Text) || !File.Exists(txtImagePath.Text))
        {
            MessageBox.Show("Please select a valid source image file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtOutputPath.Text))
        {
            MessageBox.Show("Please select an output folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Save last used paths
        SaveLastUsedPaths();

        // Disable the process button during processing
        btnProcess.Enabled = false;
        btnProcess.Text = "Processing...";
        progressBar.Value = 0;
        txtLog.Clear();

        try
        {
            await ProcessXmlAsync();
        }
        catch (Exception ex)
        {
            LogMessage($"Error: {ex.Message}");
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // Re-enable the process button
            btnProcess.Enabled = true;
            btnProcess.Text = "Process XML and Copy Images";
        }
    }

    private async Task ProcessXmlAsync()
    {
        string xmlFilePath = txtXmlPath.Text;
        string sourceImagePath = txtImagePath.Text;
        string outputBasePath = txtOutputPath.Text;

        LogMessage($"Loading XML file: {xmlFilePath}");
        
        // Load the XML document
        XDocument doc = XDocument.Load(xmlFilePath);
        
        // Get platform information
        var platformElement = doc.Descendants("Platform").FirstOrDefault();
        string platformName = platformElement?.Element("Name")?.Value ?? "Unknown Platform";
        
        LogMessage($"Platform: {platformName}");
        
        // Create output directory structure
        string outputBaseDir = Path.Combine(outputBasePath, platformName);
        string imagesDir = Path.Combine(outputBaseDir, "images");
        
        LogMessage($"Creating directory structure: {outputBaseDir}");
        Directory.CreateDirectory(imagesDir);
        
        // Parse all Game elements into Game objects and track XML elements for modification
        var gameElements = doc.Descendants("Game").ToList();
        var allGames = gameElements
            .Select(gameElement => new Game
            {
                Title = gameElement.Element("Title")?.Value ?? "Unknown Title",
                Platform = gameElement.Element("Platform")?.Value ?? "Unknown Platform",
                Developer = gameElement.Element("Developer")?.Value ?? "Unknown Developer",
                Publisher = gameElement.Element("Publisher")?.Value ?? "Unknown Publisher",
                ApplicationPath = gameElement.Element("ApplicationPath")?.Value ?? "Unknown Path",
                Id = gameElement.Element("ID")?.Value ?? "Unknown ID",
                ReleaseDate = gameElement.Element("ReleaseDate")?.Value ?? "Unknown Date",
                BackgroundImageDownloaded = bool.TryParse(gameElement.Element("BackgroundImageDownloaded")?.Value, out bool bgResult) && bgResult,
                BoxFrontImageDownloaded = bool.TryParse(gameElement.Element("BoxFrontImageDownloaded")?.Value, out bool boxResult) && boxResult,
                ClearLogoImageDownloaded = bool.TryParse(gameElement.Element("ClearLogoImageDownloaded")?.Value, out bool logoResult) && logoResult,
                ScreenshotGameTitleImageDownloaded = bool.TryParse(gameElement.Element("ScreenshotGameTitleImageDownloaded")?.Value, out bool titleResult) && titleResult,
                ScreenshotGameplayImageDownloaded = bool.TryParse(gameElement.Element("ScreenshotGameplayImageDownloaded")?.Value, out bool gameplayResult) && gameplayResult,
                VideoDownloaded = bool.TryParse(gameElement.Element("VideoDownloaded")?.Value, out bool videoResult) && videoResult,
                Notes = gameElement.Element("Notes")?.Value ?? "",
                XmlElement = gameElement // Store reference to XML element for modification
            })
            .ToList();
        
        // Filter games where BackgroundImageDownloaded is false
        var gamesWithoutBackground = allGames.Where(game => !game.BackgroundImageDownloaded).ToList();
        
        LogMessage($"Parsed {allGames.Count} total games from XML");
        LogMessage($"Found {gamesWithoutBackground.Count} games where BackgroundImageDownloaded is FALSE");
        LogMessage("Starting image copying and XML modification process...");
        LogMessage("");

        // Update stats
        lblStats.Text = $"Processing {gamesWithoutBackground.Count} games...";
        
        // Setup progress bar
        progressBar.Maximum = gamesWithoutBackground.Count;
        progressBar.Value = 0;
        
        // Process each game without background image
        int processedCount = 0;
        foreach (var game in gamesWithoutBackground)
        {
            try
            {
                // Sanitize the game title for use as filename
                string sanitizedTitle = SanitizeFileName(game.Title);
                string targetImagePath = Path.Combine(imagesDir, $"{sanitizedTitle}.jpg");
                
                // Copy the source image to target location
                File.Copy(sourceImagePath, targetImagePath, overwrite: true);
                
                // Update the XML element to set BackgroundImageDownloaded to true
                var bgElement = game.XmlElement?.Element("BackgroundImageDownloaded");
                if (bgElement != null)
                {
                    bgElement.Value = "true";
                }
                
                processedCount++;
                
                // Update progress
                progressBar.Value = processedCount;
                lblProgress.Text = $"Processed {processedCount}/{gamesWithoutBackground.Count}: {game.Title}";
                
                // Log every 50th item to avoid too much spam, or log all for smaller sets
                if (gamesWithoutBackground.Count <= 100 || processedCount % 50 == 0 || processedCount == gamesWithoutBackground.Count)
                {
                    LogMessage($"Processed {processedCount}/{gamesWithoutBackground.Count}: {game.Title} -> {sanitizedTitle}.jpg");
                }
                
                // Allow UI to update
                Application.DoEvents();
                
                // Small delay to make progress visible
                if (processedCount % 10 == 0)
                {
                    await Task.Delay(1);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error processing game '{game.Title}': {ex.Message}");
            }
        }
        
        // Save the modified XML to the output directory
        string outputXmlPath = Path.Combine(outputBaseDir, $"{platformName}.xml");
        LogMessage("");
        LogMessage($"Saving modified XML to: {outputXmlPath}");
        doc.Save(outputXmlPath);
        
        // Final summary
        LogMessage("");
        LogMessage("=== PROCESSING COMPLETE ===");
        LogMessage($"Total games processed: {processedCount}");
        LogMessage($"Images copied to: {imagesDir}");
        LogMessage($"Modified XML saved to: {outputXmlPath}");
        LogMessage($"All BackgroundImageDownloaded flags updated to 'true'");
        
        // Update final stats
        lblProgress.Text = "Processing complete!";
        lblStats.Text = $"Successfully processed {processedCount} games!";
        
        // Show completion message
        MessageBox.Show(
            $"Processing complete!\n\n" +
            $"Games processed: {processedCount}\n" +
            $"Images copied to: {imagesDir}\n" +
            $"Modified XML saved to: {outputXmlPath}",
            "Success",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void LogMessage(string message)
    {
        if (txtLog.InvokeRequired)
        {
            txtLog.Invoke(new Action<string>(LogMessage), message);
            return;
        }

        txtLog.AppendText(message + Environment.NewLine);
        txtLog.SelectionStart = txtLog.Text.Length;
        txtLog.ScrollToCaret();
    }

    // Helper method to sanitize filenames
    private static string SanitizeFileName(string fileName)
    {
        // Remove or replace invalid characters for Windows file names
        string invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        string sanitized = Regex.Replace(fileName, $"[{Regex.Escape(invalidChars)}]", "_");
        
        // Also replace some common problematic characters
        sanitized = sanitized.Replace(":", "_")
                            .Replace("*", "_")
                            .Replace("?", "_")
                            .Replace("\"", "_")
                            .Replace("<", "_")
                            .Replace(">", "_")
                            .Replace("|", "_")
                            .Replace("/", "_")
                            .Replace("\\", "_");
        
        // Trim whitespace and periods from start/end
        sanitized = sanitized.Trim().Trim('.');
        
        // Ensure it's not empty
        if (string.IsNullOrWhiteSpace(sanitized))
        {
            sanitized = "Unknown_Game";
        }
        
        // Limit length to avoid path length issues
        if (sanitized.Length > 100)
        {
            sanitized = sanitized.Substring(0, 100).Trim();
        }
        
        return sanitized;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        SaveLastUsedPaths();
        
        // Clean up image resources
        if (picImagePreview.Image != null)
        {
            picImagePreview.Image.Dispose();
            picImagePreview.Image = null;
        }
        
        base.OnFormClosing(e);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        
        // Ensure the default image preview is loaded after the form is fully loaded
        // This handles cases where the image wasn't loaded during constructor
        if (!string.IsNullOrEmpty(txtImagePath.Text) && File.Exists(txtImagePath.Text) && IsImageFile(txtImagePath.Text))
        {
            // Use a small delay to ensure everything is rendered
            this.BeginInvoke(new Action(() => {
                LoadImagePreview(txtImagePath.Text);
            }));
        }
    }
}

// Game class to represent parsed game data
public class Game
{
    public string Title { get; set; } = "";
    public string Platform { get; set; } = "";
    public string Developer { get; set; } = "";
    public string Publisher { get; set; } = "";
    public string ApplicationPath { get; set; } = "";
    public string Id { get; set; } = "";
    public string ReleaseDate { get; set; } = "";
    public bool BackgroundImageDownloaded { get; set; }
    public bool BoxFrontImageDownloaded { get; set; }
    public bool ClearLogoImageDownloaded { get; set; }
    public bool ScreenshotGameTitleImageDownloaded { get; set; }
    public bool ScreenshotGameplayImageDownloaded { get; set; }
    public bool VideoDownloaded { get; set; }
    public string Notes { get; set; } = "";
    public XElement? XmlElement { get; set; } // Reference to original XML element for modification
    
    public override string ToString()
    {
        return $"Title: {Title}\n" +
               $"Platform: {Platform}\n" +
               $"Developer: {Developer}\n" +
               $"Publisher: {Publisher}\n" +
               $"Application Path: {ApplicationPath}\n" +
               $"ID: {Id}\n" +
               $"Release Date: {ReleaseDate}\n" +
               $"Background Image Downloaded: {BackgroundImageDownloaded}\n";
    }
}
