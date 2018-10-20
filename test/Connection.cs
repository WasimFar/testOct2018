using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace test
{
    public class Connection
    {
        const string myIPAddress = "79.125.80.209";
        const Int32 myPort = 4092;
        const int sleepUnit = 1000;

        public delegate void ConnectionEventHandler(String message);
        public event ConnectionEventHandler ConnectionEvent;

        public delegate void ConnectionExceptionHandler(Exception ex);
        public event ConnectionExceptionHandler ConnectionException ;

        string p;
        bool running = false;

        public Connection(){

        }

        public void Stop() {
            running = false;
        }

        public void Start(){
            running = true;
            try
            {
                using (var client = new TcpClient(myIPAddress, myPort))
                using (var stream = client.GetStream())
                using (var reader = new StreamReader(stream))
                {
                    while (running)
                    {
                        p = reader.ReadLine();
                        if (p == null)
                        {   
                            Thread.Sleep(sleepUnit);
                        }else{
                             ConnectionEvent(p);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ConnectionException(e);
            }
        }
    }

}
