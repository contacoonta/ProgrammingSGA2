using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject hazardObj;
	public Vector3 spawnPos;

	[Range(8,20)] public int hazardCnt;
	public float startWait = 2;
	[Range(0.1f,0.7f)] public float spawnWait;
	[Range(3,10)] public float waveWait;

	public GUIText txtRestart;

	private bool bRestart;

	void Start () 
	{
		bRestart = false;
		txtRestart.enabled = false;
		StartCoroutine (SpawnWaves());
	}

	void Update ()
	{
		if ( bRestart == true )
		{
			if ( Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds ( startWait );
		while(true)
		{
			for (int i = 0; i < hazardCnt; i++) 
			{
				Vector3 pos = new Vector3 (Random.Range (-spawnPos.x, spawnPos.x), spawnPos.y, spawnPos.z);
				Instantiate (hazardObj, pos, Quaternion.identity);
				yield return new WaitForSeconds( spawnWait );
			}//for()
			yield return new WaitForSeconds( waveWait );

			if ( bRestart )
				txtRestart.enabled = true;
		}//while()
	}

	public void GameOver()
	{
		bRestart = true;
	}
}
