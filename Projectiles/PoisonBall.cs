using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBall : MonoBehaviour {

	[HideInInspector] public Transform target;
	[HideInInspector] public Tower.DamageType damageType;
	[HideInInspector] public int damage;
	[HideInInspector] public int poisonDamage;
	[HideInInspector] public int poisonTicks;
	[SerializeField]  float travelSpeed = 5.0f;
	void Start () {
		Destroy(gameObject,3.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.position);
		transform.Translate(Vector3.forward * Time.deltaTime * travelSpeed);
		if (target.gameObject.activeInHierarchy == false)
			Destroy(gameObject);
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		IHittable badGuy = other.GetComponent<IHittable>();
		if (badGuy != null && other.gameObject.name == target.gameObject.name)
		{
			badGuy.TakeDamage(damage, damageType);
		}
		IPoisonable creep = other.GetComponent<IPoisonable>();
		if (creep != null && other.gameObject.name == target.gameObject.name)
		{
			creep.BePoisoned(poisonDamage, poisonTicks);
			Destroy(gameObject);
		}
	}
}
