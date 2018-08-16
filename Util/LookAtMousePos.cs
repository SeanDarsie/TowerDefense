using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMousePos : MonoBehaviour {
	// public GameObject whatToLookAt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	RaycastHit hit;
	void Update () {
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100000))
		{
			transform.LookAt(hit.point);
		}

	}
}
