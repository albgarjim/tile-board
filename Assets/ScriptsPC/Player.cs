using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player {
	public int health = 100;
	public int gold = 5;
	public string name;

	public int max_board;
	public int max_stash;

	public Vector3 offset;

	public List<BoardCell> stash = new List<BoardCell>();	
	public List<BoardPiece> pixels = new List<BoardPiece>();

	public List<int> queue = new List<int>();

	public int GetFirst(){
		int val = queue[0];
		queue.RemoveAt(0);
		return val;
	}

	public Player(string _name, Vector3 _offset, int _max_board, int _max_stash){
		name = _name;
		offset = _offset;
		max_board = _max_board;
		max_stash = _max_stash;

		for(int I = 0; I < max_stash; I++) queue.Add(I);
	}

	public bool AddPieceStash(BoardPiece _piece){
		if(queue.Count > 0){
			pixels.Add(_piece);
			_piece.locat = Glob.locat.STASH;
			_piece.st_id = GetFirst();
			return true;
		}
		return false;
	}

	public bool MovePieceToBoard(int _id, int _x, int _y){
		if(pixels.Count - (max_stash - queue.Count) < max_board){
			pixels[_id].locat = Glob.locat.BOARD;
			pixels[_id].pos = new Vector3(_x, _y, -0.7f);
			queue.Add(pixels[_id].st_id);
			queue.Sort();
			return false;
		}
		return true;
	}

	public void PutPiecesOnBoard(int _x1, int _y1, int _x2, int _y2, int _x3, int _y3){
		MovePieceToBoard(0, _x1, _y1);
		MovePieceToBoard(1, _x2, _y2);
		MovePieceToBoard(3, _x3, _y3);
	}

	public void QuitPiecesFromBoard(){
		for(int I = 0; I < pixels.Count; I++){
			if(pixels[I].locat == Glob.locat.BOARD && queue.Count > 0){
				pixels[I].locat = Glob.locat.STASH;
				pixels[I].st_id = GetFirst();
			}
		}
	}

}