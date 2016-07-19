package checkers;

import java.io.IOException;
import java.net.Socket;
import java.net.UnknownHostException;

public class Client {

	public static void main(String args[]) throws UnknownHostException, IOException {
		Socket socket = new Socket("http://localhost", 9000);
		
	}
}
