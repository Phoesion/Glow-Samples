using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            //declares
            int msgId = 0;
            var recBuffer = new byte[1024];

            //connect
            using var socket = new System.Net.WebSockets.ClientWebSocket();
            await socket.ConnectAsync(new Uri("ws://localhost:16000/Example/WebSocket/Connect"), CancellationToken.None);

            //heartbeat
            while (socket.State == System.Net.WebSockets.WebSocketState.Open)
            {
                //receive some data
                var rec = await socket.ReceiveAsync(recBuffer, CancellationToken.None);
                var recMsg = Encoding.UTF8.GetString(recBuffer.AsSpan().Slice(0, rec.Count));
                Console.WriteLine($"Received data. length={rec.Count}, message={recMsg}");

                //send some data!
                msgId++;
                var sendBuffer = Encoding.UTF8.GetBytes("Hello from client! this is message " + msgId);
                await socket.SendAsync(sendBuffer, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
