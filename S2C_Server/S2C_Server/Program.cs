using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace S2C_Server
{
    class Program
    {
        static void Main(string[] args)
        {

            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);

            listener.Start();

            Console.WriteLine("Server khoi dong o: " + listener.LocalEndpoint);
            Console.WriteLine("Dang doi ket noi...");

            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Ket noi toi " + socket.RemoteEndPoint);

            var stream = new NetworkStream(socket);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;

            while (true)
            {
                string str = reader.ReadLine();
                if (str.ToUpper() == "EXIT")
                {
                    writer.WriteLine("bye");
                    break;
                }
                writer.WriteLine("Hello " + str);
            }
            stream.Close();
            socket.Close();
            listener.Stop();
        }
    }
}
