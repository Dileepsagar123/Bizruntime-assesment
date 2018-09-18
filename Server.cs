using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AssesmentApp
{
	class Server
	{
		static void Main(string[] args)
		{


			try
			{
				IPAddress ipAd = IPAddress.Parse("127.0.0.1");
				// use local m/c IP address, and 
				// use the same in the client

				/* Initializes the Listener */
				int port = 8888;
				TcpListener myList = new TcpListener(ipAd, port);

				/* Start Listeneting at the specified port */
				myList.Start();

				Console.WriteLine("The server is running at port {0}...", port);
				Console.WriteLine("The local End point is  :" +
								  myList.LocalEndpoint);
				Console.WriteLine("Waiting for a connection.....");

				Socket s = myList.AcceptSocket();
				Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);

				byte[] b = new byte[100];
				int k = s.Receive(b);
				Console.WriteLine("Recieved...");
				for (int i = 0; i < k; i++)
					Console.Write(Convert.ToChar(b[i]));

				ASCIIEncoding asen = new ASCIIEncoding();
				s.Send(asen.GetBytes("The string was recieved by the server."));
				Console.WriteLine("\nSent Acknowledgement");
				/* clean up */
				s.Close();
				myList.Stop();

			}
			catch (Exception e)
			{
				Console.WriteLine("Error..... " + e.StackTrace);
			}
			Console.ReadLine();

		}
	}
}
