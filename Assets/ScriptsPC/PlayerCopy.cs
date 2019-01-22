using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCopy {
	public int health = 100;
	public int gold = 5;
	public string name;

	public int max_board;
	public int max_stash;

	public Vector3 offset;
	public List<BoardCell> stash = new List<BoardCell>();
	public List<BoardCell> board = new List<BoardCell>();

	public PlayerCopy(string _name, Vector3 _offset, int _max_board, int _max_stash){
		name = _name;
		offset = _offset;

		max_board = _max_board;
		max_stash = _max_stash;
		for (int I = 0; I < max_board; I++){
			board.Add(new BoardCell());
		}
	}

	public void AddPieceStash(BoardPiece _piece){
		for(int I = 0; I < stash.Count; I++){
			if(stash[I].piece == null){
				stash[I].piece = _piece;
				break;
			}
		}
	}

	public void MovePieceToBoard(int _id, int _x, int _y){
		for(int I = 0; I < board.Count; I++){
			if(board[I].piece == null){
				board[I].piece = stash[_id].piece;
				board[I].pos = new Vector3(_x, _y, -0.7f);
				break;
			}
		}
	}

	public void PutPiecesOnBoard(int _x1, int _y1, int _x2, int _y2, int _x3, int _y3){
		MovePieceToBoard(0, _x1, _y1);
		stash[0].piece = null;

		MovePieceToBoard(1, _x2, _y2);
		stash[1].piece = null;

		MovePieceToBoard(3, _x3, _y3);
		stash[3].piece = null;		
	}

	public void QuitPiecesFromBoard(){
		for(int I = 0; I < board.Count; I++){
			AddPieceStash(board[I].piece);
			board[I].piece = null;
		}

	}

}