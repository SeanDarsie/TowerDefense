using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpOrDown : MonoBehaviour {
	public void resetSpeed()
	{
		Time.timeScale = 1.0f; 
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
	public void IncreaseSpeed()
	{
		if (Time.timeScale >= 4.0f)
			return;
		Time.timeScale *= 2;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
	public void ReduceSpeed()
	{
		if (Time.timeScale <= 0.25)
			return;
		Time.timeScale /= 2;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
