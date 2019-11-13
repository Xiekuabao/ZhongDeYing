using System;
using System.Data;

namespace MicosoftAccessAPI
{
    public class AccessFile:DataTable
    {
        public string m_FilePath { get; private set; }
        private string m_password;
        public AccessFile(string FilePath,string Password)
        {
            m_FilePath = FilePath;
            m_password = Password;
            //this=
        }
    }
}
