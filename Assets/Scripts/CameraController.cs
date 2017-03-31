using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		playerController = player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (!playerController.gameOver) {
			transform.position = player.transform.position + offset;
		} 
	}
}
