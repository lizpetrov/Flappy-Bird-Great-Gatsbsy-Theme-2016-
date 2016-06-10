using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Generate : MonoBehaviour {

	public GameObject obstacle;
	public GameObject player;
	public float refresh = 2.5f;
	public float accumulator = 0.0f;
	private int score = 0;
	public Text myText;
	private bool spacePressed;
	public int count = 0;


	// Use this for initialization
	void Start() {
		player.SetActive (false);

		accumulator = 0;

		myText.text = "Hello\nGatsby,\nGet Daisy\n(|)(|)(|)\nTap to start";
		spacePressed = false;

		count = 1;

	}

	void CreateObstacle()
	{
		Instantiate(obstacle);
		score++;
	}

//	void OnGUI () 
//	{s
//		GUI.color = Color.black;
//		GUILayout.Label(" Score: " + score.ToString());
//	}
	
	// Update is called once per frame
	void Update () {
		if (spacePressed == false)
		if (Input.GetKeyUp ("space") || Input.GetMouseButtonDown(0))
				spacePressed = true;


		if (spacePressed == true) {
			accumulator -= Time.deltaTime;
			if (accumulator <= 0.01f) {
			if (count <= 7) {
				if (count == 0) {
					myText.text = "Hello\nGatsby,\nGet Daisy\n(|)(|)(|)\nTap to start";
					accumulator = 1.0f;
				} else if (count == 1) {
					myText.text = "Tap to make Gatsby jump\n\nAvoid Tom";
					accumulator = 2.5f;
				} else if (count == 2) {
					myText.text = "Head towards the green light to get Daisy";
					accumulator = 2.0f;
				} else if (count == 3) {
					myText.text = "3";
					accumulator = 1.0f;
				} else if (count == 4) {
					myText.text = "2";
					accumulator = 1.0f;
				} else if (count == 5) {
					myText.text = "1";
					accumulator = 1f;
				} else if (count == 6) {
						player.SetActive (true);
						myText.text = "GO";
						accumulator = 1f;
				} else if (count == 7) {
					myText.text = "";
				}

				print ("count" + count);
				count++;
			//	accumulator = 1.0f;
			} 

			else {
				CreateObstacle ();
				accumulator = refresh;
			}
			}
		}
	}
}
