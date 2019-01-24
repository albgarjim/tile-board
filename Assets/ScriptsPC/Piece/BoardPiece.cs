using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item {
	public GameObject model;
	public Vector3 pos;

	public Glob.type typ;
	public Glob.locat locat = Glob.locat.NONE;
	public Glob.player owner = Glob.player.NONE;
	public int id = 0;

	public Item(){
		id = Glob.count;
		Glob.count++;	
	}
}

public class BoardCell : Item {
	public BoardCell() : base() {
		typ = Glob.type.CELL;
	}

	public void LoadModel(GameObject _go, Vector3 _pos, Quaternion _q){
		model = (GameObject)GameObject.Instantiate(_go, _pos, _q); 
		model.name = "cell_" + id.ToString();
		Glob.name_item[model.name] = this;	
		
	}
}

public class BoardPiece : Item {
	public BoardPiece() : base() {
		typ = Glob.type.PIECE;
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/base"));
		model.name = "piece_" + id.ToString();
		Glob.name_item[model.name] = this;	
	}

}

public class Mage : BoardPiece {
	public Mage(){
		typ = Glob.type.PIECE;
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/mage"));
		model.name = "piece-mage_" + id.ToString();
		Glob.name_item[model.name] = this;
	}
}
