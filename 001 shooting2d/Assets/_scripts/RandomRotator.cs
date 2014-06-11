using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	[Range(0,10)]
	public float tumble;
	// Use this for initialization
	void Start ()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
