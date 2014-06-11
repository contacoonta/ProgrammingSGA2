using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject explosionPlayer;

	private GameManager gamemgr;

	void Start()
	{
		GameObject objGameMgr = GameObject.FindWithTag ("GameController");
		if ( objGameMgr )
		{
			gamemgr = objGameMgr.GetComponent<GameManager>();
		}
		else
		{
			Debug.Log("Cannot find 'GameManager' Script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary") return;

		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag == "Player") 
		{
			Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
			gamemgr.GameOver();
		}

		Destroy(other.gameObject);
		Destroy (gameObject);
	}

}
