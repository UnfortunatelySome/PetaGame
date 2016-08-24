using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public Vector2 firstPressPos;
	public Vector2 secondPressPos;
	public Vector2 currentSwipe;

	public enum swipes{up,down,left,right,none};

	public swipes swipe(){
		if(Input.touches.Length > 0){
			Touch t = Input.GetTouch (0);
			if(t.phase == TouchPhase.Began){
				firstPressPos = new Vector2(t.position.x, t.position.y);
			}
			if(t.phase == TouchPhase.Ended){
				secondPressPos = new Vector2 (t.position.x, t.position.y);
				currentSwipe = new Vector2 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				currentSwipe.Normalize ();
				if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					return swipes.up;
				}if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
					return swipes.down;
				}if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					return swipes.right;
				}if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
					return swipes.left;
				}
				return swipes.none;
			}
			return swipes.none;
		}
		return swipes.none;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
