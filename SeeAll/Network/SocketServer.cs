using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SeeAll
{
    class SocketServer
    {
        public SocketServer(config.ConfigNetwork cfgntwr)
        {
            IPAddress ipAddr = IPAddress.Any;
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, cfgntwr.Port);

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                Task task = Task.Run(() => RunTask(sListener,ipEndPoint));
                // Начинаем слушать соединения
                
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

        private void RunTask(Socket sListener, IPEndPoint ipEndPoint)
        {
            while (true)
            {
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                // Программа приостанавливается, ожидая входящее соединение
                Socket handler = sListener.Accept();
                string data = null;

                // Мы дождались клиента, пытающегося с нами соединиться

                byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);

                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                // Показываем данные на консоли
                Console.Write("Полученный текст: " + data + "\n\n");

                // Отправляем ответ клиенту\
                string reply = "Спасибо за запрос в " + data.Length.ToString()
                        + " символов";
                byte[] msg = Encoding.UTF8.GetBytes(reply);
                handler.Send(msg);

                if (data.IndexOf("<TheEnd>") > -1)
                {
                    Console.WriteLine("Сервер завершил соединение с клиентом.");
                    break;
                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
    }
}
