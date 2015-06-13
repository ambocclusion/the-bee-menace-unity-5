using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour {

	public float PlayerSpeed = 5.0f;
	public Transform mainCamera;
	private CharacterController _characterController;

	private Vector3 startPos = new Vector3();

	public GameObject AttackPrefab;
	public Transform AttackOrigin;

	// Use this for initialization
	void Start () {

		_characterController = GetComponent<CharacterController>();
		startPos = transform.position;
	
	}
	
	private float _lastFire = 0.0f;
	// Update is called once per frame
	void Update () {

		Vector2 playingInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		float firingInput = Input.GetAxis("Fire1");

		Vector3 faceDir = new Vector3(transform.position.x + playingInput.x, transform.position.y, transform.position.z + playingInput.y);

		transform.LookAt(faceDir);

		_characterController.Move(new Vector3((mainCamera.forward.x * (playingInput.x * PlayerSpeed)) * Time.deltaTime, 0, (mainCamera.transform.forward.z * (playingInput.y * PlayerSpeed)) * Time.deltaTime));
		transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);

		if(ScoreKeeper.Instance.SpecialCharge == 100.0f && firingInput != 0 && _lastFire != firingInput)
			Fire();

		_lastFire = firingInput;
	
	}

	void Fire(){

		GetComponent<Animator>().SetTrigger("fire");
		Invoke("CreatePrefab", .65f);
		ScoreKeeper.Instance.SpecialCharge = 0.0f;

	}

	void CreatePrefab(){

		Instantiate(AttackPrefab, AttackOrigin.position, Quaternion.identity);

	}
}
