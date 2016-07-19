Author: Duc Le
Date: 7/13/2016

I) Introduction:
CheckerDriver.java is an implementation of the game Checker. TestCheckerDriver.java is the jUnit test for CheckerDriver.java,
and IntPair.java is a helper class.

II) Implementation:
CheckerDriver implements the Checker board as an 8x8 array of integers:
	0 for empty square
	1 for black piece
	2 for red piece
	3 for kinged black piece
	4 for kinged red piece
See CheckerDriver.html for info on key methods.

III) Game Flow: Black goes first, and will be player 1
1) The constructor creates an initial board with normal black and red pieces.
2) Each player conduct their turns, each turn includes:
	a) calling isLost() to check if the player cannot move and lose. If so, the game ends.
	b) The player select a pieces to move.
	c) calling legalMoves(), get the list of all legal moves for that piece
	d) If player chooses an illegal square, alert.
	e) Repeat d until player select a legal square
	f) calling movePiece(), to move the piece and king it if necessary. The function will modify the board and return 
		true or false.
	g) If movePiece() return true, the player just complete a jump, and that piece can jump again.
		Continue calling legalMoves() for the new position, with justJump = true, and proceed to movePiece() until
		it cannot jump anymore (movePiece() return false or legalMoves() return an empty list).
	h) If movePiece() return false, the turn is ended.
	i) The turn goes to the other player, repeat.
3) When isLost() return true, the game ends and the other player is called the victor.

IV) Connection:
CheckerDriver is Serializable, the whole object can be sent between machines.
Alternatively, the int[][] board can be sent after movePiece() is called (using getBoard()). Then, the other machine will
receive the array and call setBoard() to modify its local board.
   

