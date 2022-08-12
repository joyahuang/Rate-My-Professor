using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RateMyCourse
{
	static public class VitalMessage
	{
		static public int uid=1;
		static public int cid=1;
        static public SqlConnection myconn = new SqlConnection("Initial Catalog = DatabaseCD; Data Source = (local); Integrated Security = True");
	}

}
