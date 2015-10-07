using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
	{
		public float xMin, xMax, zMin, zMax;
	}
public class Controls : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public GameObject emptyShotSpawn;
	public Transform[] shotSpawn;
	public float fireRate;
	private float nextFire;
	
	void Update ()
	{
		//var selectSpawns = Instantiate(shot, shotSpawn[].position, shotSpawn[].rotation);
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn[0].position, shotSpawn[0].rotation);
		}
		if (Input.GetButton ("Fire2") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn[1].position, shotSpawn[1].rotation);
			Instantiate(shot, shotSpawn[2].position, shotSpawn[2].rotation);
			Test ();
		}
	}


	void FixedUpdate ()
	
	{

		float moveH = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		var ship = GetComponent<Rigidbody> ();
		Vector3 movement = new Vector3 (moveH,0.0f, moveV);
		ship.velocity = movement*speed;

		ship.position = new Vector3(
				Mathf.Clamp (ship.position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (ship.position.z, boundary.zMin, boundary.zMax)
				);
		
		ship.rotation = Quaternion.Euler (0.0f, 0.0f, ship.velocity.x * -tilt);

	}

	void Test ()
	{
		AudioSource laser = GetComponent<AudioSource>();
		laser.Play ();
	}
}