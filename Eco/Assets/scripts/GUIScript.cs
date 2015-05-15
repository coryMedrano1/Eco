using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour
{

		public GUISkin myGUISkin;
		public Texture2D background;
		public Texture2D logo;
		private Rect windowRect = new Rect ((Screen.width / 2) - 100, Screen.height / 2, 200, 200);
		public string[] creditsLine = new string[0];
		private string menuState;
		private string main = "main";
		private string options = "options";
		private string credits = "credits";
		private string textToDisplay = "Credits \n";
		private float volume = 1.0f;

		// Use this for initialization
		void Start ()
		{

				menuState = main;
	
				for (int x = 0; x < creditsLine.Length; x++) {
						textToDisplay += creditsLine [x] + " \n";
				}

				textToDisplay += "Press esc to go back";
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (menuState == credits && Input.GetKey (KeyCode.Escape))
	
						menuState = main;

		}

		private void OnGUI ()
		{
				if (background != null) {
						GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);
				}
		
				if (logo != null) {
						GUI.DrawTexture (new Rect ((Screen.width / 2) - 100, 30, 200, 200), logo);
				}
		
				GUI.skin = myGUISkin;
		
				if (menuState == main) {
						windowRect = GUI.Window (0, windowRect, menuFunc, "Main Menu");
				}
		
				if (menuState == options) {
						windowRect = GUI.Window (1, windowRect, optionsFunc, "Options");
				}
		
				if (menuState == credits) {
						GUI.Box (new Rect (0, 0, Screen.width, Screen.height), textToDisplay);
				}
		
		}
	
		private void menuFunc (int id)
		{
				if (GUILayout.Button ("Play Game")) {
						Application.LoadLevel ("longForestLevel");
			
				}
		
				if (GUILayout.Button ("Options")) {
						menuState = options;
			
				}
		
				if (GUILayout.Button ("Credits")) {
						menuState = credits;
			
				}
		
				if (GUILayout.Button ("Quite Game")) {
						Application.Quit ();
			
				}

		}
		
		private void optionsFunc (int id)
		{
				if (GUILayout.Button ("Volume")) {
						volume = GUILayout.HorizontalSlider (volume, 0.0f, 1.0f);
						AudioListener.volume = volume;
				
				}

				if (GUILayout.Button ("Back")) {
						menuState = main;
				}

		}


}