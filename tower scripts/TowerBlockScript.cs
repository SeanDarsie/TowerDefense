using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBlockScript : MonoBehaviour {
	public bool occupied = false; // is there a tower on this block?
	public GameObject towerModel; // gets shown
	public GameObject towerPrefab; // actually gets placed
	GameObject TowerInstance;
	[SerializeField] Transform whereToPlaceTower;
	private TowerPlacingScript towerPlacer;
	private PlayerStats player;
	void Start()
	{
		towerPlacer = FindObjectOfType<TowerPlacingScript>();
		whereToPlaceTower = transform.GetChild(0);
		player = FindObjectOfType<PlayerStats>();
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (TowerInstance == null)
			occupied = false;
	}
	/// <summary>
	/// Called every frame while the mouse is over the GUIElement or Collider.
	/// </summary>
	void OnMouseOver()
	{
		if (occupied == true)
			return;
		
		showTower();
	}
	/// <summary>
	/// Called when the mouse is not any longer over the GUIElement or Collider.
	/// </summary>
	void OnMouseExit()
	{
		if (towerPlacer.towerSelected == true)
			stopShowingTower();
	}
	/// <summary>
	/// OnMouseUp is called when the user has released the mouse button.
	/// </summary>
	void OnMouseUp()
	{
		// towerPlacer.CloseTowerUI();
		if (!occupied)
		{
			placeTower();
		}
	}
	public void showTower()
	{
		if (!occupied && towerPlacer.towerSelected == true)
		{
			towerModel = towerPlacer.towerModel;
			towerPrefab = towerPlacer.towerPrefab;
			//tempTower = Instantiate(towerModel, whereToPlaceTower.position, whereToPlaceTower.rotation);
			towerModel.SetActive(true);
			towerModel.transform.position = whereToPlaceTower.position;
			towerModel.transform.rotation = whereToPlaceTower.rotation;
		}
	}
	public void stopShowingTower()
	{
		towerModel.SetActive(false);
	}
	public void placeTower()
	{
		if (towerPlacer.towerSelected == false)
			return;
		occupied = true;
		TowerInstance = Instantiate(towerPrefab, whereToPlaceTower.position, whereToPlaceTower.rotation);
		towerPlacer.towerSelected = false; //???? maybe we could let them place a bunch at once. 
		towerModel.SetActive(false);
		player.AdjustMonies(-towerPlacer.selectedTowerPrice);// monies -= towerPlacer.selectedTowerPrice;

	}
}
