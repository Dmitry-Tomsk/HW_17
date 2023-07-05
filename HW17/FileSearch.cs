using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17
{
    public class FileSearch
    {
        delegate void FileFoundInfo(FileArgs fileArgs);
        event FileFoundInfo FileFoundInfoEvent;
        public FileSearch()
        {
            FileFoundInfoEvent += FileFoundEventHandler;
        }
        public void scanCatalog(string path) 
        {
            if (Directory.Exists(path))
            {
                string[] folders = Directory.GetDirectories(path);
                foreach (string folder in folders)
                {
                    FileInfo fileInfo = new FileInfo(folder);
                    Console.WriteLine("Папка: '" + fileInfo.Name + "'");
                    scanCatalog(folder);
                }
                string[] files = Directory.GetFiles(path);
                foreach (string filename in files)
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    FileFoundInfoEvent?.Invoke(new FileArgs { fileInfoFound = fileInfo });
                }
            }
        }
        private void FileFoundEventHandler(FileArgs fileArgs)
        {
            Console.WriteLine($"Файл: '{fileArgs.fileInfoFound.Name}'");
        }
    }

    internal class FileArgs : EventArgs
    {
        public FileInfo fileInfoFound;
    }
}
