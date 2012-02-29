using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderFileTree
{
    //Define classes File { string name, int size }
    //and Folder { string name, File[] files, Folder[]
    //childFolders } and using them build a tree keeping 
    //all files and folders on the hard drive starting from 
    //C:\WINDOWS. Implement a method that calculates the sum
    //of the file sizes in given subtree of the tree and test 
    //it accordingly. Use recursive DFS traversal.
    class FileTree
    {
        static void Main(string[] args)
        {
            string path = @"T:\07. Ruby\Emo\PeepCode";
            Folder folder = new Folder(path);

            PrintContents(folder);
        }
  
        private static void PrintContents(Folder folder)
        {
            foreach(Folder d in folder.ChildFolders){
            	
                foreach(File f in d.Files){
                    Console.WriteLine(f.Name);
                }
            }
        }
  




    }

    class File
    {
        public string Name { get; set; }
        public long Size { get; set; }
        
        public File(string name)
        {
            this.Name = name;
        }

        public File()
        {
        }

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }
    }

    class Folder
    {
        public List<File> Files  { get; set; }
        public string Name { get; set; }
        public List<Folder> ChildFolders { get; set; }

        public Folder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            this.Name = dir.Name;

            FillFoldersAndFiles(dir);
        }



        public Folder()
        {
            this.ChildFolders = new List<Folder>();
            this.Files = new List<File>();
        }

        private void FillFoldersAndFiles(DirectoryInfo dir)
        {
            //List<Folder> folders = new List<Folder>
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                Folder folder = new Folder();
                folder.ChildFolders = new List<Folder>();
                folder.Name = d.Name;

                foreach (FileInfo f in d.GetFiles())
                {
                    if(f.Name != null && f.Length != null)
                    folder.Files.Add(new File(f.Name, f.Length));
                }
                folder.ChildFolders.Add(folder);
                FillFoldersAndFiles(d);
            }
        }
    }
}