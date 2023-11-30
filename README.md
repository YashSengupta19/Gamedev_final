# GameDev
# Treasure Quest - Game Documentation

## 1. Introduction

### 1.1 Overview
"Treasure Quest" is an adventurous 2D game created using Unity. Players navigate through various obstacles, solve puzzles, and combat enemies to find a hidden treasure. The game combines elements of platforming, puzzle-solving, and strategic combat.

### 1.2 Team Members
- Yash
- Narayana
- Shreyank

## 2. Game Concept

### 2.1 Objective
The primary goal is to find a hidden treasure by solving puzzles and overcoming obstacles. Players must discover clues, avoid enemies, and successfully unlock the chest containing the treasure.

### 2.2 Gameplay Features
- Running and jumping mechanics
- Rope climbing ability
- God mode which enables the player to move as they like.
- Puzzle-solving elements
- Combat with enemies (snakes, poisonous turtles, and arrow-throwing foes)

### 2.3 Obstacles
Players will encounter snakes, poisonous turtles, and enemies equipped with arrows. Successfully navigating through these obstacles is crucial to reaching the treasure.

## 3. Controls

### 3.1 Basic Controls
- Arrow keys/WASD: Movement
- Spacebar: Jump
- `q` to choose rappelling mode, press `E` and use the mouse for rappelling mode
- `9` to choose God Mode

### 3.2 God Mode
The player can activate God mode, allowing them to pass through obstacles without harm. This ability has a cooldown to maintain balance.

### 3.3 Using the Rope
Players can use the rope to climb vertical surfaces. Timing and precision are essential for successful navigation.

## 4. Game Flow

### 4.1 Starting the Game
Players start in a designated starting area and must explore the game world to find the hidden treasure.

### 4.2 Finding Clues
Discover clues hidden throughout the level, leading to the combination required to open the chest.

### 4.3 Opening the Chest
Locate the lever and throw a stone at it to open the door to the chest. Input the correct combination discovered from the clues.

### 4.4 Winning and Losing Conditions
Win by successfully opening the chest with the correct code. Lose if the player's health drops to zero.

## 5. Characters

### 5.1 Player Character
A nimble explorer with the ability to run, jump, use a rope, and activate God mode temporarily.

### 5.2 Enemies
- Snakes: Move in patterns, requiring precise timing to avoid.
- Poisonous Turtles: Move slowly but release toxins upon contact.
- Arrow-Throwing Enemies: Engage in ranged combat.

## 6. Conclusion
"Treasure Quest" offers players an exciting and challenging adventure, combining platforming, puzzle-solving, and combat elements.
# Enemy Folder Unity Scripts

## Boulder.cs

### Variables
- **speed (float):** Public variable determining the boulder's speed. Marked with `[HideInInspector]` attribute.
- **myBody (private Rigidbody2D):** Private variable holding the Rigidbody2D component.

### Methods
- **Awake():** Gets the Rigidbody2D component during script loading.
- **Start():** Empty method called before the first frame update.
- **FixedUpdate():** Sets horizontal velocity based on the speed variable.

## snakespawner.cs

### Variables
- **snakereferences (array of GameObjects):** Represents different snake prefabs.
- **spawnedsnake (GameObject):** Reference to the currently spawned snake.
- **leftPos, rightPos (Transform):** Transform references for left and right spawn positions.
- **randomIndex (int):** Index for randomly selecting a snake.
- **randomSide (int):** Randomly determines left (0) or right (1) spawn.

### Methods
- **Start():** Initiates the `Spawnsnakes()` coroutine.
- **Spawnsnakes():**
  - Coroutine for continuous snake spawning with a 2-second delay.
  - Randomly selects a snake, sets spawn side, and instantiates.
  - Adjusts position, speed, and flips the snake if spawned on the right.

## spear.cs

### Introduction
A Unity script for controlling the movement of a spear in a 2D game using `Rigidbody2D`.

### Features
- Basic spear movement functionality.
- Adjustable speed through the Unity Inspector.

### How to Use
1. Attach the `spear` script to the GameObject representing your spear.
2. Adjust the `speed` parameter in the Unity Inspector for movement speed.

### Getting Started
1. Clone or download the repository to your local machine.
2. Open the Unity project containing your game.
3. Drag and drop the `spear` script onto the GameObject representing your spear.
4. Adjust the `speed` parameter in the Unity Inspector.
5. Run your Unity game to see the spear in action.

## Collisiondetect.cs

### Features
- Directional movement based on speed.
- Collision handling for specified objects.
- Trigger reflection on colliding with a "Wall."

### Usage
1. Attach `CollisionDetection.cs` to the GameObject.
2. Ensure a `Rigidbody2D` component is attached.
3. Adjust parameters in the Unity Editor.

### Script Components
- **CollisionDetection.cs:** Main script file for collision detection and movement.
- **Dependencies:** Requires the Unity Engine.

## manthrowing.cs

### Features
- Randomly selects and spawns snakes from left or right.
- Dynamically adjusts snake speed based on the side.
- Flips the snake when spawned on the right for realism.

### Usage
1. Attach to a GameObject in your Unity scene.
2. Assign snake prefabs to the `snakereferences` array.
3. Set left and right spawn positions using `leftPos` and `rightPos`.
4. Adjust spawn interval in the `StartCoroutine` method.

## snake.cs

### Introduction
A basic implementation of the classic Snake game using Unity.

### Features
- Responsive snake movement.
- Adjustable speed for increased difficulty.
- Rigidbody2D physics for smooth motion.
### Code Explanation
- Controls movement using Rigidbody2D.
- Adjustable speed through the `speed` variable.
- Initialization in `Awake`, movement in `FixedUpdate`.

