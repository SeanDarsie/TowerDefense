using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerManager : MonoBehaviour {
	
	Dictionary<int,GameObject> activeTowers = new Dictionary<int,GameObject>();
	[SerializeField] Transform[] buttonPositions;
	[SerializeField] GameObject[] allTowers;
	[SerializeField] TowerSlot[] allSlots;
	// [SerializeField] ;
	// [SerializeField] ;
	// [SerializeField] ;
	// [SerializeField] ;
	// [SerializeField] ;
	// [SerializeField] ;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DestroyAllTowers()
	{
		Tower[] allTowers = FindObjectsOfType<Tower>();
		foreach (Tower x in allTowers)
			Destroy(x.gameObject);
	}

	public void AssignTower(int towerBtnPosIndex, GameObject towerToAssign)
	{
		// towerToAssign.transform.position = buttonPositions[towerBtnPosIndex].position;
		if (activeTowers.ContainsKey(towerBtnPosIndex))
		{
			if (activeTowers[towerBtnPosIndex] == null)
				activeTowers[towerBtnPosIndex] = towerToAssign;
		}
		else
			activeTowers.Add(towerBtnPosIndex,towerToAssign);
		// Debug.Log("tower Position Index: " + towerBtnPosIndex);
		// Debug.Log("Tower that shoudl be there: " + towerToAssign.name);
		 // we have na index a tower and a list of transforms. all we need to do is assign a gameobject to 
	}
	public void RemoveTower(int towerBtnPosIndex, GameObject towerToUnassign)
	{
		activeTowers.Remove(towerBtnPosIndex);
		activeTowers[towerBtnPosIndex] = null;
	}
	public void InitializeTowerUI()
	{
		foreach(GameObject x in allTowers)
		{
			x.SetActive(false);
		}
		for (int i = 0; i< 6; i++)
		{
			if (activeTowers.ContainsKey(i))
			{
				activeTowers[i].transform.position = buttonPositions[i].position;
				activeTowers[i].SetActive(true);
			}
		}
		// activate the chosen towers. Place them in the positions that correspond to the indices that have been saved.

	}
	public void RemakeDictionary() // Clear the dictionary and remake it
	{
		activeTowers.Clear();
		// for (int i = 0; i < 6; i++)
		// {
		// 	if (activeTowers.ContainsKey(i))
		// 	{
		// 		Debug.Log(activeTowers[i].name);
		// 	}
		// }
		foreach(TowerSlot x in allSlots)
		{
			if (x.chosen == true)
			{
				x.AssignTower(x.myTower);
			}
		}
		for (int i = 0; i < 6; i++)
		{
			if (activeTowers.ContainsKey(i))
			{
				Debug.Log(activeTowers[i].name);
			}
		}
	}
}
