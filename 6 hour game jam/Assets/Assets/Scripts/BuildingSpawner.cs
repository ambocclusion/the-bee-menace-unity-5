using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingSpawner : MonoBehaviour {

	public List<GameObject> Buildings = new List<GameObject>();

	void Start(){
		int random = Random.Range(0, Buildings.Count);

		if(Buildings[random] != null)
			Instantiate(Buildings[random], transform.position, Quaternion.identity);
		Destroy(this.gameObject);

	}

	
}
