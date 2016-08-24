using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public GameController gameController;
	public float moveSpeed;
	public Transform raycastPosition;
	// Use this for initialization
	void Start () {
		gameController = gameObject.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, gameController.playerPosition.position, moveSpeed);
		//checkBlock ();
	}
	void checkBlock(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, -Vector3.up, out hit, 100.0f)) {
			if (hit.collider.gameObject.tag == "Block") {
				Block block = hit.collider.gameObject.GetComponent<Block> ();
				if (block.walkable) {
				} else {
					SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				}
			} else {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}
}
