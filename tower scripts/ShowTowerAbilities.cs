using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowTowerAbilities : MonoBehaviour {
	[SerializeField] GameObject towerUICanvas;
	GameObject towerUI;
	TowerPlacingScript towerPlacer;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		CloseTowerUI();
		towerPlacer = FindObjectOfType<TowerPlacingScript>();
		towerUI = GameObject.FindWithTag("TowerUI");
	}
	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		towerPlacer = FindObjectOfType<TowerPlacingScript>();
		towerUI = GameObject.FindWithTag("TowerUI");
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()			
	{
//		Debug.Log(name);
		if (towerPlacer.selectetTowerUI != null)
			towerPlacer.CloseTowerUI();
		towerUICanvas.SetActive(true);
		towerPlacer.selectetTowerUI = towerUICanvas;
		towerPlacer.ShowTowerStats(gameObject);
		// GameObject.FindWithTag("TowerUI").SetActive(false);
	}
	void OnMouseOver() { towerPlacer.towerUIAbleToBeSummoned = false; }
	void OnMouseExit() { towerPlacer.towerUIAbleToBeSummoned = true; }
	public void CloseTowerUI()	{towerUICanvas.SetActive(false);}
}
