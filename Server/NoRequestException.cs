using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class NoRequestException:Exception
    {
        public NoRequestException(String exception):base(exception)
        {

        }
    }
}
