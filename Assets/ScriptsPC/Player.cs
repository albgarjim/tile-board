using System.Collections;
using System.Collections.Generic;

public class Player{
	public int health = 100;
	public int gold = 5;
	public string name;

	public List<BoardPiece> player_pieces = new List<BoardPiece>();

	public Player(string _name){
		name = _name;
	}

	public void AddPiece(BoardPiece _board_piece){
		player_pieces.Add(_board_piece);
	}

	public void RemovePiece(){

	}


	public void PutPiecesOnBoard(int _x1, int _y1, int _x2, int _y2, int _x3, int _y3){
		Glob.board.PutPiece(_x1, _y1, player_pieces[0]);
		Glob.board.PutPiece(_x2, _y2, player_pieces[1]);
		Glob.board.PutPiece(_x3, _y3, player_pieces[2]);
	}

	public void QuitPiecesFromBoard(){

	}

}