using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

//Write a program to traverse the 
//directory C:\WINDOWS and all its 
//subdirectories recursively and to 
//display all files matching the mask *.exe. 
//Use the class System.IO.Directory. 

class TraverseDir
{
    static void Main(string[] args)
    {
        TraverseDirDFS(new DirectoryInfo(@"T:\"));
    }
  
    private static void TraverseDirDFS(DirectoryInfo dir)
    {
        DirectoryInfo[] dirs = dir.GetDirectories();


        foreach (DirectoryInfo d in dirs)
        {
            foreach (var e in d.GetFiles())
            {
                if (e.Extension == ".exe")
                    Console.WriteLine(e.Name);
            }
            TraverseDirDFS(d);
        }
    }
}