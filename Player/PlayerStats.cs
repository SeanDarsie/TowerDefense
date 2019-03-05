using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
	[SerializeField] int score = 0;
	[SerializeField] int health = 20;
   	[SerializeField] int startingHealth = 20;
	public int monies = 50;
	[SerializeField] int maxMonies = 9999;
	[SerializeField] int startingMonies;
	[SerializeField] Text scoreTxt;
	[SerializeField] Text lifeTxt;
	[SerializeField] Text moniesTxt;
	[SerializeField] GameObject pauseGameUI;
	QuitAndRestart quitAndRestart;
	bool playerHasLost = false;
    // Use this for initialization
    void Start () {
		AdjustHealth(0);
		AdjustMonies(0);
		UpdateScore(0);
		quitAndRestart = FindObjectOfType<QuitAndRestart>();
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (health <= 0)
			Lose();
	}
	public void UpdateScore(int x)
	{
		score += x;
		scoreTxt.text = "Score: " + score.ToString();
	}

	public void AdjustHealth(int someAmount)
	{
		health += someAmount;
		lifeTxt.text = "Life: " + health.ToString();
	}
	public void AdjustMonies(int someAmount)
	{
		monies += someAmount;
		if (monies > maxMonies)
			monies = maxMonies;
		moniesTxt.text  = "GOLD: " + monies;
	}
	void Lose()
	{
		if (playerHasLost == true)
			return;
		playerHasLost = true;
		quitAndRestart.PauseGame(true);

		// pause the game. 
		// change the music.
		// bring up a menu.
	}	
	public void ResetLevelHealthAndMonies()
	{
		playerHasLost = false;
		monies = startingMonies;
		health = startingHealth;
		UpdateScore(0);
		AdjustHealth(0);
		AdjustMonies(0);
	}
		// public void ResetHealth() // maybe this can be a reset for teh whole level.
	// {
	// 	health = startingHealth;
	// 	lifeTxt.text = "Life: " + health.ToString();
	// }
}
