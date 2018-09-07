using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacingScript : MonoBehaviour {
	public GameObject towerModel; // for showing where the tower will be placed
	public GameObject towerPrefab;
	public bool towerSelected;
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
		// if (Input.GetMouseButtonDown(0))
		// 	{	RaycastHit hit;
		// 		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
		// 		{
		// 			// Tower tower = hit.collider.GetComponent<Tower>();
		// 			// if (tower == null)
		// 			// 	CloseTowerUI();
		// 		}
		// 		// else
		// 		// 	CloseTowerUI();
		// 	}
	}
	public void ShowTowerStats(GameObject tower)
	{
		upgradeTowerButton.interactable = true;
		sellTowerButton.interactable = true;
		Tower currentTower = tower.GetComponent<Tower>();
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
		ShowTowerStats(towerToUpgrade);
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
	// need a function to sell selected tower or upgrade selected tower
}
