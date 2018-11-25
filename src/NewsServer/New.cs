using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsServer
{
    class New
    {
        public string id;
        public string header;
        public string href;
        public string hrefType;

        public New(string s)
        {
            string[] param = s.Split(','); 
            if(param.Length >= 4)
            {
                id = param[0];
                header = param[1];
                href = param[2];
                hrefType = param[3];
            }
        }
    }
}
