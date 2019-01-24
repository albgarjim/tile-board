using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glob {
	public enum locat {NONE, BOARD, STASH};
	public enum type {CELL, PIECE, BOARD_CELL, STASH_CELL};
	public enum player {NONE, PLAYER1, PLAYER2}
	public static Item selected;
	public static PieceShop shop;
	public static DrawBoardGame draw_board_game;
	public static int board_size = 8;

	public static Vector3 board_offset = new Vector3(-3, -2, 0);
	public static int max_stash = 10;

	public static Dictionary<string, Item> name_item = new Dictionary<string, Item>();
	public static int count = 0;	
}