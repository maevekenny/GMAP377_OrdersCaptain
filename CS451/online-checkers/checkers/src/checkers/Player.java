package checkers;

import java.net.Socket;

public class Player {

	
	public Player(Socket socket) {
		System.out.println("Player " + socket.getPort());
	}
}
