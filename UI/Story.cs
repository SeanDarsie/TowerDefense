using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour {
	// the story so far
	[SerializeField] Text storyText;
	UImanager uImanager;
	[HideInInspector] public int storyIndex = 0;
	[SerializeField] string[] storyLines1;
	[SerializeField] string[] storyLines2;
	[SerializeField] string[] storyLines3;
	[SerializeField] string[] storyLines4;
	[SerializeField] string[] storyLines5;
	[SerializeField] string[] storyLines6;
	[SerializeField] string[] storyLines7;

	// Use this for initialization
	void Start () {
		uImanager = FindObjectOfType<UImanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void NextLine(int whatStory)
	{
		switch(whatStory)
		{
			case 0:
			{
				storyIndex++;
				if (storyIndex >= storyLines1.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines1[storyIndex];
				break;
			}
			case 1:
			{
				storyIndex++;
				if (storyIndex >= storyLines2.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines2[storyIndex];
				break;
			}
			case 2:
			{
				storyIndex++;
				if (storyIndex >= storyLines3.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines3[storyIndex];
				break;
			}
			case 3:
			{
				storyIndex++;
				if (storyIndex >= storyLines4.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines4[storyIndex];
				break;
			}
			case 4:
			{
				storyIndex++;
				if (storyIndex >= storyLines5.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines5[storyIndex];
				break;
			}
			case 5:
			{
				storyIndex++;
				if (storyIndex >= storyLines6.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines6[storyIndex];
				break;
			}
			case 6:
			{
				storyIndex++;
				if (storyIndex >= storyLines7.Length)
				{
					storyIndex = 0;
				}
				storyText.text = storyLines7[storyIndex];
				break;
			}
			default:
				break;
		}
	}
}
