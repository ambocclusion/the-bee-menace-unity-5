using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreKeeper : MonoBehaviour {

	public static ScoreKeeper Instance {get; private set;}

	public int PlayerScore = 0;
	public float RoundTime = 200;

	public Dictionary<BuildingTypes, int> BuildingValues = new Dictionary<BuildingTypes, int>() { {BuildingTypes.Large, 250}, {BuildingTypes.Small, 125}};

	public float SpecialCharge = 0.0f;

	public CoolText ScoreText;
	public CoolText TimerText;
	public GameObject GameOverText;
	public GameObject SpecialBar;
	public CoolText ChargedText;

	private float _roundTimer = 0.0f;
	private bool _gameRunning = true;
	private int _displayScore = 0;

	void Awake(){
		Instance = this;
	}

	void Start(){
		GameOverText.SetActive(false);
		_roundTimer = RoundTime;
		ChargedText.gameObject.SetActive(false);
	}

	public void DestroyBuilding(BuildingTypes type){
		PlayerScore += BuildingValues[type];
		SpecialCharge += BuildingValues[type] * .025f;
	}

	void Update(){

		if(_displayScore != PlayerScore)
			_displayScore = Mathf.FloorToInt(Mathf.MoveTowards(_displayScore, PlayerScore, 25));

		ScoreText.GetComponent<CoolText>().text = _displayScore.ToString();
		
		if(!_gameRunning)
			return;

		SpecialCharge += 2.0f * Time.deltaTime;

		SpecialCharge = Mathf.Clamp(SpecialCharge, 0.0f, 100.0f);
		SpecialBar.transform.localScale = new Vector2(SpecialCharge / 100.0f, SpecialBar.transform.localScale.y);

		if(SpecialCharge >= 100.0f)
			ChargedText.gameObject.SetActive(true);
		else
			ChargedText.gameObject.SetActive(false);

		_roundTimer -= Time.deltaTime;

		string timer = string.Format("{0}:{1:00}", (int)_roundTimer / 60, (int)_roundTimer % 60);
		TimerText.text = timer;

		if(_roundTimer >= RoundTime)
			GameOver();
	}

	public void GameOver(){
		_gameRunning = false;
		GameOverText.SetActive(true);
	}

}
