﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacingScript : MonoBehaviour {
	[SerializeField] GameObject towerUI;
	public bool towerUIAbleToBeSummoned = true;
	public GameObject towerModel; // for showing where the tower will be placed
	public GameObject towerPrefab;
	public bool towerSelected; // if the player has successfully chosen a tower to place.
	public int selectedTowerPrice = 0;
	public GameObject selectetTowerUI;
	[SerializeField] Text towerName;
	[SerializeField] Text towerDPS;
	[SerializeField] Text towerUpgrade;
	[SerializeField] Text towerSell;
	[SerializeField] Text towerLevel;
	[SerializeField] Button upgradeTowerButton;
	[SerializeField] Button sellTowerButton;
	private GameObject towerToUpgrade;
	public void CloseTowerUI()
	{
		if (selectetTowerUI != null)
			selectetTowerUI.SetActive(false);
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (Input.GetMouseButtonUp(0))
			Invoke("DeactivateTowerSelectUI", 0.1f);
		if (Input.GetMouseButtonDown(0) && towerSelected == false && towerUIAbleToBeSummoned == true)
			{
				towerUI.transform.position = Input.mousePosition;
				towerUI.SetActive(true);
			}
		if (Input.GetMouseButtonDown(1) && towerSelected == true)
		{
			towerModel.SetActive(false);
			towerSelected = false;
		}
		if (towerSelected == true && towerPrefab.GetComponent<Tower>().GetPrice() > FindObjectOfType<PlayerStats>().monies)
		{
			towerModel.SetActive(false);
			towerSelected = false;
		}
		if (towerToUpgrade != null)
		{
			if (FindObjectOfType<PlayerStats>().monies >= towerToUpgrade.GetComponent<Tower>().GetUpgradePrice())
				upgradeTowerButton.interactable = true;
		}
	}
	public void ShowTowerStats(GameObject tower)
	{
		if (towerToUpgrade == tower)
		{
			CloseTowerUI();
			towerToUpgrade = null;
			return;
		}
		if (towerModel != null)
			towerModel.SetActive(false);
		if (towerUI.activeInHierarchy)
			towerUI.SetActive(false);
		towerSelected = false;
		sellTowerButton.interactable = true;
		Tower currentTower = tower.GetComponent<Tower>();
		if (FindObjectOfType<PlayerStats>().monies >= currentTower.GetUpgradePrice())
			upgradeTowerButton.interactable = true;
		else
			upgradeTowerButton.interactable = false;
		towerName.text = "Level " + currentTower.GetLevel().ToString() + " " + currentTower.GetName();
		towerDPS.text = "DPS " + currentTower.GetDPS().ToString("0.00");
		towerUpgrade.text = "Upgrade: " + currentTower.GetUpgradePrice().ToString();
		towerSell.text = "Sell: "+ currentTower.GetSellPrice().ToString();
		towerLevel.text = "Level: " + currentTower.GetLevel().ToString();
		towerToUpgrade = tower;
		// we need a bunch og ui elements to manipulate
	}
	public void UpgradeSelectedTower()
	{
		// we need to call the curent towers upgrade function, then maybe call show tower stats after that
		towerToUpgrade.GetComponent<Tower>().UpgradeTower();
		UpdateTowerStats(towerToUpgrade);
	}
	public void SellSelectedTower()
	{
		towerToUpgrade.GetComponent<Tower>().SellTower();
		towerToUpgrade = null;
		ResetTowerUI();
	}

	void ResetTowerUI()
	{
		sellTowerButton.interactable = false;
		upgradeTowerButton.interactable = false;
	}
	void UpdateTowerStats(GameObject tower)
	{
		if (FindObjectOfType<PlayerStats>().monies >= tower.GetComponent<Tower>().GetUpgradePrice())
			upgradeTowerButton.interactable = true;
		else
			upgradeTowerButton.interactable = false;
		sellTowerButton.interactable = true;
		Tower currentTower = tower.GetComponent<Tower>();
		towerName.text = "Level " + currentTower.GetLevel().ToString() + " " + currentTower.GetName();
		towerDPS.text = "DPS " + currentTower.GetDPS().ToString("0.00");
		towerUpgrade.text = "Upgrade: " + currentTower.GetUpgradePrice().ToString();
		towerSell.text = "Sell: "+ currentTower.GetSellPrice().ToString();
		towerLevel.text = "Level: " + currentTower.GetLevel().ToString();
		towerToUpgrade = tower;
	}
	void DeactivateTowerSelectUI()
	{
		towerUI.SetActive(false);
	}
	// need a function to sell selected tower or upgrade selected tower
}
