﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundManager : MonoBehaviour {
	public Sound[] sounds;
	public int SEEME;
	// Use this for initialization

	public static SoundManager instance;
	void Awake () {
		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
		
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	
	// Update is called once per frame
	public void Play (string name)
	{
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null)
			return;
		s.source.Play();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
