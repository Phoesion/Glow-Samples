import java.util.Scanner;
import com.microsoft.signalr.HubConnection;
import com.microsoft.signalr.HubConnectionBuilder;

public class App {
	public static void main(String[] args) throws Exception {
		// for reading from System.in
		Scanner reader = new Scanner(System.in);

		//create hub
		HubConnection hubConnection =  HubConnectionBuilder.create("http://localhost:16000/Glow.SignalR").build();

		//Register events
		hubConnection.on("ChatMsg", (message) -> {
			System.out.println("\r\n" + message + "\r\n");
		}, String.class);

		hubConnection.on("NotificationMsg", (message) -> {
			System.out.println("\r\n*** " + message + "\r\n");
		}, String.class);

		//Connect to server
		System.out.println("Connecting to server...");
		hubConnection.start().blockingAwait();

		//Register client
		System.out.println("");
		System.out.print("Enter your username : ");
		RegistrationRequestDto registrationRequest = new RegistrationRequestDto();
		registrationRequest.username =  reader.nextLine();
		hubConnection.invoke(String.class, "REGISTER", "ChatService/Chat/Register", registrationRequest);

		//message loop
		while (true)
		{
			//create Dto
			MessageRequest message = new MessageRequest();

			//get destination username
			System.out.println("");
			System.out.print("Send to user : ");
			String dstUser = reader.nextLine();
			if(dstUser ==null || dstUser.isEmpty())
			{
				System.out.println("Error *** please specify a username or * for all!");
				continue;
			}

			//get chat message
			System.out.print("Message : ");
			message.Text = reader.nextLine();

			//send message request
			hubConnection.invoke(String.class, "CALL", "ChatService/Chat/SendMessage", "toUser=" + dstUser, message);

			//artificial delay
			Thread.sleep(500);
		}

		//shutdown
		//reader.close();
		//hubConnection.stop();
	}
}
