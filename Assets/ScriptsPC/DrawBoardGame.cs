using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardCell {
	public GameObject bg;
	public BoardPiece piece;
	public bool is_empty;

	public Vector3 pos;
	public BoardCell(){
	}
}

public class DrawBoardGame : MonoBehaviour {
	public GameObject cell_dark;
	public GameObject cell_light;

	List<List<BoardCell>> board_cells = new List<List<BoardCell>>();

	protected bool is_drawn = false;
	protected Vector3 v_board_offset = new Vector3(-3, -2, 0);
	protected Vector3 v_piece_offset = new Vector3(0, 0, -0.7f);

	public void DrawBoard(){
		if(!is_drawn){
		    for (int I = 0; I < Glob.board_size; I++) {
		    	List<BoardCell> row = new List<BoardCell>();
		        for (int K = 0; K < Glob.board_size; K++) {
					BoardCell cv = new BoardCell();
					cv.pos = new Vector3(I, K, 0) + v_board_offset;

					cv.bg = (I + K)%2 == 0 ? 
						Instantiate(cell_dark, cv.pos, Quaternion.identity) 
						: 
						Instantiate(cell_light, cv.pos, Quaternion.identity);
		        	row.Add(cv);
		        			            
		        }
		        board_cells.Add(row);
		    }
		    is_drawn = true;
		}
	}

	public void DrawStash(Player _player){
        for (int I = 0; I < Glob.max_stash_size; I++) {
			BoardCell bc = new BoardCell();
			bc.pos = new Vector3(I, 0, 0) + _player.offset;

			if(I%2 == 0){
				bc.bg = Instantiate(cell_light, bc.pos, Quaternion.identity);
			} else {
				bc.bg = Instantiate(cell_dark, bc.pos, Quaternion.identity);
			}   
			_player.stash.Add(bc);        
        }	    
	}

	public void DrawPiecesStash(Player _player){
		for (int I = 0; I < _player.pixels.Count; I++) {
			if(_player.pixels[I].locat == Glob.locat.STASH){
				_player.pixels[I].model.transform.position = _player.stash[_player.pixels[I].st_id].pos + v_piece_offset;
			}
		}
	}

	public void DrawPiecesBoard(Player _player){
		for (int I = 0; I < _player.pixels.Count; I++) {
			if(_player.pixels[I].locat == Glob.locat.BOARD){
				_player.pixels[I].model.transform.position = _player.pixels[I].pos + v_board_offset;
			}
		}		
	}

}
