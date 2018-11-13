using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSlot : MonoBehaviour {

	[SerializeField] int positionIndex;
	[SerializeField] GameObject[] towers;
	[HideInInspector] public bool chosen = false;
	[HideInInspector] public int myTower = -1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AssignTower(int tower)
	{
		FindObjectOfType<TowerManager>().AssignTower(positionIndex, towers[tower]);
		GetComponentInChildren<Text>().text = "";
		myTower = tower;
		chosen = true;
	}
	public void UnassignTower(int tower)
	{
		myTower = -1;
		chosen = false;
		FindObjectOfType<TowerManager>().RemoveTower(positionIndex,towers[tower]);
		FindObjectOfType<TowerManager>().RemakeDictionary();
		GetComponentInChildren<Text>().text = "Empty";

	}
}
