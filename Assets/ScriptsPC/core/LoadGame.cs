using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadGame : MonoBehaviour {
	protected Create1v1 cg;
	protected List<VisualPlayer> players;

	void Start () {
		Glob.shop = new PieceShop();
		players = new List<VisualPlayer>();

		players.Add(new VisualPlayer(Glob.player.PLAYER1, 10, 10));
		players.Add(new VisualPlayer(Glob.player.PLAYER2, 10, 10));

		cg = new Create1v1(new Vector3(-3, -2, 0), players[0], players[1]);
	}

	public void BuyPiecePlayer1(){
		Glob.shop.GivePieceToPlayer(players[0]);
	}

	public void EndWait(){
		cg.p1.MovePiece("piece-mage_87", "cell_3");
		cg.p1.MovePiece("piece_88", "cell_4");
		foreach (BoardPiece it in cg.p1.pixels){
			it.Evolve();
		}
		foreach (BoardPiece it in cg.p2.pixels){
			it.Evolve();
		}		
	}

	public void EndFight(){
		cg.p1.QuitPiecesFromBoard();
		cg.p2.QuitPiecesFromBoard();

		cg.p1.health--;
		cg.p1.gold++;

		cg.p2.health--;
		cg.p2.gold++;
	}

	public void Update(){
		Updater.UpdatePieces(cg);
	}

}
