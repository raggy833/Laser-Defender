using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}
    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
