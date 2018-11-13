using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UItower : MonoBehaviour, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler{
	
	// Colors
	[SerializeField] Color normalColor;
	[SerializeField] Color hoveredColor;
	[SerializeField] Color disabledColor;
	// Colors
	[SerializeField] Image towerBackground;
	[SerializeField] GameObject towerUI;
	[SerializeField] GameObject towerPrefab; // the tower prefab that this button allows the user to select. 
	[SerializeField] GameObject towerModel; // the model with no scripts on it that will show the player where they are placing they tower
	// [SerializeField] UImanager manager;
	TowerPlacingScript placeTower;
	PlayerStats player;
	bool towerHovered = false;
	bool playerCanAffordTower = true;
	void Start () { 
		player = FindObjectOfType<PlayerStats>();
		placeTower = FindObjectOfType<TowerPlacingScript>();
		// manager = FindObjectOfType<UImanager>();
	}
	/// <summary>
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		towerHovered = false;
	}
	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		player = FindObjectOfType<PlayerStats>();
		placeTower = FindObjectOfType<TowerPlacingScript>();	
		if (player.monies >= towerPrefab.GetComponent<Tower>().GetPrice())
		{
			playerCanAffordTower = true;
			towerBackground.color = normalColor;
		}
		else
		{
			playerCanAffordTower = false;
			towerBackground.color = disabledColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (towerHovered == true)
		{
			if (player.monies >= towerPrefab.GetComponent<Tower>().GetPrice())
				towerBackground.color = hoveredColor;
			else
				towerBackground.color = disabledColor;
		}
		else
		{
			if (player.monies >= towerPrefab.GetComponent<Tower>().GetPrice())
				towerBackground.color = normalColor;
			else
				towerBackground.color = disabledColor;
		}
		if (Input.GetMouseButtonUp(0) && towerHovered == true)
		{
			
			selectTower();
		}
	
		
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


	// Interface Functions //
	public void OnPointerUp(PointerEventData eventData)
	{
		if (!playerCanAffordTower)
			return;
		selectTower();
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!playerCanAffordTower)
			return;
		towerBackground.color = hoveredColor;
		towerHovered = true;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		if (!playerCanAffordTower)
			return;

		towerBackground.color = normalColor;
		towerHovered = false;
	}
	// Interface Functions
}
