# Vortex---3D-Platformer
A 3D platformer developed in Unity

How to Play:

    The player can start a new game through the start menu UI. The player can control the character via WASD or the arrow keys. The player should move around to pick up various power-ups that will allow the player to interact with the world in different ways (power up will change the character color and the UI will tell the player which power up they currently have). UV slime collectables can also be picked up by the player to increase the time left on the timer. The player can also click the left mouse button to fire a projectile that will destory enemies. The goal of the game is to traverse through the level in order to find a way to get to the mothership plane (the end of the level) without dying to enemies or letting the timer run out.

For technology requirements, I could not find a comprehensive list anywhere on Canvas, so I used the Video Game Design Rubric as a basis. Parts I felt were a "technology requirement" are listed below.

Technology Requirements:

    3D Game Feel:

        -Player success is communicated clearly with text when the player reaches the end goal (mothership plane) to end the level

        -Player failure is communicated clearly with text and time freeze when the player touches an enemy and loses the game

        -Start menu UI is present and functional

        -Player is able to reset game from the menu at any time (including after game win/lose)

    Fun Gameplay:

        -interesting choices are available to the player who can move around the level to decide how to best

        solve the puzzle to reach the end

        -choice consequences are present as the player cannot progress if they miss/ignore the correct power up

        -player choice engages the player with the game world as power ups affect how the player can interact with evironment

        -AI controlled enemies will get start chasing the player if he/she gets too close. Otherwise, they patrol back and forth

        -game balances level difficulty with level timer

        -game has learning/training opportunity with the tutorial level

    3D Character:

        -character control is functional and is a predominant part of gameplay (must move to traverse to end of level)

        -character 

        -character is not a unity tutorial/CS4455 milestone/complete prepackged asset character

        -character has engaging floating and spinning animaation during movement

        -no group member has a gaming controller, so we could not test continuous, dynamic, varaible/analog-style control for movement with a gaming controller. Character moves in these ways (as much as possible) with keyboard inputs such as acceleration the longer the key is held for movement.

        -animation is fluid for character and enemies

        -camera movement is smooth

        -auditory feedback is present for most interactables in the game (jump, collecting power up, etc.)

    3D world:

        -environment fully synthesized by hand (not from Unity asset store)

        -graphics correclty aligned with physics representation

        -boundaries are present to prevent the player from moving out of playable zone

        -environmental physical interactions are present inlcuding phasable walls (with power up), blocks of water that can be walked up (with power up), and a projectile that moves with projectile-motion that can destroy enemies if hit

        -player has six degrees of freedom movement with the jump power up

        -consistent spatial simulation present throughout gameplay

    AI:

        -only model and texture were used from prepackaged asset for enemy that uses AI

        -multiple states of AI exist for enemy (patrol and chase; patrol has the enemy moving back and forth to patrol and chase has the enemy chase after the player character)

        -AI enemy movement is smooth

        -AI difficult is appropriate (speed and chase state radius)

        -AI interacts with environment (to the players advantage however) such as being able to hide from enemies behind walls

    Polish:

        -start menu GUI and in-game pause menu (appropriately styled) with ability to quit game are present

        -player can exit the game at any time via pause menu

        -art style is cohesive