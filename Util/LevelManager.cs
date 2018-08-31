using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	[SerializeField] Transform[] corners0;
	[SerializeField] Transform[] corners1;
	[SerializeField] Transform[] corners2;
	[SerializeField] Transform[] corners3;
	[SerializeField] Transform[] corners4;
	[SerializeField] Transform[] corners5;
	
	[SerializeField] int levelIndex;
	public int whatLevelIsSelected; //WAIT I CAN JUST HAVE THE CREEPSPAWNER DO IT

	public Transform[] getCoreners()
	{
		switch(levelIndex)
		{
			case 0:
				return(corners0);
			case 1:
				return(corners1);
			case 2:
				return(corners2);
			case 3:
				return(corners3);
			case 4:
				return(corners4);
			case 5:
				return(corners5);
			default:
				return (corners0);
			
		}
	}
	public void RestartCurrentLevel()
	{
		Time.timeScale = 1f;
		List<GameObject> activeCreeps = FindObjectOfType<CreepManager>().getActiveCreeps();
		foreach (GameObject x in activeCreeps)
			{
				x.SetActive(false);
			}
			FindObjectOfType<CreepManager>().ReMakeList();
		CreepSpawner[] spawners = FindObjectsOfType<CreepSpawner>();
		foreach (CreepSpawner x in spawners)
		{
			x.SetWave(0);
		}
	}
}
