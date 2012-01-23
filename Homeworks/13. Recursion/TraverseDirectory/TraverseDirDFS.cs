using System;
using System.IO;

public static class DirectoryTraverserDFS
{
    public static void Main()
    {
        string directoryPath = @"C:\Windows";
        TraverseDir(new DirectoryInfo(directoryPath));
    }

    private static void TraverseDir(DirectoryInfo dir)
    {
        Console.WriteLine(dir.FullName);

        DirectoryInfo[] children = dir.GetDirectories();

        foreach (DirectoryInfo child in children)
        {
            TraverseDir(child);
        }
    }
}