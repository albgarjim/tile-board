using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

class Updater{

	public static void UpdatePieces(Create1v1 _cg) {
		_cg.p1.DrawPieces();		
		_cg.p2.DrawPieces();

		if(Input.GetMouseButtonDown(0)){
	    	Ray ray = new Ray();
	    	RaycastHit hit = new RaycastHit();
	        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        if(Physics.Raycast(ray, out hit)) {
	        	Debug.Log(Glob.name_item[hit.collider.name].owner);
	        	switch(Glob.name_item[hit.collider.name].typ){
	        		case Glob.type.PIECE:
	        			_cg.selected = Glob.name_item[hit.collider.name];
	            		Debug.Log(_cg.selected.model.name);
	            		Debug.LogFormat("DMG: {0} || AS: {1} || HP : {2} ", _cg.selected.damage, _cg.selected.at_speed, _cg.selected.health);
	        			break;
	        		case Glob.type.CELL:
						if(_cg.selected != null && _cg.selected.typ == Glob.type.PIECE){

							Debug.Log(hit.collider.transform.position);
							if(CellIsEmpty(hit.collider.transform.position) ){
								_cg.turn.MovePiece(_cg.selected.model.name, hit.collider.name);
							}

							
	            		}	        		
	        			break;
	        	}
	        	
	        }	
		}
	}


	

	static bool CellIsEmpty(Vector3 _pos){
        RaycastHit[] hits = Physics.RaycastAll(_pos, Vector3.back);
        if(hits.Length > 0){
        	Debug.Log("Cell occupied");
        	return false;        	
        }
        return true;
	}

}

