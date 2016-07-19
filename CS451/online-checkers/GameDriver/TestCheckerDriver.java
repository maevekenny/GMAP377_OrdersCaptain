package Checker;

import java.util.*; 

/**
 * JUnit tests for CheckerDriver class.
 * we will read each line of the board as a string representation of a base 5 number.
 */
import static org.junit.Assert.*;

import org.junit.Test;

public class TestCheckerDriver {
	final int BOARD_SIZE = new CheckerDriver().BOARD_SIZE;
	@Test
	public void testDecode() {
		assertEquals(Piece.NONE, CheckerDriver.pieceDecode(0));
		assertEquals(Piece.BLACK, CheckerDriver.pieceDecode(1));
		assertEquals(Piece.RED, CheckerDriver.pieceDecode(2));
		assertEquals(Piece.KING_B, CheckerDriver.pieceDecode(3));
		assertEquals(Piece.KING_R, CheckerDriver.pieceDecode(4));
	}
	
	@Test
	public void testConstructor()
	{
		int[][] b = new CheckerDriver().getBoard();
		assertEquals("01010101", getLine(b, 0));
		assertEquals("10101010", getLine(b, 1));
		assertEquals("01010101", getLine(b, 2));
		assertEquals("00000000", getLine(b, 3));
		assertEquals("00000000", getLine(b, 4));
		assertEquals("20202020", getLine(b, 5));
		assertEquals("02020202", getLine(b, 6));
		assertEquals("20202020", getLine(b, 7));
	}
	
	@Test
	public void testLegalMoveList()
	{
		CheckerDriver check = new CheckerDriver();
		
		//up-left corner, single piece normal black	
		int[][] b = new int[BOARD_SIZE][BOARD_SIZE];
		b[0][0] = 1;		
		check.setBoard(b);
		LinkedList<IntPair> res = check.legalMoves(0, 0, false);
		LinkedList<IntPair> correct = new LinkedList<IntPair>();
		correct.add(new IntPair(1,1));
		assertTrue(sameMoveList(correct, res));
		
		//up-right corner, single piece normal black
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[0][7] = 1;		
		check.setBoard(b);
		res = check.legalMoves(0, 7, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(1,6));
		assertTrue(sameMoveList(correct, res));
		
		//down-left corner, single red piece
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[7][0] = 2;		
		check.setBoard(b);
		res = check.legalMoves(7, 0, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(6,1));
		assertTrue(sameMoveList(correct, res));
		
		//down-right corner, single red piece
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[7][7] = 2;		
		check.setBoard(b);
		res = check.legalMoves(7, 7, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(6, 6));
		assertTrue(sameMoveList(correct, res));
		
		//single black piece, middle of empty board
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;		
		check.setBoard(b);
		res = check.legalMoves(2, 3, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(3,2));
		correct.add(new IntPair(3,4));
		assertTrue(sameMoveList(correct, res));
		
		//single red piece, middle of empty board
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[5][4] = 2;		
		check.setBoard(b);
		res = check.legalMoves(5, 4, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(4,3));
		correct.add(new IntPair(4,5));
		assertTrue(sameMoveList(correct, res));
		
		//normal black piece, with 1 jump option
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;	
		b[3][2] = 2;
		check.setBoard(b);
		res = check.legalMoves(2, 3, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(4,1));
		assertTrue(sameMoveList(correct, res));
		
		//normal black piece, with 2 jump option
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;	
		b[3][2] = 2;
		b[3][4] = 2;
		check.setBoard(b);
		res = check.legalMoves(2, 3, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(4,1));
		correct.add(new IntPair(4,5));
		assertTrue(sameMoveList(correct, res));
		
		//black king piece, in middle of empty board
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 3;	
		check.setBoard(b);
		res = check.legalMoves(2, 3, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(1,2));
		correct.add(new IntPair(1,4));
		correct.add(new IntPair(3,2));
		correct.add(new IntPair(3,4));
		assertTrue(sameMoveList(correct, res));
		
		//red king piece, in middle of empty board
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 4;	
		check.setBoard(b);
		res = check.legalMoves(2, 3, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(1,2));
		correct.add(new IntPair(1,4));
		correct.add(new IntPair(3,2));
		correct.add(new IntPair(3,4));
		assertTrue(sameMoveList(correct, res));
		
		//black king piece, surrounded by 1 black and 2 reds
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 3;	
		b[3][2] = 2;
		b[3][4] = 2;
		check.setBoard(b);
		res = check.legalMoves(2, 3, false);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(4,1));
		correct.add(new IntPair(4,5));
		assertTrue(sameMoveList(correct, res));
		
		//black piece, just jump, but surrounded by empty squares
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;	
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		assertTrue(sameMoveList(correct, res));
		
		//black king, just jump, but surrounded by empty squares
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 3;	
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		assertTrue(sameMoveList(correct, res));
		
		//red piece, just jump, but surrounded by empty squares
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 2;	
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		assertTrue(sameMoveList(correct, res));
		
		//red king, just jump, but surrounded by empty squares
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 4;	
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		assertTrue(sameMoveList(correct, res));
		
		//black piece, just jump, there is 1 other black piece and 1 black king around
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;	
		b[3][2] = 1;
		b[3][4] = 3;
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		assertTrue(sameMoveList(correct, res));
		
		//black piece, just jump, there is 1 red piece and 1 red king around
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;
		b[3][2] = 2;
		b[3][4] = 4;
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(4,1));
		correct.add(new IntPair(4,5));
		assertTrue(sameMoveList(correct, res));
		
		//king black piece, just jump, there is 1 black piece, 2 red pieces and 1 red king around
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 3;
		b[1][2] = 1;
		b[1][4] = 2;
		b[3][2] = 2;
		b[3][4] = 4;
		check.setBoard(b);
		res = check.legalMoves(2, 3, true);
		correct = new LinkedList<IntPair>();
		correct.add(new IntPair(0,5));
		correct.add(new IntPair(4,1));
		correct.add(new IntPair(4,5));
		assertTrue(sameMoveList(correct, res));
	}
	
	@Test 
	public void testMove()
	{
		//normal move
		CheckerDriver check = new CheckerDriver();
		assertFalse(check.movePiece(5, 4, new IntPair(4, 5)));
		assertEquals("00000200", getLine(check.getBoard(), 4));
		assertEquals("20200020", getLine(check.getBoard(), 5));
		
		assertFalse(check.movePiece(2, 7, 3, 6));
		assertEquals("01010100", getLine(check.getBoard(), 2));
		assertEquals("00000010", getLine(check.getBoard(), 3));
		
		//a jump
		assertFalse(check.movePiece(3, 6, 5,4));
		assertEquals("00000000", getLine(check.getBoard(), 3));
		assertEquals("00000000", getLine(check.getBoard(), 4));
		assertEquals("20201020", getLine(check.getBoard(), 5));
	}
	
	@Test
	public void testKingPiece()
	{
		int[][] b = new int[BOARD_SIZE][BOARD_SIZE];
		b[7][2] = 1;
		b[0][1] = 2;
		CheckerDriver check = new CheckerDriver();
		check.setBoard(b);
		check.kingPiece();
		b = check.getBoard();
		assertEquals(b[7][2], 3);
		assertEquals(b[0][1], 4);
	}
	
	@Test
	public void testIsLost()
	{
		int[][] b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 1;	
		CheckerDriver check = new CheckerDriver();
		check.setBoard(b);
		assertTrue(check.isLost(2));
		
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[2][3] = 2;	
		check = new CheckerDriver();
		check.setBoard(b);
		assertTrue(check.isLost(1));
		assertFalse(check.isLost(2));
		
		b = new int[BOARD_SIZE][BOARD_SIZE];
		b[0][7] = 1;
		b[1][6] = 2;
		b[2][5] = 4;
		b[7][0] = 3;
		b[6][1] = 4;
		b[5][2] = 2;
		check = new CheckerDriver();
		check.setBoard(b);
		assertTrue(check.isLost(1));
	}
	public String getLine(int[][] board, int row)
	{
		String res = "";
		for (int i = 0; i < BOARD_SIZE; i++)
			res = res + board[row][i];
		return res;
	}
	
	public boolean sameMoveList(LinkedList<IntPair> first, LinkedList<IntPair> second)
	{
		if (first.size() != second.size())
			return false;
		return second.containsAll(first);
	}
	
	public boolean sameBoard(int[][] first, int[][] second)
	{
		if (first.length != second.length)
			return false;
		if (first[0].length != second[0].length)
			return false;
		for (int i = 0; i < BOARD_SIZE; i++)
			if (!getLine(first, i).equals(getLine(second, i)))
				return false;
		return true;
	}
}
