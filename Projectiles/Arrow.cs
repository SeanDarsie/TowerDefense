﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Destroy(gameObject, 2.0f);
	}
	// Use this for initialization
	// [HideInInspector]
	public Transform target; // The tower tells the arrow which target
	[HideInInspector]
	public int damage;
	[SerializeField] float arrowSpeed;

	void Update () {
		// move towards target
		//  = target.position - transform.position;
		transform.LookAt(target.position);
		transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
		if (target.gameObject.activeInHierarchy == false)
			Destroy(gameObject);
	}
	void OnTriggerEnter(Collider other)
	{
		IHittable badGuy = other.GetComponent<IHittable>();
		if (badGuy != null && other.gameObject.name == target.gameObject.name)
			{
				badGuy.TakeDamage(damage);
				Destroy(gameObject);
			}
		// other.GetComponent<IHittable>().TakeDamage(damage);	
	}
}