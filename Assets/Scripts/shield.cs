using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour {

    public GameObject Player;
    private Vector3 ballLocation;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        ballLocation = Player.transform.position;
        this.transform.position = ballLocation;
    }
}
