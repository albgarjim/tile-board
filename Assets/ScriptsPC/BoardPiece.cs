using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item {
	public GameObject model;
	protected Vector3 pos;

	public Vector3 offset;

	public Glob.type typ;
	public Glob.locat locat = Glob.locat.NONE;
	public Glob.player owner = Glob.player.NONE;
	protected static int count = 0;
	public int id = 0;

	public Item(){
		id = count;
		count++;	
	}

	public Vector3 GetPos(){
		return pos;
	}
	public void SetPos(Vector3 _pos){
		pos = _pos + offset;
	}
}

public class BoardCell : Item {
	
	public BoardCell(Vector3 _offset) : base() {
		typ = Glob.type.CELL;
		offset = _offset;
	}

	public void LoadModel(GameObject _go, Vector3 _pos, Quaternion _q){
		model = (GameObject)GameObject.Instantiate(_go, _pos, _q); 
		model.name = "cell_" + id.ToString();
		Glob.name_item[model.name] = this;		
	}
}

public class BoardPiece : Item {
	
	public BoardPiece() : base() {
		offset = new Vector3(0, 0, -0.7f);
		typ = Glob.type.PIECE;
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/base"));
		model.name = "piece_" + id.ToString();
		Glob.name_item[model.name] = this;	
	}
}

public class Mage : BoardPiece {

	public Mage() : base(){
		typ = Glob.type.PIECE;
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/mage"));
		model.name = "piece-mage_" + id.ToString();
		Glob.name_item[model.name] = this;
	}
}
