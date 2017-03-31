using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text countTime;
	public Text gameOverText;
	public bool gameOver;

	private Rigidbody rb;
	private int count;
	private int numPickUps;
	private float time;
	private string pickUpTag;

	void Start ()
	{
		pickUpTag = "Pick Up";
		gameOverText.text = "";
		rb = GetComponent<Rigidbody> ();
		count = 0;
		time = 0.00f;
		numPickUps = GetNumPickUps ();
		gameOver = false;

		SetCountText ();	
		SetTimeText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float vectorMovementMultiplier = 15f;

		Vector3 movement = new Vector3 (moveHorizontal * vectorMovementMultiplier, 0.0f, moveVertical * vectorMovementMultiplier);
		SetTimeText ();
		rb.AddForce (movement);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag (pickUpTag)) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();

			numPickUps = GetNumPickUps ();
			if (numPickUps == 0) {
				gameOver = true;
				gameOverText.text = "GAME OVER";
			}
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
	}

	void SetTimeText ()
	{
		time += Time.deltaTime;
		countTime.text = "Time: " + time.ToString ("F2");
	}

	int GetNumPickUps ()
	{
		return GameObject.FindGameObjectsWithTag (pickUpTag).Length;
	}

}
