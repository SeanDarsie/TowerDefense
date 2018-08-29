using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItower : MonoBehaviour {
	// the tower available at this ui element
	[SerializeField] GameObject towerPrefab; // the tower prefab that this button allows the user to select. 
	[SerializeField] GameObject towerModel; // the model with no scripts on it that will show the player where they are placing they tower
	// [SerializeField] UImanager manager;
	[SerializeField] TowerPlacingScript placeTower;
	[SerializeField] PlayerStats player;
	void Start () { 
		player = FindObjectOfType<PlayerStats>();
		placeTower = FindObjectOfType<TowerPlacingScript>();
		// manager = FindObjectOfType<UImanager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.monies >= towerPrefab.GetComponent<Tower>().GetPrice())
		{
			GetComponent<Button>().interactable = true;
		}
		else
			GetComponent<Button>().interactable = false;
	}
	public void selectTower()
	{
		if (player.monies >= towerPrefab.GetComponent<Tower>().GetPrice())
		{
			// successfully select tower
			placeTower.towerModel = towerModel;
			placeTower.towerPrefab = towerPrefab;
			placeTower.towerSelected = true;
			placeTower.selectedTowerPrice = towerPrefab.GetComponent<Tower>().GetPrice();
		}
		else
		{
			// cannot select tower
			// tell the player "not enough monies"
			// maybe flash the gold red for a second.
			placeTower.towerModel = null;
			placeTower.towerPrefab = null;
			placeTower.towerSelected = false;
			placeTower.selectedTowerPrice = 0;
		}
	}
}
