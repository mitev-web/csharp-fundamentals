using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderFileTree
{
   public static class ExtensionMethods
    {
       public static List<Folder> GetFolders(this DirectoryInfo dir)
       {
           List<Folder> folders = new List<Folder>();
           foreach (DirectoryInfo d in dir.GetDirectories())
           {
               Folder f = new Folder();
               f.Parent = new Folder();
               f.Parent.Name = dir.Name;

               f.Name = d.Name;
               folders.Add(f);
           }
           return folders;
       }


       public static List<File> GetLFilesList(this DirectoryInfo dir)
       {
           List<File> files = new List<File>();
           foreach (FileInfo f in dir.GetFiles())
           {
               File file = new File();

               file.Name = f.Name;
               files.Add(file);
           }
           return files;
       }
    }
}
