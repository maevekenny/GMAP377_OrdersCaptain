package checkers;

public class Move extends Action {

	public Move() {
		this.name = "MOVE";
	}
	
	public void execute() {
		System.out.println("Moving a piece");
	}
}
