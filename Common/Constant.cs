using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Constant
    {
        public const string Keyspace = "SchoolKeyspace";

        public static string ConnectionString = "Server=localhost;port=9160;Keyspace={0}";
    }
}
