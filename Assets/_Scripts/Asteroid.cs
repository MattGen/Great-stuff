using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
	public float tumble;
	public float speed;
	public float lifespan;
	public int scoreValue;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		var asteroid = GetComponent<Rigidbody> ();
		asteroid.angularVelocity = Random.insideUnitSphere * tumble;
		asteroid.velocity = transform.forward * speed;
		Destroy(gameObject, lifespan);
	}


	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Hazards")
		{
			other.attachedRigidbody.velocity = new Vector3 (0, 0, -5);
		} 
		else if (other.tag == "Player")
		{
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}