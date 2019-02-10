using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Glob {
	public enum locat {NONE, BOARD, STASH};
	public enum type {NONE, CELL, PIECE};
	public enum player {NONE, PLAYER1, PLAYER2}
	
	public static PieceShop shop;
	public static Dictionary<string, Item> name_item = new Dictionary<string, Item>();
}