# SnakeCombatScripts
Scripts that work on my "SnakeCombat" game that I made on Unity

Project Steps
1. Background, borders and snake visuals of the game were prepared.
2. Images/sprites were placed on the game stage in appropriate sizes, and prefabs created.
3. Game design and C# scripts are prepared for the snake movement, getting input from the keyboard and fixing bugs on movement. (GitHub SnakeCombatScripts Repository -> Snake.cs)
4. GameHandler script was created for the management of the game. In this script; eating the food, hitting the game borders and hitting snake body are checked during snake's movement. (GitHub SnakeCombatScripts Repository -> GameHandler.cs)
5. In order for the snake to grow after eating the food, the GrowUp() method in the Snake class was called from the GameHandler class.
6. In the snake script, each position where the snake moves is saved as a list object. Each new point of movement of the snake is inserted to the list. (snakeBodySize-1) element has been kept in this position list.
7. When the GrowUp method runs, the snakeBodySize variable, which is kept as an integer, is increased by 1. Each time snakeBodySize increases, the "snakeGridPositionList" List object will also increase in size by one.
8. Also, every time the GrowUp method runs, a snakeBody game object will be created with the Instantiate method. The position of game object instances will be updated continuously by matching the snakeGridPositionList elements. (GitHub SnakeCombatScripts Repository -> Snake.cs)
9. Thus; the movement and growth of the snake, and the movement of its body behind its head was enabled.
10. Visuals of Game UI elements were prepared, their placement on the game scene was made and the buttons were assigned to the relevant methods.(GitHub SnakeCombatScripts Repository -> SceneManager.cs)
11. The main menu has been created for the entry of the game.
12. The game has been made operational as a classic snake game.
13. Subsequently, a new structure was designed so that 2 players can play on the same keyboard. Control keys of Player1 are W, A, S, D ; and control keys of Player2 are direction arrow keys.
14. All the scripts of the scene that was completed as a single player, could not be used in the same way. Because 2 separate snake scripts had to be run for the movements for 2 separate snakes, and the controls for eating food, dimension controls and collision controls. In addition, GameHandler2 script controls 2 times more data than GameHandler script.
15. GameHandler2, SceneManager2, Snake2 and Snake3 scripts for multi-player game scene have been adapted to the game scene for multiplayer.
16. Bug fixes and tests have been made, the game has been made ready.
