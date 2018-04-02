using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

			void OnGUI() {
			if(GUI.Button(new Rect(20, 20, 100, 50), "Menu")) {
			SceneManager.LoadScene (0);			}
		}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
