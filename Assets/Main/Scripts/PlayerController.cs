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
		checkBlock ();
	}
	void checkBlock(){
		RaycastHit hit;
		if (Physics.Raycast (raycastPosition.position, -Vector3.up, out hit, 100.0f)) {
			if (hit.collider.gameObject.tag == "Block") {
				Block block = hit.collider.gameObject.GetComponent<Block> ();
				if (block.walkable) {
						
				} else {
					Debug.Log ("Level End V1");
				}
			} else {
				Debug.Log ("Level end V2");
			}
			Debug.Log (hit.collider.gameObject.name);
		} else {
			Debug.Log ("Level end V3");
		}
	}
}
