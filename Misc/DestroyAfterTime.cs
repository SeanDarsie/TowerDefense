using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {
	[SerializeField] float timeTillDestroy;
	// Use this for initialization
	void Start () {
		Destroy(gameObject,timeTillDestroy);
	}
}
