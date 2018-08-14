using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	[SerializeField] int score;
	[SerializeField] int health;
   	[SerializeField] int startingHealth;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(int x)
	{
		score += x;
	}
	public void ResetHealth()
	{
		health = startingHealth;
	}
	public void AdjustHealth(int someAmount)
	{
		health += someAmount;
	}

}
