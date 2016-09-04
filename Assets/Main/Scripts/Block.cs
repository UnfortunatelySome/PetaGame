using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public bool walkable;
	public bool moveable;

	public enum Hazards{Fire, Sharp, Squish, None};

	public Hazards hazard;
	void Start(){

	}
}
