﻿using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
namespace AssesmentApp
	{
public class Server2
{
	public static void Main(string[] args)
	{

		// establish the local end point for the socket 
		IPHostEntry ipHost = Dns.Resolve("localhost");
		IPAddress ipAddr = ipHost.AddressList[0];
		IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

		// create a Tcp/Ip Socket 
		Socket sListener = new Socket(AddressFamily.InterNetwork,
									  SocketType.Stream, ProtocolType.Tcp);

		// bind the socket to the local endpoint and 
		// listen to the incoming sockets 

		try
		{
			sListener.Bind(ipEndPoint);
			sListener.Listen(10);

			// Start listening for connections 

			while (true)
			{
				Console.WriteLine("Waiting for a connection on port {0}", ipEndPoint);

				// program is suspended while waiting for an incoming connection 
				Socket handler = sListener.Accept();

				string data = null;

				// we got the client attempting to connect 
				while (true)
				{
					byte[] bytes = new byte[1024];

					int bytesRec = handler.Receive(bytes);

					data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

					if (data.IndexOf("<theend>") > -1)
					{
						break;
					}
				}

				// show the data on the console 
				Console.WriteLine("Text Received: {0}", data);

				string theReply = "Thank you for those " + data.Length.ToString()
								+ " characters...";
				byte[] msg = Encoding.ASCII.GetBytes(theReply);

				handler.Send(msg);
				handler.Shutdown(SocketShutdown.Both);
				handler.Close();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}

	} // end of Main 
}
}