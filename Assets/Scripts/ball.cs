using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void Hit(){
        Destroy(gameObject);
    }
}
