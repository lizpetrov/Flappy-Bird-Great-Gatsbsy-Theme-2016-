using UnityEngine;
using System.Collections;

public class CheckPassing : MonoBehaviour {

	//public Player gatsby;
	public bool hasPassed;
	private score theScore;

	// Use this for initialization
	void Start () {
		theScore = FindObjectOfType<score> ();
		hasPassed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasPassed && -3.3 > transform.position.x) {
			theScore.scoreNum += 1;
			hasPassed = true;
		}
	}
}
