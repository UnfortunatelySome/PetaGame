﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Position playerPosition;
	public Position gamePosition;
	public GameObject[] sectors;
	public bool losing;
	InputManager input;

	// Use this for initialization
	void Start () {
		losing = false;
		input = gameObject.GetComponent<InputManager> ();
		int i = 20;
		while (i >= 0) {
			int j = Random.Range (0, sectors.Length);
			spawnSector (gamePosition.position, sectors [j]);
			i--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		InputManager.swipes swipeDirection = InputManager.swipes.none;
		if (input.swipe () != null) {
			swipeDirection = input.swipe ();
		}
		if (swipeDirection == InputManager.swipes.down) {
			playerPosition.position = playerPosition.Behind ();
		} else if (swipeDirection == InputManager.swipes.up) {
			playerPosition.position = playerPosition.Forward ();
		} else if (swipeDirection == InputManager.swipes.right) {
			playerPosition.position = playerPosition.Right ();
		} else if (swipeDirection == InputManager.swipes.left) {
			playerPosition.position = playerPosition.Left ();
		}
	}

	void spawnSector(Vector3 relativePosition,GameObject sector){
		GameObject newSector = GameObject.Instantiate (sector, relativePosition, transform.rotation) as GameObject;
		gamePosition.position += newSector.GetComponent<Sector> ().length;
	}
}

[System.Serializable]
public class Position{
	public Vector3 position;
	public Position(float x, float y, float z){
		position.x = x - (x % 1);
		position.y = y - (y % 1);
		position.z = z - (z % 1);
	}
	public Vector3 Above(){
		return new Vector3 (position.x, position.y + 1, position.z);
	}
	public Vector3 Below(){
		return new Vector3 (position.x, position.y - 1, position.z);
	}
	public Vector3 Right(){
		return new Vector3 (position.x + 1, position.y, position.z);
	}
	public Vector3 Left(){
		return new Vector3 (position.x - 1, position.y, position.z);
	}
	public Vector3 Forward(){
		return new Vector3 (position.x, position.y, position.z + 1);
	}
	public Vector3 Behind(){
		return new Vector3 (position.x, position.y, position.z - 1);
	}
}