using System;
using System.Threading;

namespace test
{
    public class UIComponent
    {
        private AssetStreamHandler assetStreamHandler;
        private Connection connection;

        public void Run(){

            //UI thread is the main thread
            //drawUI();

            assetStreamHandler = new AssetStreamHandler();
            assetStreamHandler.AssetUpdate += this.HandleAssetUpdate;

            connection = new Connection();
            connection.ConnectionEvent += assetStreamHandler.HandleConnectionEvent;
            connection.ConnectionException += this.HandleConnectionException;
            //thread to handle streaming
            Thread myThread = new Thread(new ThreadStart(connection.Start));
        }

        public void Stop()
        {
            connection.Stop();
        }

        private void HandleAssetUpdate(Asset asset){

            //////////////////////////////
            // use Dispatcher.Invoke to update UI (in WPF) 
            ////////////////////////////////

        }

        private void HandleConnectionException(Exception e)
        {
            //re-initiate connection or close app
        }
    }
}
