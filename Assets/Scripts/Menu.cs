using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	int level;
	bool twoPlayers;
	public void MainMenu(){
		Application.LoadLevel ("Home Screen");
	}

	public void Exit(){
		Application.Quit ();
	}

	public void Level1(bool twoPlayer){
		level = 1;
		if (twoPlayer) {
			twoPlayers=true;
			Application.LoadLevel ("TwoLevel"+level);
		} else {
			Application.LoadLevel("Level"+level);
		}
	}

	public void Level2(bool twoPlayer){
		level = 2;
		if (twoPlayer) {
			twoPlayers=true;
			Application.LoadLevel ("TwoLevel"+level);
		} else {
			Application.LoadLevel("Level"+level);
		}
	}

	public void Level3(bool twoPlayer){
		level = 3;
		if (twoPlayer) {
			twoPlayers=true;
			Application.LoadLevel ("TwoLevel"+level);
		} else {
			Application.LoadLevel("Level"+level);
		}
	}

	public void OnePlayer(){
		Application.LoadLevel ("LevelSelection");
	}

	public void TwoPlayer(){
		Application.LoadLevel ("TwoPlayerLevelSelection");
	}

	public void Next(){
		if (level == 1 && twoPlayers) {
			level=2;
			Application.LoadLevel ("TwoLevel"+level);
		} else {
			level=2;
			Application.LoadLevel("Level"+level);
		}
	}
	
}
