using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
	public static DontDestroy instance;
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else
			{
				Destroy(gameObject);
				return;
			}
		DontDestroyOnLoad(gameObject);	
	}
}
