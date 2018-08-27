using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowTargetHealth : MonoBehaviour {
	[SerializeField] Slider health;
	[SerializeField] GameObject healthUICanvas;
	[SerializeField] Creep creep;
	void Update () {
		health.minValue = 0f;
		health.maxValue = (float)creep.GetMaxHealth();
		health.value = (float)creep.GetHealth();
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
