using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileSysWatcher
{
    internal class Program
    {
        static string path = @"C:\Users\shifa\Desktop\test";
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
            //dataTable.Columns[i].ColumnName = "SubjectMarks";
            var reader = new System.IO.StreamReader(e.FullPath, System.Text.Encoding.UTF8);
            var text = reader.ReadToEnd();

            var fileData = new CustomFileInputModel()
            {
                Name = e.Name,
                FileData = text,
                DocTypeId = 17,
                Type = e.GetType().ToString()
        };

            var excel = new ExcelInputModel();
            excel.TenantId = 2;
            excel.BranchId = 2;
            excel.HrConfigId = 2;
            
            excel.CustomFile = fileData;


            _ = CallWebAPIAsync(excel);

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


        private static async Task CallWebAPIAsync(ExcelInputModel data)
        {

            //var token = GetToken();

           



            //var student = "{'Id':'1','Name':'Steve'}";

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            
            string strJson = JsonSerializer.Serialize<ExcelInputModel>(data, opt);



            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44317/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsync("api/HrAttendanceTest/ImportAttendanceAsync", new StringContent(strJson, Encoding.UTF8, "application/json"));
           
            if (response != null)
            {
                Console.WriteLine(response.ToString());
            }
        }

        private async static Task<string> GetToken()
        {
            try
            {
                var body = $"username =manager@demo.com&password=admin123##&grant_type=password";

                HttpClient loginCall = new HttpClient();
                loginCall.BaseAddress = new Uri("http://localhost:44317/");

                var token = await loginCall.PostAsync("token", new StringContent(body, Encoding.UTF8, "application/json"));
                if (token != null)
                {
                    Console.WriteLine(token.ToString());
                }

                return "token";

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
