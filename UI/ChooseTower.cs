using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTower : DraggableUI {
	Vector3 startingPosition;
	TowerSlot mySlot;
	[SerializeField] Transform[] slots;
	public bool assignedToSlot = false;
	[Tooltip("In ascending order based on gold price")]
	[SerializeField] int towerIndex;
	[SerializeField] float minDistance;
	[SerializeField] string myTower;
	[SerializeField] GameObject UITowerButton; // this could work i suppose. so we give the archer button in this ui the archer button in game, then it get

	void Start () {
		startingPosition = transform.position;

	}
	void OnEnable()
	{
		itemDropped += DroppedItem;
		itemGrabbed += GrabbedItem;
	}
	void OnDisable()
	{
		itemDropped -= DroppedItem;
		itemGrabbed -= GrabbedItem;
	}
	
	// Update is called once per frame
	void Update () {
		if (grabbed == true)
		{
			// follow mouse
			// GetComponent<RectTransform>().position = Input.mousePosition;
			transform.position = Input.mousePosition;
			// Debug.Log("folllow the mouse");
		}
	}
	void ResetPosition()
	{
		transform.position = startingPosition;
		assignedToSlot = false;
	}
	void DroppedItem()
	{
		// Check position against all 
		Vector3 endPosition =  new Vector3();
		float dist = 100000;
		bool slotPicked = false;
		Transform pickedSlot = null;
		foreach (Transform x in slots)
		{
			if (Vector3.Distance(transform.position, x.position) < dist			&&
				Vector3.Distance(transform.position, x.position) <= minDistance	&&
				x.GetComponent<TowerSlot>().chosen == false)
			{
				endPosition = x.position;
				pickedSlot = x;
				slotPicked = true;
			}
		}
		if (slotPicked == true) // found a place to put it
		{
			pickedSlot.GetComponent<TowerSlot>().AssignTower(towerIndex);
			mySlot = pickedSlot.GetComponent<TowerSlot>();
			transform.position = endPosition;
			assignedToSlot = true;
		}
		else // did not find a viable place to put the tower.
		{
			ResetPosition();
		}

	}
	void GrabbedItem()
	{
		if (assignedToSlot == true)
		{
			mySlot.UnassignTower(towerIndex);
			mySlot = null;
			assignedToSlot = false;
		}
	}
}
