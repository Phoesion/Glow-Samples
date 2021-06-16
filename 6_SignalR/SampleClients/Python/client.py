import logging
import sys
from signalrcore.hub_connection_builder import HubConnectionBuilder


def input_with_default(input_text, default_value):
    value = input(input_text.format(default_value))
    return default_value if value is None or value.strip() == "" else value

server_url = input_with_default('Enter your server url(default: {0}): ', "ws://localhost:16000/ChatService/Chat")
username = input_with_default('Enter your username (default: {0}): ', "pythonClient")

handler = logging.StreamHandler()
handler.setLevel(logging.INFO)

#create hub connection
hub_connection = HubConnectionBuilder()\
    .with_url(server_url) \
    .configure_logging(logging.INFO, handler=handler) \
    .with_automatic_reconnect({
            "type": "interval",
            "keep_alive_interval": 10,
            "intervals": [1, 3, 5, 6, 7, 10, 5]
        }).build()


def on_connection_open():
    # Register client
    registerReq = {
      "Username": username,
    }
    hub_connection.send('REGISTER', ['ChatService/Chat/Register', registerReq])
    print("connection opened and handshake received ready to send messages")
    
    
hub_connection.on_open(on_connection_open)
hub_connection.on_close(lambda: print("connection closed"))
hub_connection.on_error(lambda data: print(f"An exception was thrown : {data.error}"))

hub_connection.on("ChatMsg", print)

# Start connection
hub_connection.start()

# Heartbeat
dstUser = '*'
message= None
while message != "exit()":
    message = input(">> ")
    if message is not None and message != "" and message != "exit()":
        msgReq = {
            "Text": message,
        }
        hub_connection.send('CALL', ['ChatService/Chat/SendMessage', 'toUser=' + dstUser, msgReq])


# Stop connection
hub_connection.stop()
sys.exit(0)
