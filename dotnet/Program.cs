using System;
using System.Diagnostics;
using System.IO;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Path.GetDirectoryName((Directory.GetCurrentDirectory()));
            string nfsFile = Path.Join(workingDirectory, "nfs-mount/testfile");
            string nfsFolder = Path.Join(workingDirectory, "nfs-mount/testfolder");
            string localFile = Path.Join(workingDirectory, "non-nfs-mount/testfile");
            byte[] dummyData = new byte[10 * 1024 * 1024]; // 10 MB data
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            File.Move(localFile, nfsFile);
            stopwatch.Stop();

            Console.WriteLine("From local to NFS: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            File.Move(nfsFile, localFile);
            stopwatch.Stop();

            Console.WriteLine("From NFS to local: " + stopwatch.ElapsedMilliseconds);


            stopwatch.Restart();
            Directory.CreateDirectory(nfsFolder);
            stopwatch.Stop();

            Console.WriteLine("Time to create folder: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            Directory.Delete(nfsFolder);
            stopwatch.Stop();

            Console.WriteLine("Time to delete folder: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            File.WriteAllBytes(nfsFile, dummyData);
            stopwatch.Stop();

            Console.WriteLine("Time to create 10MB file: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            byte[] data = File.ReadAllBytes(nfsFile);
            stopwatch.Stop();

            Console.WriteLine("Time to read 10MB file: " + stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();
            File.Delete(nfsFile);
            stopwatch.Stop();

            Console.WriteLine("Time to delete 10MB file: " + stopwatch.ElapsedMilliseconds);
        }
    }
}
