using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieceShop {	
	public List<BoardPiece> shop_pieces = new List<BoardPiece>();

	public PieceShop(){
		shop_pieces.Add(new Mage());
		shop_pieces.Add(new Mage());
		shop_pieces.Add(new Mage());		
	}

	public void ShowShop(){
		
	}

	//TODO: Can cause concurrency problems if 2 players remove at same time
	public void GivePieceToPlayer(VisualPlayer _player){
		if(shop_pieces.Count > 0){
			int id = Random.Range(0, shop_pieces.Count);
			_player.AddPieceStash(shop_pieces[id]);
			shop_pieces.RemoveAt(id);
		}
	}

}
