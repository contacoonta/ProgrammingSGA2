using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed = 10.0f;

	// Use this for initialization
	void Start () 
	{
		rigidbody.velocity = Vector3.forward * speed;
	}
}
