using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoadGame : MonoBehaviour {
	public int board_size;
	

	Player player1 = new Player("mr cat");
	Player player2 = new Player("mr dog");

	void Start () {
		Glob.board = new BoardGame(board_size);

		player1.AddPiece(new BoardPiece("G"));
		player1.AddPiece(new BoardPiece("D"));
		player1.AddPiece(new BoardPiece("E"));

		player2.AddPiece(new BoardPiece("G"));
		player2.AddPiece(new BoardPiece("G"));
		player2.AddPiece(new BoardPiece("Q"));		
	}
	
	public void EndWait(){
		player1.PutPiecesOnBoard(0, 0, 1, 1, 0, 6);
		player1.PutPiecesOnBoard(7, 6, 7, 2, 7, 7);
		Glob.board.DrawBoard();
	}

	public void EndFight(){
		Glob.board.QuitPieces();
		Glob.board.DrawBoard();

		player1.health--;
		player1.gold++;

		player2.health--;
		player2.gold++;

		GameObject.Find("player1_hp").GetComponent<Text>().text = player1.health.ToString();
		GameObject.Find("player1_gold").GetComponent<Text>().text = player1.gold.ToString();

		GameObject.Find("player2_hp").GetComponent<Text>().text = player2.health.ToString();
		GameObject.Find("player2_gold").GetComponent<Text>().text = player2.gold.ToString();
	}

	void Update () {
		
	}
}
