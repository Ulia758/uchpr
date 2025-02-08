using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UchPractika.AppData
{
    internal class Connect
    {
        public static AISUchetEntities1 c;
        public static AISUchetEntities1 context
        {
            get
            {
                if (c == null)
                    c = new AISUchetEntities1();
                return c;
            }
        }
    }
}
