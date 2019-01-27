using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class VisualPlayer {
	public int health = 100;
	public int gold = 5;
	public int max_board;
	public int max_stash;

	public Glob.player name;
	
	public List<int> queue = new List<int>();
	public List<BoardCell> slist = new List<BoardCell>();
	public List<BoardPiece> pixels = new List<BoardPiece>();	

	public int GetFirst(){
		int val = queue[0];
		queue.RemoveAt(0);
		return val;
	}

	public VisualPlayer(Glob.player _name, int _max_board, int _max_stash){
		name = _name;
		max_board = _max_board;
		max_stash = _max_stash;
		for(int I = 0; I < max_stash; I++) queue.Add(I);
	}
	public void DrawPieces(){
		for (int I = 0; I < pixels.Count; I++) {
			pixels[I].model.transform.position = pixels[I].GetPos();
		}
	}

	public void QuitPiecesFromBoard(){
		for(int I = 0; I < pixels.Count; I++){
			if(pixels[I].locat == Glob.locat.BOARD && queue.Count > 0){
				pixels[I].locat = Glob.locat.STASH;
				pixels[I].id = GetFirst();
				pixels[I].SetPos(slist[pixels[I].id].GetPos());
			}
		}
	}

	public bool MovePiece(string _piece_name, string _cell_name){
		Debug.Log(Glob.name_item[_piece_name].locat);
		if(Glob.name_item[_piece_name].locat == Glob.locat.BOARD && Glob.name_item[_cell_name].locat == Glob.locat.BOARD){
			Debug.Log("Moving board to board");
			Glob.name_item[_piece_name].locat = Glob.name_item[_cell_name].locat;
			Glob.name_item[_piece_name].SetPos(Glob.name_item[_cell_name].GetPos());

		} else if(Glob.name_item[_piece_name].locat == Glob.locat.STASH && Glob.name_item[_cell_name].locat == Glob.locat.BOARD){
			Debug.Log("Moving stash to board");

			if(pixels.Count - (max_stash - queue.Count) < max_board){
				Glob.name_item[_piece_name].locat = Glob.locat.BOARD;
				Glob.name_item[_piece_name].SetPos(Glob.name_item[_cell_name].GetPos());
				queue.Add(Glob.name_item[_piece_name].id);
				queue.Sort();
				return true;
			}
		} else if(Glob.name_item[_piece_name].locat == Glob.locat.BOARD && Glob.name_item[_cell_name].locat == Glob.locat.STASH){
			Debug.Log("Moving board to stash");
			MoveBoardToStash(Glob.name_item[_piece_name]);
		}

		return true;
	}	

	public bool MoveBoardToStash(Item _piece){
		if(queue.Count > 0){
			_piece.locat = Glob.locat.STASH;
			_piece.owner = name;
			_piece.id = GetFirst();
			_piece.SetPos(slist[_piece.id].GetPos());
			return true;
		}
		return false;
	}

	public bool AddPieceStash(BoardPiece _piece){
		if(queue.Count > 0){
			pixels.Add(_piece);
			_piece.locat = Glob.locat.STASH;
			_piece.owner = name;
			_piece.id = GetFirst();
			_piece.SetPos(slist[_piece.id].GetPos());
			return true;
		}
		return false;
	}

}