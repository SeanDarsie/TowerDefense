using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableTowerSelecting : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

	TowerPlacingScript towerPlacingScript;
	// Use this for initialization
	void Start () {
		towerPlacingScript = FindObjectOfType<TowerPlacingScript>();
	}
	
	public void OnPointerEnter(PointerEventData eventData)
	{
		towerPlacingScript.towerUIAbleToBeSummoned = false;
	}
	public void OnPointerExit(PointerEventData eventData)
	{
		Invoke("ResetTowerSelectingAbility", 1.0f);
	}
	void ResetTowerSelectingAbility()
	{
		FindObjectOfType<TowerPlacingScript>().towerUIAbleToBeSummoned = true;
	}
	// Update is called once per frame
}
