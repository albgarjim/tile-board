using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateGame {
	DrawBoardGame board;
	Vector3 board_offset;
	Vector3 p1_offset;
	Vector3 p2_offset;

	VisualPlayer player1;
	VisualPlayer player2;

	public VisualPlayer turn;
	public Item selected;

	public CreateGame(Vector3 _offset, VisualPlayer _player1, VisualPlayer _player2){
		board = new DrawBoardGame();
		board.Initialize(8, 10);
		board.DrawBoard(_offset);

		board_offset = _offset;

		player1 = _player1;
		p1_offset = new Vector3(-1, -2, 0) + board_offset;
		player1.slist = board.DrawStash(p1_offset);

		player2 = _player2;
		p2_offset = new Vector3(-1, 9, 0) + board_offset;
		player2.slist = board.DrawStash(p2_offset);

		player1.AddPieceStash(new Mage());
		player1.AddPieceStash(new BoardPiece());
		player1.AddPieceStash(new BoardPiece());
		player1.AddPieceStash(new BoardPiece());
		player1.AddPieceStash(new BoardPiece());

		player2.AddPieceStash(new BoardPiece());
		player2.AddPieceStash(new BoardPiece());
		player2.AddPieceStash(new BoardPiece());
		player2.AddPieceStash(new BoardPiece());		
		player2.AddPieceStash(new BoardPiece());	

		turn = player1;
	}	
}