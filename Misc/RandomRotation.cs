using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {
	Vector3 myRotation = new Vector3();
	// Use this for initialization
	void Start () {
		myRotation = new Vector3(Random.Range(0, 360),Random.Range(0, 360),Random.Range(0, 360));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(myRotation.normalized * 2);
	}
}
