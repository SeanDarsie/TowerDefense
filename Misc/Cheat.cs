using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour {

	[HideInInspector] public int timesYouCheated;
	[SerializeField] Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Cheater()
	{
		timesYouCheated++;
		if (timesYouCheated == 1)
			text.text = "You've cheated " + timesYouCheated.ToString() + " time!";
		else
			text.text = "You've cheated " + timesYouCheated.ToString() + " times!";
		FindObjectOfType<PlayerStats>().AdjustMonies(100);
	}
}
