package Checker;

import java.util.*;
import java.io.*;

/**
Piece types
*/
enum Piece {
	NONE, BLACK, RED, KING_B, KING_R
}

/**
* driver class, responsible for representing the board and running the game
*
*
*/
public class CheckerDriver implements Serializable 
{
	final int BOARD_SIZE = 8;
	/**
	* 8x8 board, coded as followed:
	* 0: empty square
	* 1: normal black piece
	* 2: normal red piece
	* 3: kinged black piece
	* 4: kinged red piece
	**/
	int[][] board; 
	
	/**
	* initialize a normal board
	*/
	public CheckerDriver()
	{
		board = new int[BOARD_SIZE][BOARD_SIZE];
		for (int i = 0; i < BOARD_SIZE; i++)
		for (int j = 0; j < BOARD_SIZE; j++)
		{
			if (i % 2 == 0 && j % 2 == 0)
				board[i][j] = 0;
			else if (i < 3 && (i+j) % 2 == 1)	
				board[i][j] = 1;
			else if (i > 4 && (i+j) % 2 == 1)
				board[i][j] = 2;
		}		
	}
	
	/**
	 * set the board based on a given array
	 * @param b is an 8x8 int array
	 */
	public void setBoard(int[][] b)
	{
		for (int i = 0; i < BOARD_SIZE; i++)
		for (int j = 0; j < BOARD_SIZE; j++)
			board[i][j] = b[i][j];
	}
	
	/**
	* decode, to get the correct Piece value
	* @param code is the given code
	* @return the Piece value according to the code:
	* 			1: Piece.BLACK
	* 			2: Piece.RED
	* 			3: Piece.KING_B
	* 			4: Piece.KING_R
	* 			other: Piece.NONE
	*/
	public static Piece pieceDecode(int code)
	{
		switch(code)
		{
			case(1):
				return Piece.BLACK;
			case(2):
				return Piece.RED;
			case(3):
				return Piece.KING_B;
			case(4):
				return Piece.KING_R;
			default:
				return Piece.NONE;
		}
	}
	
	/**
	* check the given piece, then return a list of squares that it can moves to.
	* Note that if a jump is possible, it is the only legal move.
	* If multiple jumps are possible, only those jumps are legal moves.
	* @param row is the row of the piece
	* @param col is the collumn of the piece
	* @param justJump shows if the piece just completed a jump. If true, the piece just jump, and only jumps are counted as next legal moves
	* @return the list of legal moves.
	*/
	public LinkedList<IntPair> legalMoves(int row, int col, boolean justJump)
	{
		int currentPiece = board[row][col];
		LinkedList<IntPair> jumpList = getJumpList(row, col, currentPiece);
		if (jumpList.size() != 0)	//jumps are available
			return jumpList;
		if (!justJump)
			return getNormalList(row, col, currentPiece);
		return new LinkedList<IntPair>();
	}
	
	/**
	 * get the list of the available squares to move 1 to.
	 * normal moves, no jumps
	 * @param row is the row of the square
	 * @param col is the column of the square
	 * @param piece is the piece on the square
	 * @return a list for normal moves
	 */
	LinkedList<IntPair> getNormalList(int row, int col, int piece)
	{
		LinkedList<IntPair> res = new LinkedList<IntPair>();
		if (piece == 1)		//normal black piece
		{
			if (col > 0 && board[row + 1][col - 1] == 0)
				res.add(new IntPair(row + 1, col - 1));
			if (col < BOARD_SIZE - 1 && board[row + 1][col + 1] == 0)
				res.add(new IntPair(row + 1, col + 1));
			return res;
		}
		else if (piece == 2)	//normal red piece
		{
			if (col > 0 && board[row - 1][col - 1] == 0)
				res.add(new IntPair(row - 1, col - 1));
			if (col < BOARD_SIZE - 1 && board[row - 1][col + 1] == 0)
				res.add(new IntPair(row - 1, col + 1));
			return res;
		}
		else if (piece == 3 || piece == 4)	//kinged black or red piece
		{
			if (row > 0)
			{
				if (col > 0 && board[row - 1][col - 1] == 0)
					res.add(new IntPair(row - 1, col - 1));
				if (col < BOARD_SIZE - 1 && board[row - 1][col + 1] == 0)
					res.add(new IntPair(row - 1, col + 1));
			}
			if (row < BOARD_SIZE - 1)
			{
				if (col > 0 && board[row + 1][col - 1] == 0)
					res.add(new IntPair(row + 1, col - 1));
				if (col < BOARD_SIZE - 1 && board[row + 1][col + 1] == 0)
					res.add(new IntPair(row + 1, col + 1));
			}
		}
		return res;
	}
	
	/**
	 * get the list of available square to jump to
	 * @param row is the row of the square
	 * @param col is the column of the square
	 * @param piece is the type of piece on that square (1,2,3,4) 
	 * @return
	 */
	LinkedList<IntPair> getJumpList(int row, int col, int piece)
	{
		LinkedList<IntPair> res = new LinkedList<IntPair>();
		if (piece == 1)
		{
			//normal black piece
			if (row < BOARD_SIZE  - 2)
			{
				if (col > 1 && board[row + 2][col - 2] == 0 && (board[row + 1][col - 1] == 2 || board[row + 1][col - 1] == 4))
					res.add(new IntPair(row + 2, col - 2));
				if (col < BOARD_SIZE - 2 && board[row + 2][col + 2] == 0 && (board[row + 1][col + 1] == 2 || board[row + 1][col + 1] == 4))
					res.add(new IntPair(row + 2, col + 2));
			}
			return res;
		}
		else if (piece == 2)
		{
			if (row > 1)
			{
				if (col > 1 && board[row - 2][col - 2] == 0 && (board[row - 1][col - 1] == 1 || board[row - 1][col - 1] == 3))
					res.add(new IntPair(row - 2, col - 2));
				if (col < BOARD_SIZE - 2 && board[row - 2][col + 2] == 0 && (board[row - 1][col + 1] == 1 || board[row - 1][col + 1] == 3))
					res.add(new IntPair(row - 2, col + 2));
			}
			return res;
		}
		else if (piece == 3)
		{
			//kinged black piece
			if (row < BOARD_SIZE  - 2)
			{
				if (col > 1 && board[row + 2][col - 2] == 0 && (board[row + 1][col - 1] == 2 || board[row + 1][col - 1] == 4))
					res.add(new IntPair(row + 2, col - 2));
				if (col < BOARD_SIZE - 2 && board[row + 2][col + 2] == 0 && (board[row + 1][col + 1] == 2 || board[row + 1][col + 1] == 4))
					res.add(new IntPair(row + 2, col + 2));
			}
			if (row > 1)
			{
				if (col > 1 && board[row - 2][col - 2] == 0 && (board[row - 1][col - 1] == 2 || board[row - 1][col - 1] == 4))
					res.add(new IntPair(row - 2, col - 2));
				if (col < BOARD_SIZE - 2 && board[row - 2][col + 2] == 0 && (board[row - 1][col + 1] == 2 || board[row - 1][col + 1] == 4))
					res.add(new IntPair(row - 2, col + 2));
			}
			return res;
		}
		else if (piece == 4)
		{
			if (row < BOARD_SIZE  - 2)
			{
				if (col > 1 && board[row + 2][col - 2] == 0 && (board[row + 1][col - 1] == 1 || board[row + 1][col - 1] == 3))
					res.add(new IntPair(row + 2, col - 2));
				if (col < BOARD_SIZE - 2 && board[row + 2][col + 2] == 0 && (board[row + 1][col + 1] == 1 || board[row + 1][col + 1] == 3))
					res.add(new IntPair(row + 2, col + 2));
			}
			if (row > 1)
			{
				if (col > 1 && board[row - 2][col - 2] == 0 && (board[row - 1][col - 1] == 1 || board[row - 1][col - 1] == 3))
					res.add(new IntPair(row - 2, col - 2));
				if (col < BOARD_SIZE - 2 && board[row - 2][col + 2] == 0 && (board[row - 1][col + 1] == 1 || board[row - 1][col + 1] == 3))
					res.add(new IntPair(row - 2, col + 2));
			}
			return res;
		}
		return res;
	}
	/**
	* actually move the piece by modifying the board, note that the move should be checked for legality first
	* @param row is the row of the piece
	* @param col is the column of the piece
	* @param newLocation is an IntPair object specify the new location
	* @return true if it is a jump, and the user can make another move with that piece
	* 		false if the move ends the turn
	*/
	public boolean movePiece(int row, int col, IntPair newLocation)
	{
		return movePiece(row, col, newLocation.getX(), newLocation.getY());
	}
	
	/**
	* actually move the piece by modifying the board, note that the move should be checked for legality first, before calling this function
	* @param currRow is the current row of the piece
	* @param currCol is the current column of the piece
	* @param newRow is the new row to move to
	* @param newCol is the new column to move to
	* @return true if it is a jump, and the user can make another jump with that piece
	* 		false if the move ends the turn
	*/
	public boolean movePiece(int currRow, int currCol, int newRow, int newCol)
	{
		if (Math.abs(newRow - currRow) == 1 && Math.abs(newCol - currCol) == 1)		//normal move, move and return false
		{
			board[newRow][newCol] = board[currRow][currCol];
			board[currRow][currCol] = 0;
			kingPiece();		//king the piece if necessary
			return false;
		}
		else		//a jump
		{
			board[newRow][newCol] = board[currRow][currCol];
			board[currRow][currCol] = 0;
			board[(newRow + currRow) / 2][(newCol + currCol) / 2] = 0;   //capture the piece in between
			kingPiece();		//king the piece if necessary
			LinkedList<IntPair> check = legalMoves(newRow, newCol, true);
			return check.size() != 0;
		}
	}
	
	/**
	* king all the pieces that we need to king. The function will scan and modify the board accordingly
	* This function should be called after a piece is moved.
	*/
	public void kingPiece()
	{
		for (int col = 0; col < BOARD_SIZE; col++)
		{
			if (board[0][col] == 2)		//red pieces on black's edge
				board[0][col] = 4;
			if (board[BOARD_SIZE - 1][col] == 1)	//black pieces on red's edge
				board[BOARD_SIZE -1][col] = 3;
		}
	}
	
	/**
	* check if a side lose (he/she cannot make any other move).
	* This function should be called at the start of the turn, to determine if the
	* current player cannot move and lose
	* @param player is the side to check. 1 means Black, 2 means Red
	* @return true if the checked player cannot make any other move
	* 		false if the checked player can make another move
	*/
	public boolean isLost(int player)
	{
		if (player != 1 && player != 2)
			throw new IndexOutOfBoundsException();
		for(int i = 0; i < BOARD_SIZE; i++)
		for(int j = 0; j < BOARD_SIZE; j++)
		if (board[i][j] == player || board[i][j] == player + 2)			//check for all of this player's normal and king piece
		{
			LinkedList<IntPair> check = legalMoves(i, j, false);
			if (check.size() > 0)	//still have some legal moves
				return false;
		}
		return true;	//check pieces, found no hope
	}
	
	/**
	* get the board
	* @return an 8x8 int array representing the board
	*/
	public int[][] getBoard()
	{
		return board;
	}

	/**
	* print board to System.out
	*/
	public void printBoard()
	{
		for (int i = 0; i < BOARD_SIZE; i++)
		{
			for (int j = 0; j < BOARD_SIZE; j++)
				System.out.print(board[i][j] + " ");
			System.out.println();
		}
	}
}
