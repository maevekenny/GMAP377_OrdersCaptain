package Checker;

import java.io.*;

/**
* a simple class of integer pair
**/
public class IntPair implements Serializable {
	final int x;
	final int y;
	
	/**
	 * create the integer pair
	 * @param a first number
	 * @param b second number
	 */
	public IntPair(int a, int b)
	{
		x = a;
		y = b;
	}
	
	int getX() {return x;}
	int getY() {return y;}
	
	@Override
	/**
	 * override equals method for comparing 2 objects
	 * @param check the other object to compare to
	 */
	public boolean equals(Object check)
	{
		if (check instanceof IntPair && ((IntPair) check).getX() == x && ((IntPair) check).getY() == y)
			return true;
		return false;
	}
}