using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TowerBlockScript : MonoBehaviour {
	abstract public void showTower(GameObject tower);
	abstract public void placeTower(GameObject tower);
	// ui script will take care of showing the towers available. Allowing you to select a tower
	// so that you can take that tower to the field and put the selected gameobject into the 
	// showtower and placetower functions.
	// Use this for initialization
}
