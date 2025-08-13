# LaunchBox XML Processor

A Windows utility for batch processing LaunchBox XML files to copy background images and update metadata.

## Features

- **Batch Image Processing**: Copy a source image to multiple games that don't have background images
- **XML Metadata Updates**: Automatically updates `BackgroundImageDownloaded` flags to `true`
- **Settings Management**: Remember last used paths and configure default directories
- **Progress Tracking**: Real-time progress updates with detailed logging
- **Platform Support**: Processes LaunchBox platform XML files

## Requirements

- .NET 9.0 or later
- Windows operating system
- LaunchBox XML files

## Usage

1. **Select XML File**: Choose your LaunchBox platform XML file
2. **Select Source Image**: Pick the background image you want to copy to games
3. **Choose Output Folder**: Select where processed files will be saved
4. **Process**: Click "Process XML and Copy Images" to start batch processing

The application will:
- Create a directory structure based on the platform name
- Copy the source image for each game missing a background image
- Update the XML to mark background images as downloaded
- Save the modified XML file

## Configuration

Access settings via the File menu to configure:
- Default directories for XML files, images, and output
- Whether to remember last used paths
- File path preferences

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Feel free to submit issues, feature requests, or pull requests.

## About

LaunchBox XML Processor v1.0  
A utility for managing LaunchBox game metadata and background images.

---

**Please give credit if you use this software in your projects!**
