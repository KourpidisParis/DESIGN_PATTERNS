using System;

namespace DesignPatterns.Structural.CompositePattern
{
    /// <summary>
    /// Demo class to showcase the Composite Pattern
    /// </summary>
    public class Composite
    {
        public static void Run()
        {
            Console.WriteLine("=== Composite Pattern ===");
            Console.WriteLine("Building a file system hierarchy\n");

            try
            {
                // Create files (Leaf nodes)
                File file1 = new File("Resume.pdf", 250);
                File file2 = new File("Photo.jpg", 1500);
                File file3 = new File("Video.mp4", 5000);
                File file4 = new File("Notes.txt", 50);
                File file5 = new File("Presentation.pptx", 3000);

                // Create folders (Composite nodes)
                Folder documentsFolder = new Folder("Documents");
                documentsFolder.Add(file1);
                documentsFolder.Add(file4);

                Folder picturesFolder = new Folder("Pictures");
                picturesFolder.Add(file2);

                Folder videosFolder = new Folder("Videos");
                videosFolder.Add(file3);

                Folder workFolder = new Folder("Work");
                workFolder.Add(file5);

                // Create nested structure
                Folder downloadsFolder = new Folder("Downloads");
                downloadsFolder.Add(documentsFolder);
                downloadsFolder.Add(picturesFolder);

                // Create root folder
                Folder rootFolder = new Folder("Root");
                rootFolder.Add(downloadsFolder);
                rootFolder.Add(videosFolder);
                rootFolder.Add(workFolder);

                // Display the entire structure
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine("File System Structure:");
                Console.WriteLine("═══════════════════════════════════════");
                rootFolder.ShowDetails();

                // Calculate total size
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine($"Total Size: {rootFolder.GetSize()} KB");
                Console.WriteLine("═══════════════════════════════════════");

                // Show individual folder sizes
                Console.WriteLine("\n═══════════════════════════════════════");
                Console.WriteLine("Individual Folder Sizes:");
                Console.WriteLine("═══════════════════════════════════════");
                Console.WriteLine($"Downloads folder: {downloadsFolder.GetSize()} KB");
                Console.WriteLine($"Videos folder: {videosFolder.GetSize()} KB");
                Console.WriteLine($"Work folder: {workFolder.GetSize()} KB");

                // Key Points
                Console.WriteLine("\n\n=== Key Points ===");
                Console.WriteLine("1. Files (Leaf) and Folders (Composite) both implement IFileSystemComponent");
                Console.WriteLine("2. Folders can contain both files AND other folders (recursive structure)");
                Console.WriteLine("3. Client treats files and folders uniformly - no need to check types");
                Console.WriteLine("4. Operations like ShowDetails() and GetSize() work on entire tree");
                Console.WriteLine("5. Easy to add new file types or folder types without changing existing code");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}