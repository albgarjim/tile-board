using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Create1v1 {
	DrawBoardGame board;
	Vector3 board_offset;
	Vector3 p1_offset;
	Vector3 p2_offset;

	public VisualPlayer p1;
	public VisualPlayer p2;

	public VisualPlayer turn;
	public Item selected;

	public Create1v1(Vector3 _offset, VisualPlayer _player1, VisualPlayer _player2){
		board = new DrawBoardGame();
		board.Initialize(8, 10);
		board.DrawBoard(_offset);

		board_offset = _offset;

		p1 = _player1;
		p1_offset = new Vector3(-1, -2, 0) + board_offset;
		p1.slist = board.DrawStash(p1_offset);

		p2 = _player2;
		p2_offset = new Vector3(-1, 9, 0) + board_offset;
		p2.slist = board.DrawStash(p2_offset);

		p1.AddPieceStash(new Mage());
		p1.AddPieceStash(new BoardPiece());
		p1.AddPieceStash(new BoardPiece());
		p1.AddPieceStash(new BoardPiece());
		p1.AddPieceStash(new BoardPiece());

		p2.AddPieceStash(new BoardPiece());
		p2.AddPieceStash(new BoardPiece());
		p2.AddPieceStash(new BoardPiece());
		p2.AddPieceStash(new BoardPiece());		
		p2.AddPieceStash(new BoardPiece());
		p2.AddPieceStash(new Dummy());	

		turn = p1;
	}	
}