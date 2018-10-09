using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicatingEnemy : Creep {
	[SerializeField] GameObject smallerEnemyPrefab;
	[SerializeField] float splitForce;
	public void MakeTwoSmallerEnemies()
	{
		GameObject thing1 = Instantiate(smallerEnemyPrefab, transform.position + (Vector3.up/2), transform.rotation);
		GameObject thing2 = Instantiate(smallerEnemyPrefab, transform.position - (Vector3.up/2), transform.rotation);
		thing1.GetComponent<SpawnedToken>().Spawn(cornersInd, corners, (transform.right + Vector3.up) * splitForce, maxHealth, name);
		thing2.GetComponent<SpawnedToken>().Spawn(cornersInd, corners, (-transform.right + Vector3.up) * splitForce, maxHealth, name);
		

		// then we need to give them the current index of the level as well as the corners themseleves. 
	}
	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		ThisCreepHasDied += MakeTwoSmallerEnemies;
		ThisCreepHasDied += dieHorribly;
	}
	/// <summary> 
	/// This function is called when the behaviour becomes disabled or inactive.
	/// </summary>
	void OnDisable()
	{
		ThisCreepHasDied -= dieHorribly;
		ThisCreepHasDied -= MakeTwoSmallerEnemies;
	}
	
}
