using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDestroyer : MonoBehaviour
{
	public GameObject particlePrefab;
private void OnTriggerEnter(Collider other) 
{
	Destroy(gameObject);
	if (other.tag=="Enemy")
	{
		Scoremanager.instance.killScore += 1;
		// Instantiate(particlePrefab, other.transform.position, other. transform.rotation);
		Destroy(other.gameObject);
	}
}
}
