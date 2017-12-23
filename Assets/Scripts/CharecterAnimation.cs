using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharecterAnimation : MonoBehaviour {
    private Animator myAnimator;
    private PlayerController myplayer;


	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
        myplayer = FindObjectOfType<PlayerController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        myAnimator.SetFloat("Speed", 2.3f);
        myAnimator.SetBool("Grounded", myplayer.grounded);
		
	}
}
