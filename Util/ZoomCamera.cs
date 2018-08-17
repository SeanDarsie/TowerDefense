using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {


//	Vector3 zoomPos = new Vector3();
	[SerializeField] float minDist;
	[SerializeField] float maxDist;
	[SerializeField] float zoomSpeed;
	float distFromCenter;
	// Use this for initialization
	// void Start () {
	// 	zoomPos.Set(transform.position.x, transform.position.y, transform.position.z);
	// }

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			ZoomIn();
		}
		if (Input.GetKey(KeyCode.S))
		{
			ZoomOut();
		}
		// if (Input.GetMouseButtonDown(0))
		// 	ZoomIN();
		// if (Input.GetMouseButtonDown(1))
		// 	ZoomOut();
	}
	
	// Update is called once per frame
	public void ZoomIn()
	{
		distFromCenter = Vector3.Distance(transform.position, transform.parent.position);
		Debug.Log("ZoomIN()");
		if (distFromCenter <= minDist)
			return;
		transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
	}
	public void ZoomOut()
	{
		Debug.Log("ZoomOut()");
		distFromCenter = Vector3.Distance(transform.position, transform.parent.position);
		if (distFromCenter >= maxDist)
			return;
		transform.Translate(-Vector3.forward * zoomSpeed * Time.deltaTime);
	}
}
