using System.IO;
//using System.Reflection; //only needed for GetDirectoryName
using System.Diagnostics;

namespace FileCheck {
    class TOFiles {
        //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //Directory.GetCurrentDirectory();
        //

        private string _dir_path;

        public void Test()
        {
            //_dir_path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //tower-offense\bin\Debug\net6.0-windows
            //Debug.WriteLine("DirectoryName: " + _dir_path);

            //main folder path
            _dir_path = Directory.GetCurrentDirectory(); //tower-offense
            var target_path = "Test";
            _dir_path = Path.Combine(_dir_path, target_path);
            Debug.WriteLine("CurrentDirectory: " + _dir_path);
        }
    }
}