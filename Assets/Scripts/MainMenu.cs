using UnityEngine;
using System.Collections;
//Create objects and assign GUI components to them instead of hard coding
public class MainMenu : MonoBehaviour 
{
	public Texture2D wallpaper;
	
	public float buttonWidth;
	public float buttonHeight;
	public float buttonGap;
	
	public GUISkin skin;
	public bool twoPlayer;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		float offset = 0.25f;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), wallpaper);
		
		GUI.skin = skin;
		if(GUI.Button (new Rect(Screen.width * offset+buttonGap, Screen.height * 0.4f, buttonWidth, buttonHeight), "1 Player"))
		{
			twoPlayer=false;
			Application.LoadLevel("LevelSelection");
		}
		
		if(GUI.Button (new Rect(Screen.width * offset + buttonGap, Screen.height * 0.4f + (buttonGap + buttonHeight), buttonWidth, buttonHeight), "2 Player"))
		{
			twoPlayer=true;
			Application.LoadLevel("LevelSelection");
		}

		
		if(GUI.Button (new Rect(Screen.width * offset + buttonGap , Screen.height * 0.4f+2* (buttonGap + buttonHeight), buttonWidth, buttonHeight), "Exit"))
		{
			Application.Quit();
		}
	}
}
