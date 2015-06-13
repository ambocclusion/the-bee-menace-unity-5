using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Powerups{

	Speed,
	SuperCharge

}

public class PowerupManager : MonoBehaviour {

	public static PowerupManager Instance {get; private set;}

	public CharacterControl Character;

	public Dictionary<Powerups, float> ActivePowerups = new Dictionary<Powerups, float>();
	public Dictionary<Powerups, float> PowerupTimes = new Dictionary<Powerups, float>(){{Powerups.Speed, 10.0f}, {Powerups.SuperCharge, 5.0f}};

	public float BonusSpeed = 40.0f;

	private float _defaultSpeed;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {

		_defaultSpeed = Character.PlayerSpeed;
	
	}

	public void ActivatePowerup(Powerups power){

		if(ActivePowerups.ContainsKey(power)){
			ActivePowerups[power] = Time.time;
			return;
		}

		ActivePowerups.Add(power, Time.time);
	}
	
	// Update is called once per frame
	void Update () {

		foreach(Powerups power in ActivePowerups.Keys){
			if(Time.time >= ActivePowerups[power] + PowerupTimes[power])
				ActivePowerups.Remove(power);
		}

		if(ActivePowerups.ContainsKey(Powerups.Speed)){
			Character.PlayerSpeed = BonusSpeed;	
		}
		else
			Character.PlayerSpeed = _defaultSpeed;

		if(ActivePowerups.ContainsKey(Powerups.SuperCharge))
			ScoreKeeper.Instance.SpecialCharge = 100.0f;

	}
}
