using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xmin, xmax, zmin, zmax;
}

public class PlayerCtrl : MonoBehaviour
{
	public float speed = 4.0f;
	public float tilt = 6.0f;
	public float yaw = 5.0f;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotMuzzle;
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotMuzzle.position, Quaternion.identity);
		}
	}

	void FixedUpdate()
	{
		float vert = Input.GetAxis ("Vertical");
		float horz = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3(horz,0.0f,vert);
		rigidbody.velocity = movement * speed * 100 * Time.deltaTime;

		float fx = Mathf.Clamp (rigidbody.position.x, boundary.xmin, boundary.xmax);
		float fz = Mathf.Clamp (rigidbody.position.z, boundary.zmin, boundary.zmax);
		rigidbody.position = new Vector3 (fx, 0.0f, fz);
		rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.z * yaw, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
