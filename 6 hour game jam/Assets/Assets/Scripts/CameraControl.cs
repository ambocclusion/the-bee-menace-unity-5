using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform Target;
	public float offset = -10.0f;
	public float FollowSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		Vector3 destination = Target.position + transform.TransformDirection(new Vector3(0,0, offset));
		transform.position = Vector3.Lerp(transform.position, destination, FollowSpeed * Time.deltaTime);
	
	}
}
