using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            else
            {
                adminText = originalText;
            }
            return adminText;
        }
        }
    }
