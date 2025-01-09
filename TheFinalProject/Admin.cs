using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFinalProject
{
    internal class Admin
    {
        static public bool adminMode = false;

        public static string CreateAdminString(string originalText)
        {
            string adminText = "";
            if (Admin.adminMode == true)
            {
                adminText = "ADMIN MODE\n" + originalText;
            }
            return adminText;
        }
        public static string CreateMenuAdminString(string originalText)
        {
            if (Admin.adminMode == true)
            {
                originalText = "ADMIN MODE\n\n" + originalText + "\n\n\n[5]Exit Admin Mode"; ;
            }
            else if (Admin.adminMode == false)
            {
                originalText += "\n\n\n[5]Enter Admin Mode";
            }
            return originalText;
        }
    }
}
