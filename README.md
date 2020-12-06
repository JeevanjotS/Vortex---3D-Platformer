# Vortex---3D-Platformer
A 3D puzzle platformer developed in Unity by:
DJ Yu - dyu63@gatech.edu - dyu63
Kacey Chung - kchung46@gatech.edu - kchung46
Jeevanjot Singh - jsingh306@gatech.edu - jsingh306
Kevin George - kgeorge37@gatech.edu - kgeorge37


No installation requirements/procedures.


How to Play:

    The player can start a new game through the start menu UI. The player can control the character via WASD or the arrow keys. The player should move around to pick up various power-ups that will allow the player to interact with the world in different ways (power up will change the character color and the UI will tell the player which power up they currently have). UV slime collectables can also be picked up by the player to increase the time left on the timer. The player can also click the left mouse button to fire a projectile that will destory enemies. The goal of the game is to traverse through the level in order to find a way to get to the mothership plane (the end of the level) without dying to enemies or letting the timer run out.


No known deficiencies or bugs.


External resources used:
    -Player Character Asset: Downloaded character asset but made all the controls, animation except ear flopping and made the blend tree as well. 

    -Asteroids: Downloaded the colorful asteroids used in the game for aesthetics from the unity asset store.

    -Meteors: The asset is from the asteroid pack from the asset store, but the particle system, spawn logic and velocity were created by Kevin George. 

    -Enemy Asset: The asset and animation are from the RPG Monster Duo PBR Polyart by Dungeon Mason from the asset store, but the enemy AI logic was done by DJ Yu and Kacey Chung, and the enemy animation blending by DJ Yu, Kacey Chung, and Kevin George.

    -Planet/Supernovas: Vast Outer Space by Prodigious Creations was downloaded for free from the Unity Asset Store. These prefabs of planets and supernovas were placed around the level for aesthetic purposes.

    -PickUps Particle System: Downloaded the particle system used with the PickUps but changed the materials, various parameters. 


Open the following scenes:
    -Start Screen
    -Intro
    -Tutorial Level
    -Main Menu
    -Level 2
    -End Screen

Manifest:
    Kevin George -
        Contributions: 
            Player Character controls
            Player Character animations
            All sounds and music in the game
            Meteors 
            Floor rocks
            Level 2 Design 
            Level 2 implementation 
            Player Character particle system
            End Screen implementation 
            Freezing Power up
            Speed Power up
            Jumping Mechanic
            Power ups particle system 
            Tutorial Level Aesthetics 
            Level 2 Aesthetics
            Volume Sliders 
            UV Slime pick up
            Water / Ice 
            Countdown Timer  
            Heads Up Display - Timer and Power Up Text 
            Enemy Animation Blend Tree
            Death Plane and death logic
            Materials for floor, walls, character (only tint/color), water 
            Shader Graph for water
            Tutorial Level polish (Gap fixes for floors and walls)
            Sound editing with Audacity. 
            Enemy Collider bug fix
            Skybox
            Tutorial Level edge walls
            Camera rotation 

        Code Contributions: 
            AnimationAudio.cs
            CameraController.cs
            Countdown_timer.cs
            JustLoadSounds.cs
            KillPlayer.cs
            OldPlayerController.cs
            PlayerController.cs
            PlayerJump.cs
            PowerRotator.cs
            SoundManagerScript.cs
            Timer.cs
            TractorBeamCollider.cs
            ChangeSliderValues.cs
            CubeSound.cs
            DeathScript.cs
            DispalyScore.cs
            EnemyAnimationAudio.cs
            LoadFinalScreen.cs
            NextLevel.cs
            PlayRockSound.cs
            QuitEndScreen.cs
            TextureFix.cs


    Dongjoo Yu - 
        Contributions: 
            Floor rock placement for both levels
            Tutorial Level implementation (Fixed stair placement, fixed tiling, added pushable box, and added enemies)
            Tutorial Level aesthetics 
            Level 2 implementation (Fixed stair placement, tiling, pushable box sizes, and enemy placement)
            Level 2 aesthetics
            Heads Up Display - Score Text 
            Created basic shooting mechanic
            Enemy Animation Blend Tree logic
            Enemy AI
            Enemy animations
            Projectile creation and instantiation 
            Pushable boxes
            Developed backstory/theme

        Code Contributions:
            EnemyAI.cs
            GlobalVar.cs
            ProjectileScript.cs
            ScoreScript.cs
            VelocityReporter.cs
            DeathScript.cs
            NextLevel.cs
            PauseMenu.cs
            PlayerController.cs


    Jeevanjot Singh - 
        Contributions: 
            Solo implementation of the whole game for team project pitch
            Implemented prefabs for all the pickups
            Implemented animated prefab for mothership
            Created the whole playthrough tutorial
            Main menu design and implementation
            Start screen design and implementation
            Pause menu design and implementation
            Introduction and backstory page implementation
            Implemented jump powerup
            Implemented phase powerup
            Implemented freeze powerup
            Redesigned tutorial level aesthetically
            Redesigned Level 2 aesthetically
            Added timer blinking red when low on time
            Implemented basic player controls like movement(later redesigned) and jump

        Code Contributions:
            StartScreen.cs
            PauseMenu.cs
            MainMenu.cs
            NextLevel.cs
            DeathScript.cs
            TutorialManager.cs
            TractorBeamCollider.cs
            PowerRotator.cs
            PlayerJump.cs
            PlayerController.cs
            Countdown_timer.cs
            CallSpaceship.cs


    Kacey Chung - 
        Contributions: 
            Tutorial Level Design
            Tutorial Level Implementation
            Tutorial Aesthetics
            Level 2 Design 
            Level 2 Implementation (enemy, powerups, slime, boxes, asteroids)
            Level 2 Aesthetics
            End Screen Artwork
            Created basic shooting/projectile mechanic
            Finished and fixed shooting/projectile mechanic
            Enemy Animation Blend Tree logic
            Enemy AI
            Enemy animations
            Guiding Arrow
            Pushable boxes
            Asteroid Animations (later removed)
            Environment Materials
            Developed backstory/theme

        Code Contributions:
        EnemyAI.cs
        GlobalVar.cs
        ProjectileScript.cs
        VelocityReporter.cs
        PlayerController.cs
        ProjectileScript.cs
        arrowScript.cs


For technology requirements, I could not find a comprehensive list anywhere on Canvas, so I used the Video Game Design Rubric as a basis. Parts I felt were a "technology requirement" are listed below (From Alpha Demo).

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