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
        //A static bool to check if we have adminMode on or not
        static public bool adminMode = false;

        //Returns passed strings with a "ADMIN MODE" added to them so you have a visual
        //that you are still in adminMode.
        public static string CreateAdminString(string originalText)
        {
            string adminText = "";
            if (adminMode == true)
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
