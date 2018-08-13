using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {
	[Range(1f, 2f)]
	public float zoom;
	public Transform cam;
	Vector3 zoomPos = new Vector3();
	private int zoomLevel = 3;
	// Use this for initialization
	void Start () {
		zoomPos.Set(cam.position.x, cam.position.y, cam.position.z);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
			zoomIn();
		if (Input.GetMouseButtonDown(1))
			zoomOut();
	}
	
	// Update is called once per frame
	public void zoomIn()
	{
		if (zoomLevel >= 5)
			return;
		transform.Translate(Vector3.forward * 10);
		zoomLevel++;
	}
	public void zoomOut()
	{
		if (zoomLevel <= 0)
			return;
		transform.Translate(-Vector3.forward * 10);
		zoomLevel--;
	}
}
