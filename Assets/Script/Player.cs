using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject snake;
	public float speed;
	public float rSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float t = Input.GetAxis ("Vertical") * speed*Time.deltaTime;
		float r = Input.GetAxis ("Horizontal") * rSpeed * Time.deltaTime;
		snake.transform.Translate(0, 0, t);
		snake.transform.Rotate (0, r, 0);
	}
}
