using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	private float last_shot;
	private float shot_int = .1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButton ("Fire1")) {
			if (Time.time - last_shot >= shot_int) {
				Shoot ();
				last_shot = Time.time;
			} 
		}
		//else {
		//	click = false;
		//}
		//if (click == true) {
	//		Shoot ();
		
	//	}
	}
	void Shoot() {
		//yield return new WaitForSeconds (1);
					var bullet = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 15;
			Destroy(bullet, 2.0f);
		}
	}

