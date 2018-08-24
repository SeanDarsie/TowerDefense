using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAbilityAiming : MonoBehaviour {
	float rotationSpeed = 0.5f;
	Vector3 oldMousePosition;
	// Use this for initialization
	void Start () {
		oldMousePosition = new Vector3(0, Input.mousePosition.x, 0);
	}
	
	// Update is called once per frame
	void Update () {
		// follow mouse input and rotate accordingly
		Vector3 mousePositionInFram = new Vector3(0,Input.mousePosition.x,0);
		transform.Rotate((oldMousePosition - mousePositionInFram) * rotationSpeed);
		oldMousePosition = new Vector3(0,Input.mousePosition.x, 0);
	}
}
