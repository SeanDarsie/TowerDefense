using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	// Use this for initialization
	[HideInInspector] public bool grabbed;
	public delegate void UIItemDropped();
	public event UIItemDropped itemDropped;

	public delegate void UIItemGrabbed();
	public event UIItemGrabbed itemGrabbed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (grabbed == true)
		{
			// follow mouse
			// GetComponent<RectTransform>().position = Input.mousePosition;
			transform.position = Vector3.zero;// Input.mousePosition;
			// Debug.Log("folllow the mouse");
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		grabbed = true;
		if (itemGrabbed != null) {itemGrabbed();}
		// Debug.Log("pointer Down");
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		grabbed = false;
		if (itemDropped != null) {itemDropped();}
	}
	// public void Onpointer

}
