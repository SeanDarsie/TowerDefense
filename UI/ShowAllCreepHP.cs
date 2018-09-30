using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAllCreepHP : MonoBehaviour {
	[SerializeField] string nameWhenCreepHealthIsOn;
	[SerializeField] string nameWhenCreepHealthIsOff;
	private CreepManager creepManager;
	bool hpIsOn = true;
	private Text buttonText;
	// Use this for initialization
	void Start () {
		creepManager = FindObjectOfType<CreepManager>();
		buttonText = GetComponentInChildren<Text>();
	}
	public void TurnOnAndOff()
	{
		if (hpIsOn)
			turnOffHealth();
		else
			turnOnHealth();
	}
	public void turnOffHealth()
	{
		CreepSpawner[] creepSpawner = FindObjectsOfType<CreepSpawner>();
		foreach (CreepSpawner x in creepSpawner)
		{
			if (x.isActiveAndEnabled)
			{
				foreach(GameObject creep in x.creeps)
				{
					creep.GetComponent<ShowTargetHealth>().turnOffHPBar();
				}
			}
		}
		foreach(GameObject x in creepManager.getActiveCreeps())
		{
			x.GetComponent<ShowTargetHealth>().turnOffHPBar();
		}
		hpIsOn = false;
		buttonText.text = nameWhenCreepHealthIsOn;
	}
	public void turnOnHealth()
	{
		CreepSpawner[] creepSpawner = FindObjectsOfType<CreepSpawner>();
		foreach (CreepSpawner x in creepSpawner)
		{
			if (x.isActiveAndEnabled)
			{
				foreach(GameObject creep in x.creeps)
				{
					creep.GetComponent<ShowTargetHealth>().turnOnHPBar();
				}
			}
		}
		foreach(GameObject x in creepManager.getActiveCreeps())
		{
			x.GetComponent<ShowTargetHealth>().turnOnHPBar();
		}
		hpIsOn = true;
		buttonText.text = nameWhenCreepHealthIsOff;
	}
}
