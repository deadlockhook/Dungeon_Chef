using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * Credits - Joseph MacDonald
 * NSCC - Game Programming Student
 * This script handles logic for player movement using unity navmesh and clicking on enviroment
*/

public class ThirdPersonController : MonoBehaviour
{
	private NavMeshAgent agent;
	private Camera mainCamera;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		mainCamera = Camera.main;
	}

	void Update()
	{
		// Make player go to where you clicked
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				agent.SetDestination(hit.point);
			}
		}
	}
}
