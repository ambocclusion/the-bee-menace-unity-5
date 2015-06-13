using UnityEngine;
using System.Collections;

public class PowerupTrigger : MonoBehaviour {

	public Powerups thisPowerup;

	void OnTriggerEnter(Collider collider){

		if(collider.GetComponent<CharacterControl>() != null){
			PowerupManager.Instance.ActivatePowerup(thisPowerup);
			Destroy(this.gameObject);
		}

	}
}
