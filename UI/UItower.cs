using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItower : MonoBehaviour {
	// the tower available at this ui element
	public GameObject tower;
	public UImanager manager;

	// / <summary>
	// / OnMouseDown is called when the user has pressed the mouse button while
	// / over the GUIElement or Collider.
	// / </summary>
	void OnMouseDown()
	{
		manager.selectedTower = tower;
	}
	// / <summary>
	// / Called when the mouse enters the GUIElement or Collider.
	// / </summary>
	void OnMouseEnter()
	{
		// make some kind of indication that the player is selecting this element. 
	}
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
