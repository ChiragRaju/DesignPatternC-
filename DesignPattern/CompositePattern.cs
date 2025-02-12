using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{

    // definatiion : 
     //The Composite Design Pattern is a structural pattern that lets you treat individual objects and compositions of objects uniformly. It is useful when working with tree structures where a group of objects should be treated as a single object.

    //design file system

    public interface IFile
    {
        void Display(string indent);
    }

    public class File : IFile
    {
        string _name;
        public File(string name)
        {
            _name = name;
        }
        public void Display(string indent)
        {
            Console.WriteLine(indent+ "-" + _name);
        }
    }

    public class Directory : IFile
    {
        protected List<IFile> _files = new List<IFile>();
        private string _name;
        public Directory(string name)
        {
            _name = name;
        }

        public void AddItem(IFile item)
        {
            _files.Add(item);
        }

        public void Display(string indent)
        {
            foreach (var files in _files)
            {
                files.Display(indent);
            }

        }

        public class CompositePattern
        {

            public static void Main(string[] args)
            {
                // Create files
                IFile file1 = new File("file1.txt");
                IFile file2 = new File("file2.doc");

                // Create folder and add files
                Directory folder1 = new Directory("Documents");
                folder1.AddItem(file1);
                folder1.AddItem(file2);

                // Create another folder with nested structure
                Directory mainFolder = new Directory("Main");
                mainFolder.AddItem(folder1);
                mainFolder.AddItem(new Directory("main.pdf"));

                // Display structure
                mainFolder.Display("");
            }
        }
    }
}


  //      ┌────────────────┐
  //      │ IFileSystemItem │ <── Interface (Component)
  //      └────────────────┘
  //               ▲
  //               │
  //┌──────────────────────────┐
  //│        Folder            │ <── Composite (Can contain files & folders)
  //├──────────────────────────┤
  //│ - string _name           │
  //│ - List<IFileSystemItem>  │
  //│ + AddItem(IFileSystemItem) │
  //│ + Display(indent)        │
  //└──────────────────────────┘
  //               ▲
  //               │
  //┌──────────────────────────┐
  //│        FileItem          │ <── Leaf (Cannot contain anything)
  //├──────────────────────────┤
  //│ - string _name           │
  //│ + Display(indent)        │
  //└──────────────────────────┘
