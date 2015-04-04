using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public int level=0;
	public bool twoPlayers;
	public bool pause=false;
	public GameObject helpImage;

	public void Start(){
		helpImage=GameObject.Find("Help");//Finds the help screen
	}

	public void MainMenu(){//Loads main menu
		Application.LoadLevel ("Home Screen");
	}

	public void FixedUpdate(){//Loads Help Screen
		if (helpImage != null) {
			Debug.Log(pause);
			if (Input.GetKey (KeyCode.H)) {
				pause = true;
				helpImage.SetActive (true);
			
			} else if (Input.GetKey (KeyCode.Escape)) {
				helpImage.SetActive (false);
				pause = false;
			
			} else if (!pause) {
				helpImage.SetActive (false);
				pause = false;
			
			}
		}
	}

	public void Exit(){
		Application.Quit ();
	}

	public void Level1(bool twoPlayer){//Loads Level 1
		level = 1;
		if (twoPlayer) {
			twoPlayers=true;
			Application.LoadLevel ("TwoLevel"+level);
		} else {
			Application.LoadLevel("Level"+level);
		}
		LevelTracker LevelScript=(GameObject.Find ("LevelSelector").GetComponent("LevelTracker")) as LevelTracker;
		LevelScript.level = level;
		LevelScript.twoPlayers=twoPlayer;

	}

	public void Level2(bool twoPlayer){//Loads Level 2
		level = 2;
		if (twoPlayer) {
			Application.LoadLevel ("TwoLevel"+level);
		} else {
			Application.LoadLevel("Level"+level);
		}
		LevelTracker LevelScript=(GameObject.Find ("LevelSelector").GetComponent("LevelTracker")) as LevelTracker;
		LevelScript.level = level;
		LevelScript.twoPlayers=twoPlayer;
	}
	

	public void OnePlayer(){//Loads one player level selection
		twoPlayers = false;
		Application.LoadLevel ("LevelSelection");
	}

	public void TwoPlayer(){//Loads two player level selection
		twoPlayers = true;
		Application.LoadLevel ("TwoPlayerLevelSelection");
	}

	public void Next(){//Loads the next level
		LevelTracker LevelScript=(GameObject.Find ("LevelSelector").GetComponent("LevelTracker")) as LevelTracker;

		LevelScript.level++;
		if (LevelScript.twoPlayers) {
			Application.LoadLevel ("TwoLevel"+LevelScript.level);
		} else {
			Application.LoadLevel("Level"+LevelScript.level);
		}
	}
	
}
