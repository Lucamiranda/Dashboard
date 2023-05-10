using System.Runtime.InteropServices;
using System.Text;


namespace Dashboard
{
    public class InicializadorINI
    {
        public string path { get; private set;}

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public InicializadorINI(string INIPath)
        {
            path = INIPath;
        }
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
    }
}
