using UnityEngine;
using System.Collections;

public class SpecialAttack : MonoBehaviour {

	public float growSpeed;

	public float DeathTime = 1.0f;

	private float totalTime = 0.0f;
	
	// Update is called once per frame
	void Update () {

		transform.localScale += new Vector3(growSpeed * Time.deltaTime, growSpeed * Time.deltaTime, growSpeed * Time.deltaTime);
		totalTime += Time.deltaTime;

		if(totalTime >= DeathTime)
			Destroy(this.gameObject);
		
	}
/*
	void OnCollisionEnter(Collision collider){
		if(collider.GetComponent<Debris>() != null)
			collider.GetComponent<Debris>().Explode(growSpeed, collider.contacts[0].point);
	}*/
}
