using Newtonsoft.Json;

namespace XmlImageProcessor;

public class AppSettings
{
    public string DefaultXmlPath { get; set; } = "";
    public string DefaultImagePath { get; set; } = "";
    public string DefaultOutputPath { get; set; } = @"C:\temp";
    public string DefaultXmlDirectory { get; set; } = @"C:\Users\{USERNAME}\Downloads";
    public string DefaultImageDirectory { get; set; } = @"C:\Users\{USERNAME}\Downloads";
    public bool RememberLastPaths { get; set; } = true;
    public string LastUsedXmlPath { get; set; } = "";
    public string LastUsedImagePath { get; set; } = "";
    public string LastUsedOutputPath { get; set; } = "";

    private static readonly string ConfigPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "LaunchBoxXmlProcessor",
        "settings.json");

    public static AppSettings Load()
    {
        try
        {
            if (File.Exists(ConfigPath))
            {
                string json = File.ReadAllText(ConfigPath);
                var settings = JsonConvert.DeserializeObject<AppSettings>(json) ?? new AppSettings();
                
                // Replace {USERNAME} placeholder with actual username
                settings.DefaultXmlDirectory = settings.DefaultXmlDirectory.Replace("{USERNAME}", Environment.UserName);
                settings.DefaultImageDirectory = settings.DefaultImageDirectory.Replace("{USERNAME}", Environment.UserName);
                
                return settings;
            }
        }
        catch (Exception ex)
        {
            // If there's an error loading settings, create new ones
            System.Diagnostics.Debug.WriteLine($"Error loading settings: {ex.Message}");
        }

        return new AppSettings();
    }

    public void Save()
    {
        try
        {
            // Create directory if it doesn't exist
            string? directory = Path.GetDirectoryName(ConfigPath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Replace actual username with placeholder for portability
            var settingsToSave = new AppSettings
            {
                DefaultXmlPath = this.DefaultXmlPath,
                DefaultImagePath = this.DefaultImagePath,
                DefaultOutputPath = this.DefaultOutputPath,
                DefaultXmlDirectory = this.DefaultXmlDirectory.Replace(Environment.UserName, "{USERNAME}"),
                DefaultImageDirectory = this.DefaultImageDirectory.Replace(Environment.UserName, "{USERNAME}"),
                RememberLastPaths = this.RememberLastPaths,
                LastUsedXmlPath = this.LastUsedXmlPath,
                LastUsedImagePath = this.LastUsedImagePath,
                LastUsedOutputPath = this.LastUsedOutputPath
            };

            string json = JsonConvert.SerializeObject(settingsToSave, Formatting.Indented);
            File.WriteAllText(ConfigPath, json);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");
        }
    }

    public string GetDefaultXmlPath()
    {
        if (RememberLastPaths && !string.IsNullOrEmpty(LastUsedXmlPath))
            return LastUsedXmlPath;
        
        if (!string.IsNullOrEmpty(DefaultXmlPath))
            return DefaultXmlPath;
            
        return Path.Combine(DefaultXmlDirectory, "*.xml");
    }

    public string GetDefaultImagePath()
    {
        if (RememberLastPaths && !string.IsNullOrEmpty(LastUsedImagePath))
            return LastUsedImagePath;
        
        if (!string.IsNullOrEmpty(DefaultImagePath))
            return DefaultImagePath;
            
        return DefaultImageDirectory;
    }

    public string GetDefaultOutputPath()
    {
        if (RememberLastPaths && !string.IsNullOrEmpty(LastUsedOutputPath))
            return LastUsedOutputPath;
            
        return DefaultOutputPath;
    }
}