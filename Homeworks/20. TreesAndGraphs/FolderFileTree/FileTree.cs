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
   static class FileTree 
    {
        static void Main(string[] args)
        {
            string path = @"T:\02. Fundamentals";
           new Folder(path);


     
        }
  

  

    }

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public bool HasParent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

    }

    public class File
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

   public class Folder
    {
        public List<File> Files  { get; set; }
        public string Name { get; set; }
        public List<Folder> ChildFolders { get; set; }
        public Folder Parent { get; set; }



        public Folder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FillFoldersAndFiles(dir);
        }

        public Folder()
        {
            this.ChildFolders = new List<Folder>();
            this.Files = new List<File>();
        }

        private void FillFoldersAndFiles(DirectoryInfo dir)
        {
            this.Name = dir.Name;
            this.ChildFolders = dir.GetFolders();
            this.Files = dir.GetLFilesList();

            foreach (Folder folder in this.ChildFolders)
            {
                Console.WriteLine(folder.Name);
            }


            foreach (File file in this.Files)
            {
                Console.WriteLine(file.Name);
            }

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                FillFoldersAndFiles(d);
            }
   

         
        }


    }
}