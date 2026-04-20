## Entities
* Player (2 players, are assigned a marker)
* Board (9 spaces, only one marker per space)
* Marker (X / O)

## Game Flow Description
* Two players start the game
* Players choose their marks
* Players decide who goes first
* First player puts their marker in an empty space
* Second player puts their marker in an empty space
* Both players continue until one player gets three in a row (winner) or there are no empty space left on the board

## User Journeys
* Persona 1 'Jim' wins with three in a row when:
    * Jim is assigned the X marker
    * Jim goes first
    * 1 - Jim places a mark in the top left cell
    * 2 - His opponent places a mark in middle cell
    * 3 - Jim places a mark in the top middle cell
    * 4 - His opponent places a mark in the left middle cell
    * 5 - Jim places a mark in the top right cell - connecting 3 marks
    * Both players are notified that Jim has won and no more marks can be placed

* Persona 1 'Jim' and Persona 2 'Bob' tie:
    * Jim is assigned the X marker and Bob the 0 marker
    * Jim goes first
    * 1 - Jim places his marker in the top left cell
    * 2 - Bob places his marker in the bottom right cell
    * 3 - Jim places his marker in the bottom left cell
    * 4 - Bob places his marker in the left middle cell
    * 5 - Jim places his marker in the top middle cell
    * 6 - Bob places his marker in the top right cell
    * 7 - Jim places his marker in the middle cell
    * 8 - Bob places his marker in the bottom middle cell
    * 9 - Jim places his marker in the middle right cell
    * All cells have been filled and neither player have met the win-condition of connecting three, so it is a draw
    * Both players are notified that it is a draw

What about user journeys for...
* Start game
* Gameplay loop
* End game / post game

---

* Win-check algorithm
    * From the 5th turn onwards (first players 3rd turn)
        * When a player marks a cell, for the cell they just marked
            * for the row, column and diagonal that cell is part of
                * if the row/column/diagonal contains 3 marks of the same type
                    * they have won -> end game
                * else
                    continue

Three Arrays

Array 1 - | 1 | 2 | 3 |

Array 2 - | 4 | 5 | 6 |

Array 3 - | 7 | 8 | 9 |

How 