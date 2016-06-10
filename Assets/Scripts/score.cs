using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public int scoreNum = 0;
	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = gameObject.GetComponent<Text> ();
		scoreText.text = "Score goes here";
	}
	
	// Update is called once per frame
	void Update () {
			scoreText.text = "Times you outdid Tom " + scoreNum;
	}
}
