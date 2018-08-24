using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostTower : Tower {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Fire()
	{
		Debug.Log("Unimplemented Fire funciton FrostTower");
	}
	void FlashFreeze()
	{
		// freeze some enemies. doesn't hit air units Air units will have their own path.
	}
}
