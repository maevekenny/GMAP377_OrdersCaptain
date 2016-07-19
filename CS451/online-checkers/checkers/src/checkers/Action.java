package checkers;

public abstract class Action {

	public String name;
	
	public String toString() {
		return name;
	}
	
	public void execute() {
		System.out.println("Executing");
	}
}
