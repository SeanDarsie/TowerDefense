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
		// InvokeRepeating("RotateBetweenSlime", 1.0f,0.05f);
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
	int slimeIndex = 0;
	bool goingDown = false;
	[SerializeField] GameObject[] slimes;
	void RotateBetweenSlime()
	{
		if (goingDown == true)
		{
			if (slimeIndex == 4)
				goingDown = false;
			switch(slimeIndex)
			{
				case 0:
					slimes[0].SetActive(true);
					slimes[1].SetActive(false);
					slimes[2].SetActive(false);
					slimes[3].SetActive(false);
					slimes[4].SetActive(false);
					break;
				case 1:
					slimes[0].SetActive(false);
					slimes[1].SetActive(true);
					slimes[2].SetActive(false);
					slimes[3].SetActive(false);
					slimes[4].SetActive(false);
					break;
				case 2:
					slimes[0].SetActive(false);
					slimes[1].SetActive(false);
					slimes[2].SetActive(true);
					slimes[3].SetActive(false);
					slimes[4].SetActive(false);
					break;
				case 3:
					slimes[0].SetActive(false);
					slimes[1].SetActive(false);
					slimes[2].SetActive(false);
					slimes[3].SetActive(true);
					slimes[4].SetActive(false);
					break;
				case 4:
					slimes[0].SetActive(false);
					slimes[1].SetActive(false);
					slimes[2].SetActive(false);
					slimes[3].SetActive(false);
					slimes[4].SetActive(true);
					break;
				default:
					break;
			}
			slimeIndex++;
		}
		else
		{
			//slimeIndex--;
			if (slimeIndex == 0)
				goingDown = true;
			switch(slimeIndex)
			{
				case 0:
					slimes[0].SetActive(true);
					slimes[1].SetActive(false);
					slimes[2].SetActive(false);
					slimes[3].SetActive(false);
					slimes[4].SetActive(false);
					break;
				case 1:
					slimes[0].SetActive(false);
					slimes[1].SetActive(true);
					slimes[2].SetActive(false);
					slimes[3].SetActive(false);
					slimes[4].SetActive(false);
					break;
				case 2:
					slimes[0].SetActive(false);
					slimes[1].SetActive(false);
					slimes[2].SetActive(true);
					slimes[3].SetActive(false);
					slimes[4].SetActive(false);
					break;
				case 3:
					slimes[0].SetActive(false);
					slimes[1].SetActive(false);
					slimes[2].SetActive(false);
					slimes[3].SetActive(true);
					slimes[4].SetActive(false);
					break;
				case 4:
					slimes[0].SetActive(false);
					slimes[1].SetActive(false);
					slimes[2].SetActive(false);
					slimes[3].SetActive(false);
					slimes[4].SetActive(true);
					break;
				default:
					break;
			}
			slimeIndex--;
		}
	}
	
}
