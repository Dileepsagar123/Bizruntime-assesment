using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssesmentApp
{
	class InsertInfo
	{
		static void Main(string[] args)
		{
			List<Info> lstemployee = null;
			try
			{
			 lstemployee = new List<Info>();
				Console.WriteLine("Input Name");
				string name = Console.ReadLine();
				Console.WriteLine("Input Address");
				string addr = Console.ReadLine();
				Console.WriteLine("Input Phone");
				int phone = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Input Email");
				string email = Console.ReadLine();
				lstemployee.Add(new Info()

				{

					Name = name,

					Address = addr,

					Phone = phone,

					Email = email

				});
			}
			catch(Exception EX)
			{
				Console.WriteLine(EX.Message);
			}

				string output = JsonConvert.SerializeObject(lstemployee.ToArray());

				string path = @"D:\EmployeeDatahex1.json";
				if (File.Exists(path))

				{

					File.CreateText(path);
					

				}

				else

				{

					File.WriteAllText(@"D:\EmployeeDatahex1.json", output);



				}

			
			
			Console.ReadLine();


		}

	}
		
	}

