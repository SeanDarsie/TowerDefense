using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	[SerializeField] float rotationSpeed;
	[SerializeField] float rotationSpeedDecay = 2;
	[SerializeField] float rotationIncriment;
	[SerializeField] float minHeight;
	[SerializeField] float maxHeight;
    [SerializeField] float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * rotationSpeed);
		if (rotationSpeed < -0.01)
		{
			rotationSpeed += -(rotationSpeed / rotationSpeedDecay);
		}
		else if (rotationSpeed >= 0.01)
		{
			rotationSpeed -= (rotationSpeed / rotationSpeedDecay);
		}
		else
			rotationSpeed = 0;
		if (Input.GetKey(KeyCode.A))
		{
			RotateLeft();
		}
		if (Input.GetKey(KeyCode.D))
		{
			RotateRight();
		}
		if (Input.GetKey(KeyCode.E))
		{
			MoveUp();
		}
		if (Input.GetKey(KeyCode.Q))
		{
			MoveDown();
		}
	}

	void RotateLeft()
	{
		rotationSpeed += rotationIncriment;
		if (rotationSpeed >= 5f)
			rotationSpeed = 5f;
		// transform.Rotate(Vector3.up * rotationSpeed);
	}
	void RotateRight()
	{
		rotationSpeed -= rotationIncriment;
		if (rotationSpeed <= -5f)
			rotationSpeed = -5f;
		// transform.Rotate(-Vector3.up * rotationSpeed);
	}
	void MoveUp()
	{
		if (transform.position.y >= maxHeight)
			return;
		transform.Translate(Vector3.up * moveSpeed);
	}
	void MoveDown()
	{
		if (transform.position.y <= minHeight)
			return;
		transform.Translate(-Vector3.up * moveSpeed);
	}
	void ResetCameraRotationSpeed()
	{
		rotationSpeed = 0.0f;
	}
}
