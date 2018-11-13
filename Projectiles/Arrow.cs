using System.Collections;
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
	public Tower.DamageType damageType;
	[HideInInspector]
	public int damage;
	[SerializeField] float arrowSpeed;
	float timeCount;
	void Update () {
		Vector3 lookDir = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(lookDir);
		

		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;

		transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime, Space.Self);
		// move towards target
		//  = target.position - transform.position;
		// transform.LookAt(target.position);
		// transform.Translate(Vector3.forward * Time.deltaTime * arrowSpeed);
		if (target.gameObject.activeInHierarchy == false)
			Destroy(gameObject);
	}
	void OnTriggerEnter(Collider other)
	{
		IHittable badGuy = other.GetComponent<IHittable>();
		if (badGuy != null && other.gameObject.name == target.gameObject.name)
		{
			badGuy.TakeDamage(damage, damageType);
			Destroy(gameObject);
		}
		// other.GetComponent<IHittable>().TakeDamage(damage);	
	}
}
