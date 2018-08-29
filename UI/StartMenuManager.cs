using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuManager : MonoBehaviour {
	[SerializeField] GameObject startMenuUI;
	PlayerStats playerStats;
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 0f;
		playerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 public void StartGame()
	 {
		 switch(FindObjectOfType<LevelChooser>().chosenLevel)
		 {
			 case 0:
			 	// start the first level. For now we're just going to set Time.timeScale to 1 and turn off the start menu.
				 // in future we will have a more complex level system.
				Time.timeScale = 1.0f;
				startMenuUI.SetActive(false);
				playerStats.ResetLevelHealthAndMonies();
				
				break;
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
				break;
			case 7:
				break;
			default:
				break;
		 }
	 }
}
