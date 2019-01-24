using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawBoardGame : MonoBehaviour {
	public GameObject cell_dark;
	public GameObject cell_light;

	List<List<BoardCell>> board_cells = new List<List<BoardCell>>();

	public void DrawBoard(){
	    for (int I = 0; I < Glob.board_size; I++) {
	    	List<BoardCell> row = new List<BoardCell>();
	        for (int K = 0; K < Glob.board_size; K++) {
				BoardCell cv = new BoardCell();
				cv.pos = new Vector3(K, I, 0) + Glob.board_offset;

				GameObject cell_bg = (I + K)%2 == 0 ? cell_dark : cell_light;
				cv.LoadModel(cell_bg, cv.pos, Quaternion.identity);
				if(I < 4) cv.owner = Glob.player.PLAYER1;
				else if (I >= 4 && I < 8) cv.owner = Glob.player.PLAYER2;
	        	row.Add(cv);        
	        }
	        board_cells.Add(row);
	    }
	}

	public List<BoardCell> DrawStash(Vector3 _offset){
		List<BoardCell> stash = new List<BoardCell>();
		List<int> stashID = new List<int>();
        for (int I = 0; I < Glob.max_stash; I++) {
   			BoardCell bc = new BoardCell();
			bc.pos = new Vector3(I, 0, 0) + _offset;

			GameObject cell_bg = I%2 == 0 ? cell_light : cell_dark;
			bc.LoadModel(cell_bg, bc.pos, Quaternion.identity);

			stash.Add(bc);  
			stashID.Add(bc.id);     
        }	

        return stash;    
	}
     
    void Update(){
    	if(Input.GetMouseButtonDown(0)){
	    	Ray ray = new Ray();
	    	RaycastHit hit = new RaycastHit();
	        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        if(Physics.Raycast(ray, out hit)) {
	        	Debug.Log(Glob.name_item[hit.collider.name].owner);
	        	switch(Glob.name_item[hit.collider.name].typ){
	        		case Glob.type.PIECE:
	        			Glob.selected = Glob.name_item[hit.collider.name];
	            		Debug.Log(Glob.selected.model.name);
	        			break;
	        		case Glob.type.CELL:
						if(Glob.selected != null && Glob.selected.typ == Glob.type.PIECE){
	            			Glob.selected.pos = Glob.name_item[hit.collider.name].pos + new Vector3(3, 2, -0.7f);
	            			Debug.Log("2    " + Glob.selected.pos);
	            			if(Glob.selected.locat == Glob.locat.STASH)
	            				Glob.selected.locat = Glob.locat.BOARD;
	            		}	        		
	        			break;
	        	}
	        	
	        }	
    	}

    }

}
