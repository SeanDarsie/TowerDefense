﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class will be in charge of making sure all the ui elements are up to date and assign the right ui to the right place???? wtf amisaying
public class UImanager : MonoBehaviour {
	[SerializeField] GameObject startMenu;
	[SerializeField] GameObject optionsMenu;
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
			case "Main":
				startMenu.SetActive(true);
				optionsMenu.SetActive(false);
				break;
			case "Options":
				startMenu.SetActive(false);
				optionsMenu.SetActive(true);
				break;
			case "None": // set's all UI gameobjects inactive. Not sure if needed.
				startMenu.SetActive(false);
				optionsMenu.SetActive(false);
				break;
			case "":
				Debug.LogError("Impressive! you managed to call SwitchMenus(string nameOfMenuToActivate) with an empty string");
				break;
			default:
				Debug.LogWarning("No menu named " + nameOfMenuToActivate + " exists. Activating main menu");
				startMenu.SetActive(true);
				optionsMenu.SetActive(false);
				break;
			
		}
	}

}
