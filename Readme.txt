Name:
Skee-Ball game

Installation:
APK file is in the project first level of folder(Animoca brands Unity Game Assignment)

Structure:
	MenuScene
		Rank Manager: for Save and Load of the game data
		Scene Manager: for Scene control and transfer
		Canvas: For displaying the UI components
	GamePlayScene
		GameManager: Controller of the game system, including:
				1.Time duration
				2.Detection Area
				3.Score Recording
				4.References of the game system like player, canvas
		Scene Manager: for Scene control and transfer
		Enviornment: The Gameobjects of composing the game environment
		UI: Interface display
	LeaderBoard
		Rank Canvas: display interface of the rank
		Scene Manager: for Scene control and transfer
Features:
Storing data in the presisting file path with own written IO system
Size Scaling based on resolution
power bar move a different speed if it is closer to the end of the bar
Game setting control in the game manager
Amount of points given for each hole.