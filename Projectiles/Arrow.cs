using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	[HideInInspector]
	public Transform target; // The tower tells the arrow which target
	[HideInInspector]
	public int damage;
	[SerializeField] float arrowSpeed;

	void Update () {
		// move towards target
		//  = target.position - transform.position;
		transform.LookAt(target.position);
		transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Hit " + other.name);
		IHittable badGuy = other.GetComponent<IHittable>();
		if (badGuy != null)
			{
				Debug.Log("Arrow.cs found a hittable thingy");
				badGuy.TakeDamage(damage);
				Destroy(gameObject);
			}
		other.GetComponent<IHittable>().TakeDamage(damage);	
	}
}
