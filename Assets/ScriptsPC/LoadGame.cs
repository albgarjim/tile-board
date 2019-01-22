using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadGame : MonoBehaviour {
	Player player1 = new Player("mr cat", new Vector3(-4, -4, 0), 2, 6);
	Player player2 = new Player("mr dog", new Vector3(-4,  7, 0), 2, 6);

	void Start () {
		Glob.draw_board_game = GameObject.Find("object_board").GetComponent<DrawBoardGame>();

		Glob.shop = new PieceShop();

		Glob.draw_board_game.DrawBoard();
		Glob.draw_board_game.DrawStash(player1);
		Glob.draw_board_game.DrawStash(player2);

		player1.AddPieceStash(new Mage());
		player1.AddPieceStash(new BoardPiece());
		player1.AddPieceStash(new BoardPiece());
		player1.AddPieceStash(new BoardPiece());
		player1.AddPieceStash(new BoardPiece());

		player2.AddPieceStash(new BoardPiece());
		player2.AddPieceStash(new BoardPiece());
		player2.AddPieceStash(new BoardPiece());
		player2.AddPieceStash(new BoardPiece());		
		player2.AddPieceStash(new BoardPiece());		
	}

	public void BuyPiecePlayer1(){
		Glob.shop.GivePieceToPlayer(player1);
	}

	public void EndWait(){
		player1.PutPiecesOnBoard(0, 0, 1, 1, 0, 6);
		player2.PutPiecesOnBoard(7, 6, 7, 2, 7, 7);
	}

	public void EndFight(){
		player1.QuitPiecesFromBoard();
		player2.QuitPiecesFromBoard();

		player1.health--;
		player1.gold++;

		player2.health--;
		player2.gold++;

		/*
		GameObject.Find("player1_hp").GetComponent<Text>().text = player1.health.ToString();
		GameObject.Find("player1_gold").GetComponent<Text>().text = player1.gold.ToString();

		GameObject.Find("player2_hp").GetComponent<Text>().text = player2.health.ToString();
		GameObject.Find("player2_gold").GetComponent<Text>().text = player2.gold.ToString();

		Glob.shop.ShowShop();*/
	}

	void Update () {
		Glob.draw_board_game.DrawPiecesStash(player1);
		Glob.draw_board_game.DrawPiecesStash(player2);
		Glob.draw_board_game.DrawPiecesBoard(player1);
		Glob.draw_board_game.DrawPiecesBoard(player2);		
	}
}
