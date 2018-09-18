using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AssesmentApp
{
	class Ado1
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Input table Name");
			string tableName = Console.ReadLine();
			new Ado1().Create(tableName, "data source=DESKTOP-JH5J8TL\\SQLEXPRESS;database=Student;integrated security=SSPI");
			new Ado1().Insert(tableName, "data source=DESKTOP-JH5J8TL\\SQLEXPRESS;database=Student;integrated security=SSPI");
			Console.ReadLine();
		}
		public void Insert(string TName , string Constring)
		{
			try
			{

				


			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}
		public void Create(string TName, string ConString)
		{
			try
			{

				string sql = "SELECT count(*) as IsExists FROM dbo.sysobjects where id = object_id('[dbo].[" + TName + "]')";
				SqlCommand sqlCommand = new SqlCommand(sql);
				
				
				using (SqlCommand cmd = new SqlCommand("CREATE TABLE [dbo].['" + TName + "']("
								+ "[ID] [int] IDENTITY(1,1) NOT NULL,"
								+"[name][varchar],"
								+ "CONSTRAINT ['pk_" + TName + "'] PRIMARY KEY CLUSTERED "
								+ "("
								+ "[ID] ASC"
								+ ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"
								+ ") ON [PRIMARY]", new SqlConnection(ConString)))
				{
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
		}

	}
}
