using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stomatology.BD
{
    public partial class User
    {
        public string AdminControlsVisibility
        {
            get
            {
                if (App.CurrentUser.RoleId == 1)
                {

                    return "Visible";

                }
                else
                {
                    return "Collapsed";
                }

            }

        }
       
    }
}
