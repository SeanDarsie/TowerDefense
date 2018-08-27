using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTowerAbilities : MonoBehaviour {
	[SerializeField] GameObject towerUICanvas;
	TowerPlacingScript towerPlacer;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		CloseTowerUI();
		towerPlacer = FindObjectOfType<TowerPlacingScript>();
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
	}

	public void CloseTowerUI()	{towerUICanvas.SetActive(false);}
}
