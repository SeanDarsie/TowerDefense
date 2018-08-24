using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEditor;

public class CustomGizmos : MonoBehaviour {
	public Color color1;
	public Color color2;
	 void OnDrawGizmos() {
        Gizmos.color =  color1;
		
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
		 if (target != null) {
            Gizmos.color = color2;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
