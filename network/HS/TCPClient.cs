/*********************************************************************************************
* 
* ILS-Sim.org Apps
* Copyright (C) 2016  ils-sim.org Team
* 
* This program is free software; you can redistribute it and/or modify it under the terms
* of the GNU General Public License as published by the Free Software Foundation; either
* version 3 of the License, or (at your option) any later version.
* 
* This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
* without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
* See the GNU General Public License for more details.
* 
* You should have received a copy of the GNU General Public License along with this
* program; if not, see <http://www.gnu.org/licenses/>.
* 
*********************************************************************************************/
using System;
using System.Net;
using System.Net.Sockets;

namespace network
{
	public class TCPClient
	{
		public Socket clientSocket = null;
		public byte[] buffer;

		public TCPClient()
		{
		}

		public void Connect(String server, Int32 port)
		{
			try
			{
				clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				clientSocket.BeginConnect(server, port, new AsyncCallback(OnConnect), null);
			} catch(Exception ex)
			{
				Console.WriteLine("TCP Connection Error: " + ex.Message);
				clientSocket = null;
			}
		}

		public bool Connected()
		{
			if(clientSocket == null)
			{
				return false;
			}
			return clientSocket.Connected;
		}

		public void Close()
		{
			clientSocket.Close();
			clientSocket = null;
		}

		public void Send(Protocol package)
		{
			try
			{
				System.IO.MemoryStream memStream = new System.IO.MemoryStream();
				Google.Protobuf.CodedOutputStream stream = new Google.Protobuf.CodedOutputStream(memStream);
				package.WriteTo(stream);
				stream.Flush();

				byte[] data_package = memStream.ToArray();
				byte[] data = new byte[data_package.Length + 4];
				WriteInt(data, 0, data_package.Length);
				data_package.CopyTo(data, 4);

				clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
			} catch(Exception ex)
			{
				Console.WriteLine("TCP Send Error: " + ex.Message);
			}
		}

		public delegate void ReceivePacketEventHandler(Protocol package);
		public event ReceivePacketEventHandler onPackageReceive;

		private void OnConnect(IAsyncResult ar)
		{
			try
			{
				clientSocket.EndConnect(ar);
				buffer = new byte[4];
				clientSocket.BeginReceive(buffer, 0, 4, 0, new AsyncCallback(OnSizeReceive), null);
			} catch(Exception ex)
			{
				Console.WriteLine("TCP OnConnect Error: " + ex.Message);
				clientSocket = null;
			}
		}

		private void OnSizeReceive(IAsyncResult ar)
		{
			Int32 received = clientSocket.EndReceive(ar);
			if(received > 0)
			{
				Int32 size = buffer[0];
				size += buffer[1] << 8;
				size += buffer[2] << 16;
				size += buffer[3] << 24;
				buffer = new byte[size];
				clientSocket.BeginReceive(buffer, 0, size, 0, new AsyncCallback(OnPackageReceive), null);
			} else
			{
				Console.WriteLine("TCP OnSizeReceive Error: " + ar.ToString());
			}
		}

		private void OnPackageReceive(IAsyncResult ar)
		{
			Int32 received = clientSocket.EndReceive(ar);
			if(received > 0)
			{
				if(onPackageReceive != null)
				{
					System.IO.MemoryStream memStream = new System.IO.MemoryStream(buffer);
					Google.Protobuf.CodedInputStream stream = new Google.Protobuf.CodedInputStream(memStream);
					Protocol package = new Protocol();
					package.MergeFrom(stream);
					onPackageReceive(package);
				}
				buffer = new byte[4];
				clientSocket.BeginReceive(buffer, 0, 4, 0, new AsyncCallback(OnSizeReceive), null);
			} else
			{
				Console.WriteLine("TCP OnPackageReceive Error: " + ar.ToString());
			}
		}

		private void OnSend(IAsyncResult ar)
		{
			try
			{
				clientSocket.EndSend(ar);
			} catch(Exception ex)
			{
				Console.WriteLine("TCP OnSend Error: " + ex.Message);
			}
		}

		private void WriteInt(byte[] buffer, Int32 offset, Int32 value)
		{
			buffer[offset + 3] = (byte)(value >> 24);
			buffer[offset + 2] = (byte)(value >> 16);
			buffer[offset + 1] = (byte)(value >> 8);
			buffer[offset] = (byte)(value);
		}
	}
}

