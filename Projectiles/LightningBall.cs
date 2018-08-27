using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightningBall : MonoBehaviour {

	[HideInInspector]
	public int damage;
	[HideInInspector]
	public int numberOfBounces;
	[SerializeField] GameObject[] lightningPrefab;
	[SerializeField] GameObject[] lightningEndpoints;
	[SerializeField] CountEnemiesInCollider enemiesInCollider;
	float readyToSwitchTargets;
	float maxDistance = 5.0f;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 20.0f);
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		foreach (GameObject x in enemiesInCollider.creepsInsideCollider)
		{
			DigitalRuby.LightningBolt.LightningBoltScript lb = getInactiveLightningBolt();
			if (lb != null)
			{
				lb.EndObject = x;
				StartCoroutine(shootLightning(lb, x));
			}
		}
	}
	// void OnTriggerEnter(Collider other)
	// {	
	// 	IShockable x = other.GetComponent<IShockable>();
	// 	if (x != null)
	// 	{
	// 		x.BeShocked(damage, numberOfBounces);
	// 		Destroy(gameObject);
	// 	}
	// }
	// void SwitchLightningTarget()
	// {
	// 	readyToSwitchTargets = Time.time + UnityEngine.Random.Range(0,0.5f);
	// 	lightningPrefab.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndObject = lightningEndpoints[UnityEngine.Random.Range(0, lightningEndpoints.Length)];
	// }
	DigitalRuby.LightningBolt.LightningBoltScript getInactiveLightningBolt()
	{
		foreach (GameObject x in lightningPrefab)
		{
			if (!x.activeInHierarchy)
				{
					x.SetActive(true);
					return x.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>();
				}
		}
		return(null);
	}
	IEnumerator shootLightning(DigitalRuby.LightningBolt.LightningBoltScript lightning, GameObject target)
	{
		// do periodic damage while the target is alive. if target is not alive turn off teh lightning gameobject 
		// readyToSwitchTargets = Time.time + 0.1f;
		while (target.activeInHierarchy)
		{
			if (Vector3.Distance(transform.position, target.transform.position) > maxDistance)
				break;
			target.GetComponent<IShockable>().BeShocked(damage, numberOfBounces);
			yield return new WaitForSeconds(0.25f);
		}
		lightning.gameObject.SetActive(false);
		yield return null;
	}
}
