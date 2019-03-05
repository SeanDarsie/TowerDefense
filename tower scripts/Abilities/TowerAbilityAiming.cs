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
		// Quaternion test = new Quaternion();
		Vector3 mousePosition = new Vector3(Input.mousePosition.x - (Screen.width/2), 0,Input.mousePosition.y - (Screen.height/2));
		Quaternion rotation = Quaternion.LookRotation(transform.position + mousePosition.normalized - transform.position);
		transform.rotation = rotation;


		// Vector3 mousePositionInFram = new Vector3(0,Input.mousePosition.x,0);
		// transform.Rotate(-(oldMousePosition - mousePositionInFram) * rotationSpeed);
		// oldMousePosition = new Vector3(0,Input.mousePosition.x, 0);
		// transform.rotation = new Quaternion(0, Input.mousePosition.x,0,0);
	}
}
