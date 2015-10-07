using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int waveCount;

	public GUIText scoreText;
	public int score;


	void Start ()
	{
		score = 0;
		UpdateScore();
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for(int j = 0; j < waveCount; j++)
			{
				while (true)
				{
					for (int i = 0; i < hazardCount; i++)
					{
						float randomHazard = Random.value;
						if (0.66 < randomHazard)
						{
							randomHazard = 1;
						} 
						int randomNow = (int) randomHazard;
						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
						Quaternion spawnRotation = Quaternion.identity;
						Instantiate (hazards[randomNow], spawnPosition, spawnRotation);
						yield return new WaitForSeconds (spawnWait);
					}
					yield return new WaitForSeconds (waveWait);
				}
			}
		MainScript.
	}
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "score : " + score;
	}
}