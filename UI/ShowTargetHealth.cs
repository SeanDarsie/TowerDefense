using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowTargetHealth : MonoBehaviour {
	[SerializeField] Slider health;
	[SerializeField] GameObject healthUICanvas;
	[SerializeField] Creep creep;
	[SerializeField] CreepNav creepNav;
	
	void Start()
	{
		creep = GetComponent<Creep>();
		creepNav = GetComponent<CreepNav>();
	}
	void Update () {
		if (creep != null) {
			health.minValue = 0f;
			health.maxValue = (float)creep.GetMaxHealth();
			health.value = (float)creep.GetHealth();
		}
		if (creepNav != null) {
			health.minValue = 0f;
			health.maxValue = (float)creepNav.GetMaxHealth();
			health.value = (float)creepNav.GetHealth();
		}
	}
	// void OnMouseDown()			
	// {
	// 	if (!healthUICanvas.activeInHierarchy)
	// 		healthUICanvas.SetActive(true);
	// 	else
	// 		healthUICanvas.SetActive(false);		
	// }
	public void turnOnHPBar()
	{
		healthUICanvas.SetActive(true);
	}
	public void turnOffHPBar()
	{
		healthUICanvas.SetActive(false);
	}
}
