﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SeeHost
{
    class SocketServer
    {
        public SocketServer()
        {
            //IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = IPAddress.Any;
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 45013);

            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);
                Socket handler = sListener.Accept();
                Task task = Task.Run(() => RunTask(handler, ipEndPoint));
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

        private void RunTask(Socket handler, IPEndPoint ipEndPoint)
        {
            while (true)
            {
              
                // Программа приостанавливается, ожидая входящее соединение
              
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

               // handler.Shutdown(SocketShutdown.Both);
              //  handler.Close();
            }
        }
    }
}
