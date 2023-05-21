using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stomatology.BD
{
    public partial class Uslugi
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
        public string Stoimost
        {
            get
            {

                    return $"{Stoimost_Uslugi:N2} рублей";
            }
        }


    }
}
