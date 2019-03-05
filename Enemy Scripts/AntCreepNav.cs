using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCreepNav : CreepNav {
	[SerializeField] Transform[] bonePositions;
	[SerializeField] GameObject[] bones;

	void OnEnable()
	{
		ThisCreepHasDied += ScatterBones;
		ThisCreepHasDied += dieHorribly;
	}

	void OnDisable()
	{
		ThisCreepHasDied -= ScatterBones;
		ThisCreepHasDied -= dieHorribly;
	}
	
	void ScatterBones()
	{
		List<GameObject> boneScatter = new List<GameObject>();
		for (int i = 0; i < bonePositions.Length; i++)
		{
			GameObject x = Instantiate(bones[i], bonePositions[i].position, bonePositions[i].rotation);
			boneScatter.Add(x);
		}
		foreach(GameObject x in boneScatter)
		{
			x.GetComponent<Rigidbody>().AddForce((x.transform.position - transform.position).normalized * 200);
		}
	}

}
