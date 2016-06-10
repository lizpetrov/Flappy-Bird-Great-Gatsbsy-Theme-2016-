using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {

	public Vector2 velocity = new Vector2(-3, 0);
	Rigidbody2D tom;
	public float range = 4.4f;

	public float refresh = 7f;
	public float accumulator = 0.0f;

	// Use this for initialization
	void Start()
	{
		tom = gameObject.GetComponent<Rigidbody2D> ();

		transform.position = new Vector3(8, Random.Range(-1.9f, 2.4f), -0.5f);
		tom.velocity = velocity;
		accumulator = refresh;
	}
	
	// Update is called once per frame
	void Update () {
		accumulator -= Time.deltaTime;
		if (accumulator <= 0.01f) {
			Destroy (this.gameObject);
			accumulator = refresh;
		}
	}
}
