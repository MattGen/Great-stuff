using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public float lifespan;
	GameObject player;

	void Start ()
	{
		player = GameObject.Find ("Player");
		Controls playerSpeed = player.GetComponent<Controls>();
		GetComponent<Rigidbody>().velocity = transform.forward * (speed * playerSpeed.speed);
		Destroy(gameObject, lifespan);
	}
}