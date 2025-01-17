using BoatAttack;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
	// Start is called before the first frame update
	[SerializeField] bool started = false; 
	[SerializeField] bool ended = false;
	[SerializeField] float timer = 0f;
	[SerializeField] float resultDelay = 20f;
	[SerializeField] float maxTime = 300f;

	[SerializeField] AudioSource audioSource;

	void Start()
    {
        RaceManager.raceStarted += OnRaceStarted;

	}

	private void OnRaceStarted(bool obj)
	{
		Debug.Log("Race Started: "+ obj);
		if (obj)
		{
			started = true;
		}
	}

	// Update is called once per frame
	void Update()
    {
        if(started && !ended)
		{
			timer += Time.deltaTime;
			if (RaceManager.RaceStarted)
			{
				if(timer > maxTime)
				{
					Debug.Log("End Race");
					RaceManager.BoatFinished(0);
					Ended();
				}
			}
			else
			{
				Ended();
			}
		}

		if(ended)
		{
			timer += Time.deltaTime;
			if (timer > resultDelay)
			{
				Debug.Log("Quit App");
				started = false;
				ended = false;
				Application.Quit();
			}
		}
    }

	private void Ended()
	{
		ended = true;
		timer = 0;
		audioSource.Play();
	}
}
