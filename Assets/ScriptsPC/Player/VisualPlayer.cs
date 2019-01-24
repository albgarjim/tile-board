using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class VisualPlayer {
	public Vector3 offset;
	protected Vector3 v_piece_offset = new Vector3(0, 0, -0.7f);
	public List<BoardCell> slist = new List<BoardCell>();
	public Player p;

	public VisualPlayer(Glob.player _name, Vector3 _offset, int _max_board, int _max_stash){
		offset = _offset;
		p = new Player(_name, _max_board, _max_stash);
	}

	public void CreateStash(){
		slist = Glob.draw_board_game.DrawStash(offset);    
	}

	public void DrawPiecesStash(){
		for (int I = 0; I < p.pixels.Count; I++) {
			if(p.pixels[I].locat == Glob.locat.STASH){
				p.pixels[I].model.transform.position = slist[p.pixels[I].id].pos + v_piece_offset;
			}
		}
	}

	public void DrawPiecesBoard(){
		for (int I = 0; I < p.pixels.Count; I++) {
			if(p.pixels[I].locat == Glob.locat.BOARD){
				p.pixels[I].model.transform.position = p.pixels[I].pos + Glob.board_offset;
			}
		}		
	}	
}