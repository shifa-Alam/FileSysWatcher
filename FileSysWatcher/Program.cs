using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileSysWatcher
{
    internal class Program
    {
        static string path = @"C:\Users\test\Desktop\test";
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
          
            MonitorDirectory(path);
            Console.ReadKey();
        }
        private static void MonitorDirectory(string path)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.EnableRaisingEvents = true;


        }

      

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {

            var excel = new ExcelInputModel();

            //excel.CustomFile.Name = e.Name;
            //excel.CustomFile.Size = e.Siz;
            //File.Move(e.FullPath, path+"\\x\\"+e.Name);
            _ = CallWebAPIAsync(e.FullPath);

            Console.WriteLine("File Created :{0}", e.Name);
        }
        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File Renamed :{0}", e.Name);
        }
       
        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File Deleted :{0}", e.Name);
        }


        private static  async Task CallWebAPIAsync(string path)
        {
            var student = "{'Id':'1','Name':'Steve'}";

           

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44317/");
            var response = await client.PostAsync("api/HrAttendanceTest/ImportAttendanceAsync", new StringContent(student, Encoding.UTF8, "application/json"));
            if (response != null)
            {
                Console.WriteLine(response.ToString());
            }
        }
    }
}
