﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour {

	private ProgressBar status;
	public GameObject levelCompleteCanvas;
	public string nextLevel;
	public float delay = 4f;
	public bool isComplete;

	public Text theTextEnemyKill;
	public Text theTextConstructKill;
	public Text theTextEnemySurvived;
	public Text title;

	public int intEnemyKilled;
	public int intConstructKilled;
	private  int holdForTotalEnemyKill=0;
	private  int holdForTotalConstructDestroy=0;
	private  int holdForTotalEnemySurvived = 0;
	private int intTotalEnemySurvived;
	private bool isAdded;
	public bool isLastLevel;
	private int highScore;

	private LevelManager levelManager;

	float delayTimer;
	void Start () {
		isComplete = false;
		status = FindObjectOfType<ProgressBar> ();
		levelManager = FindObjectOfType<LevelManager> ();
		isAdded = false;

	}
	

	void Update () 
	{
		if(status.progress>=status.maxValue)
		{
			delayTimer += Time.deltaTime;

				if (delayTimer >= delay) 
					{
				isComplete = true;
				levelCompleteCanvas.SetActive (true);
				if (!isLastLevel) {
					
					intEnemyKilled = PlayerPrefs.GetInt ("EnemyKilled");
					theTextEnemyKill.text = "Enemy Killed: " + intEnemyKilled;

					intConstructKilled = PlayerPrefs.GetInt ("ConstructionDestroyed");
					theTextConstructKill.text = "Construct Destroyed: " + intConstructKilled;


					theTextEnemySurvived.text = "Enemy Survived: " + (levelManager.totalEnemies - intEnemyKilled - intConstructKilled);
				}

				if (isLastLevel) {
					title.text = "GAME COMPLETE";
					intEnemyKilled = PlayerPrefs.GetInt ("TotalEnemyKills");
					theTextEnemyKill.text = "Total Enemy Killed: " + intEnemyKilled;

					intConstructKilled = PlayerPrefs.GetInt ("TotalConstructDestroy");
					theTextConstructKill.text = "Total Construct Destroyed: " + intConstructKilled;
					intTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");
					theTextEnemySurvived.text = "Total Enemy Survived: " + intTotalEnemySurvived;
					highScore = intEnemyKilled + intConstructKilled;
					PlayerPrefs.SetInt ("HighScore", highScore);

				}





							Time.timeScale = 0f;
				if (!isAdded) 
				{
					holdForTotalEnemyKill = PlayerPrefs.GetInt ("TotalEnemyKills");
					//Debug.Log (holdForTotalEnemyKill);


					holdForTotalConstructDestroy = PlayerPrefs.GetInt ("TotalConstructDestroy");
					holdForTotalEnemySurvived = PlayerPrefs.GetInt ("TotalEnemySurvived");

					holdForTotalEnemySurvived += levelManager.totalEnemies - intEnemyKilled - intConstructKilled;
					holdForTotalEnemyKill += intEnemyKilled;
					holdForTotalConstructDestroy += intConstructKilled;

					//Debug.Log (holdForTotalEnemyKill);
					PlayerPrefs.SetInt ("TotalEnemyKills", holdForTotalEnemyKill);
					//Debug.Log (holdForTotalEnemyKill);

					PlayerPrefs.SetInt ("TotalConstructDestroy", holdForTotalConstructDestroy);
					PlayerPrefs.SetInt ("TotalEnemySurvived", holdForTotalEnemySurvived);
					isAdded = true;
				}


					}
		}
	}



	public void NextLevel()
	{
		SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);		

	}




}