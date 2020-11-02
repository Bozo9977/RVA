using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVAProjekat
{
    public class CurrentUser 
    {

        private static User instance = null;

        private CurrentUser()
        {
        }

        public static User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new User();
                }
                return instance;
            }
            set
            {
                if (instance == null)
                {
                    instance = value;
                }
                else
                {
                    instance = null;
                }
            }
        }

    }
}
