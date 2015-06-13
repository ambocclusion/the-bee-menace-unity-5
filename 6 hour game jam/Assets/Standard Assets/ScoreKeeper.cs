using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum BuildingTypes{
	Small,
	Large
}

public class ScoreKeeper : MonoBehaviour {

	public static ScoreKeeper Instance {get; private set;}

	public int PlayerScore = 0;
	public float RoundTime = 200;

	public Dictionary<BuildingTypes, int> BuildingValues = new Dictionary<BuildingTypes, int>() { {BuildingTypes.Large, 250}, {BuildingTypes.Small, 125}};

	public Text ScoreText;
	public Text TimerText;
	public GameObject GameOverText;

	private float _roundTimer = 0.0f;
	private bool _gameRunning = true;

	void Awake(){
		Instance = this;
	}

	void Start(){
		GameOverText.SetActive(false);
	}

	public void DestroyBuilding(BuildingTypes type){
		PlayerScore += BuildingValues[type];
	}

	void Update(){
		
		if(!_gameRunning)
			return;

		_roundTimer += Time.deltaTime;

		if(_roundTimer >= RoundTime)
			GameOver();
	}

	public void GameOver(){
		_gameRunning = false;
		GameOverText.SetActive(true);
	}

}
