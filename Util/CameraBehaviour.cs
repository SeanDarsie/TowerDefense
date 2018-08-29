using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	[SerializeField] float rotationSpeed;
	[SerializeField] float minHeight;
	[SerializeField] float maxHeight;
    [SerializeField] float moveSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
		transform.Rotate(Vector3.up * rotationSpeed);
	}
	void RotateRight()
	{
		transform.Rotate(-Vector3.up * rotationSpeed);
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
}
