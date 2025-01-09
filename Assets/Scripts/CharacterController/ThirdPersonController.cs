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

	private enum MovementState
	{
		Stopped,
		Moving
	}

	// Used for checking if player is actually moving
	private MovementState currentState = MovementState.Stopped;
	[SerializeField] private float velocityThreshold = 0.1f;

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

		// Update state machine based on vel (This is also how we are gonna trigger player animations)
		switch (currentState)
		{
			case MovementState.Stopped:
				// Check if moving
				if (agent.velocity.magnitude > velocityThreshold)
				{
					currentState = MovementState.Moving;
					Debug.Log("Moving");
				}
				break;

			case MovementState.Moving:
				// Check if stopped
				if (agent.velocity.magnitude <= velocityThreshold)
				{
					currentState = MovementState.Stopped;
					Debug.Log("Stopped");
				}
				break;
		}
	}
}
