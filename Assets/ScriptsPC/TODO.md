##Mover pieza a casilla ocupada
track pieces in cells?

1.- add click listener on cell to return id
2.- each frame track possition of pieces on board:
	-access the pos of each piece
	-raycast to detect what object is under the center of the piece
	-retrieve the id of the object

	-In DrawBoardGame create a map to map id to BoardCell object


-Remove stash list from visual player by just giving each piece a position