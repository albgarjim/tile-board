using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardPiece {
	public GameObject model;
	public Vector3 pos;
	public Glob.locat locat = Glob.locat.NONE;
	public int st_id;

	public BoardPiece(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/base"));
	}

}

public class Mage : BoardPiece {
	public Mage(){
		model = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/mage"));
	}
}
