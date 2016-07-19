package checkers;

import java.io.IOException;
import java.net.ServerSocket;

public class Server {
	
	public static void main(String args[]) throws IOException {
		ServerSocket listener = new ServerSocket(9000);
        System.out.println("Running on port 9000");
        Player p1 = new Player(listener.accept());
        Player p2 = new Player(listener.accept());
        Game game = new Game(p1, p2);
        
        
        listener.close();
	}
}