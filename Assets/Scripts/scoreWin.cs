﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text myText = GetComponent<Text>();
        myText.text = scoreKeeper.score.ToString();
        scoreKeeper.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
