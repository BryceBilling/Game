using UnityEngine;
using System.Collections;

public class LevelSelection : MonoBehaviour 
{
	public Texture2D wallpaper;
	
	public float buttonWidth;
	public float buttonHeight;
	public float buttonGap;
	
	public GUISkin skin;
	
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
		if(GUI.Button (new Rect(Screen.width * offset+buttonGap, Screen.height * 0.4f, buttonWidth, buttonHeight), "Main Menu"))
		{
			Application.LoadLevel("Home Screen");
		}
		
		if(GUI.Button (new Rect(Screen.width * offset + buttonGap, Screen.height * 0.4f + (buttonGap + buttonHeight), buttonWidth, buttonHeight), "Level 1"))
		{
			Application.LoadLevel("Level1");
		}
		
		if(GUI.Button (new Rect(Screen.width * offset + buttonGap, Screen.height * 0.4f + 2 * (buttonGap + buttonHeight), buttonWidth, buttonHeight), "Level 2"))
		{
			Application.LoadLevel("Level2");
		}
		
		if(GUI.Button (new Rect(Screen.width * offset + buttonGap , Screen.height * 0.4f + 3 * (buttonGap + buttonHeight), buttonWidth, buttonHeight), "Exit"))
		{
			Application.Quit();
		}
	}
}
