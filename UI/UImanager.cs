using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class will be in charge of making sure all the ui elements are up to date and assign the right ui to the right place???? wtf amisaying
public class UImanager : MonoBehaviour {
	[SerializeField] GameObject startMenu;
	[SerializeField] GameObject towersMenu;
	[SerializeField] GameObject levelSelect;
	[SerializeField] GameObject controlsMenu;
	// [SerializeField] GameObject credits;
	// [SerializeField] GameObject whatOtherMenuOptionsDoINeed;

	void Start () {

	}

	void Update () {
		
	}

	public void SwithMenus(string nameOfMenuToActivate)
	{
		switch(nameOfMenuToActivate)
		{
			case "LevelSelect":
				startMenu.SetActive(false);
				towersMenu.SetActive(false);
				levelSelect.SetActive(true);
				controlsMenu.SetActive(false);
				break;
			case "Main":
				levelSelect.SetActive(false);
				startMenu.SetActive(true);
				towersMenu.SetActive(false);
				controlsMenu.SetActive(false);
				break;
			case "Towers":
				levelSelect.SetActive(false);
				startMenu.SetActive(false);
				towersMenu.SetActive(true);
				controlsMenu.SetActive(false);
				break;
			case "None": // set's all UI gameobjects inactive. Not sure if needed.
				levelSelect.SetActive(false);
				startMenu.SetActive(false);
				towersMenu.SetActive(false);
				controlsMenu.SetActive(false);
				break;
			case "Controls":
				controlsMenu.SetActive(true);
				levelSelect.SetActive(false);
				startMenu.SetActive(false);
				towersMenu.SetActive(false);
				break;
			case "":
				Debug.LogError("Impressive! you managed to call SwitchMenus(string nameOfMenuToActivate) with an empty string");
				break;
			default:
				Debug.LogWarning("No menu named " + nameOfMenuToActivate + " exists. Activating main menu");
				startMenu.SetActive(true);
				towersMenu.SetActive(false);
				controlsMenu.SetActive(false);
				levelSelect.SetActive(false);
				break;
			
		}
	}

}
