using System;
using System.Threading;
using System.Threading.Tasks;

namespace PingPongUsingEvents
{
    public class Program
    {
        private const int Timeout = 1000;

        public static void Main(string[] args)
        {
            ManualResetEventSlim startEvent = null; // TODO Create a new ManualResetEvent.
            AutoResetEvent pingEvent = null; // TODO Create a new AutoResetEvent.
            AutoResetEvent pongEvent = null; // TODO Create a new AutoResetEvent.

            CancellationTokenSource cts = null; // TODO: Create a new cancellation token source.

            // This is a ping thread.
            Task.Run(() =>
            {
                Console.WriteLine("ping: Waiting for start.");
                startEvent.Wait();

                while (cts.IsCancellationRequested == false)
                {
                    Console.WriteLine("ping!");

                    // TODO Use pingEvent OR pongEvent to notify pong thread to continue.

                    // TODO Use pingEvent OR pongEvent to wait for pong thread.

                    Thread.Sleep(Timeout);
                }

                // TODO Release pong thread in case the thread is waiting for pingEvent.

                Console.WriteLine("ping: done");
            });

            // This is pong thread.
            Task.Run(() =>
            {
                Console.WriteLine("pong: Waiting for start.");
                startEvent.Wait();

                while (cts.IsCancellationRequested == false)
                {
                    // TODO Use pingEvent OR pongEvent here to wait for ping thread.

                    Thread.Sleep(Timeout);

                    Console.WriteLine("pong!");

                    // TODO Use pingEvent OR pongEvent to notify ping thread to continue.
                }

                Console.WriteLine("pong: done");
            });

            Console.WriteLine("Press any key to start. Press any key once more to stop.");
            Console.ReadKey();

            // TODO Send a signal to ping and pong threads to start using startEvent.

            Console.ReadKey();

            // TODO Сancel both ping and pong threads using cancellation token.

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}