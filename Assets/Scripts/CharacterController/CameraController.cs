using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Credits - Joseph MacDonald
 * NSCC - Game Programming Student
 * This script handles logic for camera tracking of the player and camera rotation
*/

public class CameraController : MonoBehaviour
{
	[Header("Target Settings")]
	public Transform target;
	public Vector3 offset = new Vector3(0f, 3f, -6f);

	[Header("Rotation Settings")]
	public float rotationSpeed = 5f;
	public bool lockVerticalRotation = true; // Don't really need to look up and down I think?

	private float currentRotationY = 0f;

	void Start()
	{
		// Set pos of camera
		transform.position = target.position + offset;
		transform.LookAt(target.position);
	}

	void Update()
	{
		if (!target) return;

		// Handle camera rotation but only horizontal
		if (Input.GetMouseButton(1))
		{
			float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

			currentRotationY += mouseX;
		}

		Quaternion rotation = Quaternion.Euler(0f, currentRotationY, 0f);
		Vector3 rotatedOffset = rotation * offset;

		// Update camera pos
		transform.position = target.position + rotatedOffset;
		transform.LookAt(target.position);
	}
}
