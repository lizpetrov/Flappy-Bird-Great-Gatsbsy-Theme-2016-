using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Vector2 jumpForce = new Vector2 (0, 300);
	Rigidbody2D gatsby;
	float z;
	public Text textBox;
	public AudioClip otherClip;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		gatsby = gameObject.GetComponent<Rigidbody2D> ();
	//	AudioSource audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp("space") || Input.GetMouseButtonDown(0))
		{
			print ("space");
			gatsby.velocity = Vector2.zero;
			gatsby.AddForce(jumpForce);
		}

		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0)
		{
			Die();
		}

		if (gatsby.velocity.y > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 25);
		} 
		else {
			transform.rotation = Quaternion.Euler (0, 0, -5);	
		
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Die();
	}

	void Die()
	{
	//	audio.clip = otherClip;
	//	audio.Play ();

		obstacle[] toms = FindObjectsOfType<obstacle> ();

		foreach (obstacle tom in toms) {
			Destroy (tom.gameObject);
		} 

		gameObject.GetComponent<SpriteRenderer> ().enabled = false;

		//gameObject.SetActive (false);

	//	Time.timeScale = 0;

		StartCoroutine (wait(6));
		StopCoroutine ("wait");
		StartCoroutine (secondWait (6));
	}

	IEnumerator wait(float sec){
		textBox.text = "Tom got Daisy\nSorry Jay\nDaisy is only in your\nDreams";
	//	audio.Play ();
		yield return new WaitForSeconds (sec);
		textBox.text = "Sorry Mr.Gatsby\nDaisy is only in your\nDreams";
		yield return new WaitForSeconds (sec);
	//	Application.LoadLevel(Application.loadedLevel);
	}

	IEnumerator secondWait(float sec){
		textBox.text = "Sorry Mr.Gatsby\n\nDaisy is forever in your\nDreams";
		yield return new WaitForSeconds (sec);
		Application.LoadLevel(Application.loadedLevel);
	}
}
