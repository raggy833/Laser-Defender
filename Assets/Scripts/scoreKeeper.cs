using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class scoreKeeper : MonoBehaviour {

    public static int score = 0;
    private static Text myText;

    void Start(){
        myText = GetComponent<Text>();
    }

    public void Score(int points){
        score += points;
        myText.text = score.ToString();
    }

    public static void Reset(){
        score = 0;
    }
}
