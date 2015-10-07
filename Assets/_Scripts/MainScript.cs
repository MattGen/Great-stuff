using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	public int ore;
	private GameController gameController;
	private Controls player;

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
		
		GameObject playerObject = GameObject.FindWithTag ("Player");
		if (playerObject != null)
		{
			player = playerObject.GetComponent <Controls>();
		}
		if (player == null)
		{
			Debug.Log ("Cannot find 'Controls' script");
		}	
	}

	void Main()
	{
	
	}


	public void AddOre(int oreValue)
	{
			oreValue = gameController.score/10;
			UpdateOre ();
	}

	public void UpdateOre()
	{
		ore = ore + oreValue;
	}
}