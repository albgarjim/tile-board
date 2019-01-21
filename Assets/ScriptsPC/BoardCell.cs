using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardCell {
	public string bg;
	public BoardPiece board_piece = null;

	public BoardCell(){

	}
}

public class BoardGame {
	List<List<BoardCell>> board_game = new List<List<BoardCell>>();
	int board_size;

	public BoardGame(int _size){
		board_size = _size;

		for(int I = 0; I < board_size; I++){
			List<BoardCell> board_row = new List<BoardCell>();
			for(int K = 0; K < board_size; K++){
				BoardCell cell = new BoardCell();
				cell.bg = (I + K)%2 == 0 ? "#" : " "; 
				board_row.Add(cell);
			}
			board_game.Add(board_row);
		}
	}

	public void PutPiece(int _row, int _col, BoardPiece _piece){
		board_game[_row][_col].board_piece = _piece;
		_piece.placed = true;
	}	

	public void QuitPieces(){
		for(int I = 0; I < board_size; I++) {
			for(int K = 0; K < board_size; K++){
				if(board_game[I][K].board_piece != null){
					board_game[I][K].board_piece.placed = false;
					board_game[I][K].board_piece = null;
				}
			}
		}	
	}


	public void DrawBoard(){
		GameObject.Find("TestDraw").GetComponent<Text>().text = "";
		for(int I = 0; I < board_size; I++) {
			string row = "";
			for(int K = 0; K < board_size; K++){
				if(board_game[I][K].board_piece == null){
					row += "   " + board_game[I][K].bg;
				} else {
					row += "   " + board_game[I][K].board_piece.name;
				}
			}
			GameObject.Find("TestDraw").GetComponent<Text>().text += row + "\n";
		}	
	}
}
