# Game Jam Base Code
The purpose is to bootstrap the game prototyping during game jams. The base code is written on Unity with C#.

## Scenes

1. `Menu` - displays logo, credits and START and EXIT buttons
2. `Main` - core scene for the game itself
3. `Victory` - displays victory title and score
4. `Game Over` - displays game over title and score

## Scripts

1. `GameManager` - contains the game state and core logic 
2. `HotKeys` - listens for shortcuts
3. `WinLoseConditions` - Contains the win / lose conditions and triggers victory or game over accordingly.
4. `ScoreLabel` - being attached to a UI Text component, displays current score

## Shortcuts

|Key|Action
|--|--
|S|Increment the score
|W|Trigger victory
|L|Trigger game over
|H|Go to the main menu
