using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
	public float distance;
	public float angle;
	public LayerMask objectsLayers;
	public LayerMask obstaclesLayers;

	private void Update()
	{
		Collider[] colliders = Physics.OverlapSphere(
			transform.position, distance, objectsLayers
		);

		for (int i = 0; i < colliders.Length; i++)
		{
			Collider collider = colliders[i];
		}
	}
}
