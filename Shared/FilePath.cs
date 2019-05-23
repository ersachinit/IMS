using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Shared
{
    public class FilePath
    {
        static string currentPath = AppDomain.CurrentDomain.BaseDirectory;
        static DirectoryInfo parentDir = Directory.GetParent(currentPath.EndsWith("\\") ? currentPath : string.Concat(currentPath, "\\"));
        static string RootPath = parentDir.Parent.FullName;

        public static string GetEmailTemplatesFolderPath
        {
            get { return Path.Combine(RootPath, "Shared", "EmailTemplates", "SignUp.txt"); }
        }

    }
}
