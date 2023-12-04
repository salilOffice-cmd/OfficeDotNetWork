using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2.OCT10.Assignments.Assignment2
{
    class FileSizeStorage : IComparable<FileSizeStorage>
    {
        public string fileName { get; set; }

        public double fileSize { get; set; }

        public int CompareTo(FileSizeStorage other)
        {
            if (this.fileSize == other.fileSize) return 0;
            else if (this.fileSize > other.fileSize) return 1;
            else return -1;
        }
    }

    internal class sortFiles
    {
        public static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("D:\\DayUsers\\SalilDeogade\\Official\\ConsoleApp2\\OCT11\\Assignments\\Assignment2");

            List<FileSizeStorage> fileSizeStorages = new List<FileSizeStorage>();

            // Getting the name and size of file and then adding it to dictionary
            foreach (string file in files) {
            
                FileInfo fileInfo = new FileInfo(file);
                double fileSizeInKBs = (double) fileInfo.Length / 1024;

                FileSizeStorage fileSizeStorage = new FileSizeStorage();

                fileSizeStorage.fileName = file;
                fileSizeStorage.fileSize = fileSizeInKBs;
                fileSizeStorages.Add(fileSizeStorage);
            }

            fileSizeStorages.Sort();

            foreach (var item in fileSizeStorages)
            {
                Console.WriteLine($"{item.fileName} : {item.fileSize} Kbs");
            }

        }
    }
}
