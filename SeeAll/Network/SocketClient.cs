using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SeeAll
{
    class SocketClient
    {
        private Socket sender;
        private config.ConfigNetwork cfgntwrk;

        public Socket Sender { get { return sender; } }

        public SocketClient(config.ConfigNetwork cfgntwrk)
        {
            this.cfgntwrk = cfgntwrk;
            try
            {
                ConnectSocket();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //finally
            //{
            //    Console.ReadLine();
            //}
        }

        void ConnectSocket()
        {
          
            IPEndPoint ipEndPoint = this.cfgntwrk.IpEndPoint;

            this.sender = new Socket(this.cfgntwrk.IpAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            this.sender.Connect(this.cfgntwrk.IpEndPoint);
        }

        public void SendMessage()
        {
           
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];
            Console.Write("Введите сообщение: ");
            string message = Console.ReadLine();

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);

            // Отправляем данные через сокет
            int bytesSent = sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
          
            //// Используем рекурсию для неоднократного вызова SendMessageFromSocket()
            //if (message.IndexOf("<TheEnd>") == -1)
            //    SendMessageFromSocket(cfgntwrk);
        }
        public void CloseSocket()
        {
            // Освобождаем сокет
            this.sender.Shutdown(SocketShutdown.Both);
            this.sender.Close();
        }
    }
}
