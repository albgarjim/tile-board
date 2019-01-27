using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadGame : MonoBehaviour {
	List<VisualPlayer> players = new List<VisualPlayer>();
	CreateGame cg;

	void Start () {
		Glob.shop = new PieceShop();

		players.Add(new VisualPlayer(Glob.player.PLAYER1, 2, 6));
		players.Add(new VisualPlayer(Glob.player.PLAYER2, 2, 6));

		cg = new CreateGame(new Vector3(-3, -2, 0), players[0], players[1]);
	}

	public void BuyPiecePlayer1(){
		Glob.shop.GivePieceToPlayer(players[0]);
	}

	public void EndWait(){
		players[0].MovePiece("piece-mage_87", "cell_3");
		players[0].MovePiece("piece_88", "cell_4");
	}

	public void EndFight(){
		players[0].QuitPiecesFromBoard();
		players[1].QuitPiecesFromBoard();

		players[0].health--;
		players[0].gold++;

		players[1].health--;
		players[1].gold++;
	}

	void Update () {
		foreach(VisualPlayer p in players){
			p.DrawPieces();		
		}	

		if(Input.GetMouseButtonDown(0)){
	    	Ray ray = new Ray();
	    	RaycastHit hit = new RaycastHit();
	        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        if(Physics.Raycast(ray, out hit)) {
	        	Debug.Log(Glob.name_item[hit.collider.name].owner);
	        	switch(Glob.name_item[hit.collider.name].typ){
	        		case Glob.type.PIECE:
	        			cg.selected = Glob.name_item[hit.collider.name];
	            		Debug.Log(cg.selected.model.name);
	        			break;
	        		case Glob.type.CELL:
						if(cg.selected != null && cg.selected.typ == Glob.type.PIECE){

							cg.turn.MovePiece(cg.selected.model.name, hit.collider.name);
	            		}	        		
	        			break;
	        	}
	        	
	        }	
		}


	}
}
