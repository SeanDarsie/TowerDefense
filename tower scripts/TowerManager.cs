using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DestroyAllTowers()
	{
		Tower[] allTowers = FindObjectsOfType<Tower>();
		foreach (Tower x in allTowers)
		{
			Destroy(x.gameObject);
		}
	}
}
