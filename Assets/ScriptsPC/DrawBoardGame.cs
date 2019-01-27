using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawBoardGame {
	public GameObject cell_dark;
	public GameObject cell_light;

	protected int board_size;
	protected int max_stash;

	public DrawBoardGame(){
		cell_dark = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/cell_dark"));
		cell_light = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/cell_light"));
	}

	public List<List<BoardCell>> board_cells = new List<List<BoardCell>>();

	public void Initialize(int _board_size, int _max_stash){
		board_size = _board_size;
		max_stash = _max_stash;	
	}

	public void DrawBoard(Vector3 _offset){	
	    for (int I = 0; I < board_size; I++) {
	    	List<BoardCell> row = new List<BoardCell>();
	        for (int K = 0; K < board_size; K++) {
				BoardCell cv = new BoardCell(_offset);
				cv.SetPos(new Vector3(K, I, 0));
				cv.locat = Glob.locat.BOARD;

				GameObject cell_bg = (I + K)%2 == 0 ? cell_dark : cell_light;
				cv.LoadModel(cell_bg, cv.GetPos(), Quaternion.identity);
				if(I < 4) cv.owner = Glob.player.PLAYER1;
				else if (I >= 4 && I < 8) cv.owner = Glob.player.PLAYER2;
	        	row.Add(cv);        
	        }
	        board_cells.Add(row);
	    }
	}

	public List<BoardCell> DrawStash(Vector3 _offset){
		List<BoardCell> stash = new List<BoardCell>();
        for (int I = 0; I < max_stash; I++) {
   			BoardCell bc = new BoardCell(_offset);
   			bc.locat = Glob.locat.STASH;
			bc.SetPos(new Vector3(I, 0, 0));

			GameObject cell_bg = I%2 == 0 ? cell_light : cell_dark;
			bc.LoadModel(cell_bg, bc.GetPos(), Quaternion.identity);

			stash.Add(bc);  
        }	

        return stash;    
	}



}
