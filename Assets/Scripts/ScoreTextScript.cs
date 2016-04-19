using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {

    Text textComponent; 
	void Start () {
        textComponent = GetComponent<Text>();
	}
	
	
	void Update () {

		textComponent.text = "ქულა: "+ GlobalParams.Score.ToString();
	
	}
}
