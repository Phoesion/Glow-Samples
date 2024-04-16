using Microsoft.Extensions.Logging;
using Phoesion.Glow.SDK;
using Phoesion.Glow.SDK.Firefly;
using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Foompany.Services.Example.Modules
{
    public class WebSocket : Phoesion.Glow.SDK.Firefly.FireflyModule
    {
        [Action(Methods.GET)]
        public string Default() => "Default method!";

        // *****************************************************************************************************
        // Notes :
        //  Mark this action as [IsUpgradableConnection] to instruct PRISM this connection may be upgraded.
        // *****************************************************************************************************

        [Action(Methods.GET), IsUpgradableConnection]
        public async Task<IWebSocketConnection> Connect()
        {
            logger.Information($"Received a websocket connection request!");

            //upgrade connection to websockets
            var connection = await Context.UpgradeWebSocketAsync();

            //start handler (in another task, since this method needs to return the connection object)
            _ = Task.Run(() => connectionHandler(connection));

            //return connection to client
            return connection;
        }

        //This method will handle the new websocket connections
        async Task connectionHandler(IWebSocketConnection connection)
        {
            //declares
            var recbuffer = new byte[1024];
            int msgId = 0;
            var ct = connection.ConnectionAborted;

            //handler
            await using (connection)
                try
                {
                    //get socket
                    var socket = await connection.GetServerSocket();

                    //heartbeat (run until connection is closed/aborted)
                    while (!connection.IsDisposed &&
                            socket.State == WebSocketState.Open &&
                            !ct.IsCancellationRequested)
                    {
                        //send some data
                        msgId++;
                        var sendBuffer = Encoding.UTF8.GetBytes("Hello from server! this is message " + msgId);
                        await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, ct);

                        //spin delay
                        await Task.Delay(1000);

                        //receive some data
                        var rec = await socket.ReceiveAsync(recbuffer, ct);
                        var recMsg = Encoding.UTF8.GetString(recbuffer.AsSpan().Slice(0, rec.Count));
                        logger.Information($"Received data. length={rec.Count}, message={recMsg}");

                        //spin delay
                        await Task.Delay(1000);
                    }
                    logger.Information($"Connection closed!");
                }
                catch (Exception ex) { logger.Error(ex, "Connection handler error"); }
        }
    }
}
