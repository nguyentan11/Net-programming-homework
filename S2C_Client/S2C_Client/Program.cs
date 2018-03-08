using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace S2C_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            client.Connect("127.0.0.1", 1234);
            Stream stream = client.GetStream();

            Console.WriteLine("Da ket noi toi server.");
            while (true)
            {
                Console.Write("Nhap ten cua ban: ");

                string str = Console.ReadLine();
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;

                writer.WriteLine(str);
                str = reader.ReadLine();
                Console.WriteLine(str);
                if (str.ToUpper() == "BYE")
                    break;
            }
            stream.Close();
            client.Close();
        }
    }
}
