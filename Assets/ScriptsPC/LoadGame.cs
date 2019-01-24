using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadGame : MonoBehaviour {
	List<VisualPlayer> players = new List<VisualPlayer>();

	void Start () {
		players.Add(new VisualPlayer(Glob.player.PLAYER1, new Vector3(-4, -4, 0), 2, 6));
		players.Add(new VisualPlayer(Glob.player.PLAYER2, new Vector3(-4,  7, 0), 2, 6));

		Glob.draw_board_game = GameObject.Find("object_board").GetComponent<DrawBoardGame>();

		Glob.shop = new PieceShop();

		Glob.draw_board_game.DrawBoard();
		players[0].CreateStash();
		players[1].CreateStash();

		players[0].p.AddPieceStash(new Mage());
		players[0].p.AddPieceStash(new BoardPiece());
		players[0].p.AddPieceStash(new BoardPiece());
		players[0].p.AddPieceStash(new BoardPiece());
		players[0].p.AddPieceStash(new BoardPiece());

		players[1].p.AddPieceStash(new BoardPiece());
		players[1].p.AddPieceStash(new BoardPiece());
		players[1].p.AddPieceStash(new BoardPiece());
		players[1].p.AddPieceStash(new BoardPiece());		
		players[1].p.AddPieceStash(new BoardPiece());		
	}

	public void BuyPiecePlayer1(){
		Glob.shop.GivePieceToPlayer(players[0].p);
	}

	public void EndWait(){
		players[0].p.PutPiecesOnBoard(0, 0, 1, 1, 0, 6);
		players[1].p.PutPiecesOnBoard(7, 6, 7, 2, 7, 7);
	}

	public void EndFight(){
		players[0].p.QuitPiecesFromBoard();
		players[1].p.QuitPiecesFromBoard();

		players[0].p.health--;
		players[0].p.gold++;

		players[1].p.health--;
		players[1].p.gold++;

		/*
		GameObject.Find("player1_hp").GetComponent<Text>().text = player1.health.ToString();
		GameObject.Find("player1_gold").GetComponent<Text>().text = player1.gold.ToString();

		GameObject.Find("player2_hp").GetComponent<Text>().text = player2.health.ToString();
		GameObject.Find("player2_gold").GetComponent<Text>().text = player2.gold.ToString();

		Glob.shop.ShowShop();*/
	}

	void Update () {
		foreach(VisualPlayer p in players){
			p.DrawPiecesStash();
			p.DrawPiecesBoard();		
		}	
	}
}
