﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItemPickUp : MonoBehaviour {

	public PlayerHealthManager playerHealthManager;
	public int healthHealPoint;
	public Animator animator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") 
		{
			playerHealthManager = other.GetComponent<PlayerHealthManager> ();
			animator = other.GetComponent<Animator> ();
			playerHealthManager.TakeDamage (-healthHealPoint);
			animator.SetTrigger ("Collect");
			Destroy (gameObject);
		}
	}
}
