using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public GameObject snake;
	public GameObject snakeBody;
	public float speed;
	public float rSpeed;
	Queue bodyQueue;
	float moveCount = 0;
	float maxMoveCount = 1f;
	float rota;
	int food = 2;
	Vector3 forward;
	CharacterController controller;
	// Use this for initialization
	void Start ()
	{
		bodyQueue = new Queue ();
		maxMoveCount /= speed;
		controller = snake.GetComponent<CharacterController> ();
	}
	void moveHead(){
		forward = snake.transform.TransformDirection(Vector3.forward)*speed;
		moveCount += Time.deltaTime;
		controller.Move (forward * Time.deltaTime);
		if (moveCount >= maxMoveCount/1.2) {
			moveCount = 0;
			bodyQueue.Enqueue (Instantiate (snakeBody,snake.transform.position+snake.transform.TransformDirection(Vector3.back),Quaternion.identity));
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) {
			snake.transform.Rotate (snake.transform.TransformDirection(Vector3.up)*-rSpeed*Time.deltaTime);
			rota -= rSpeed * Time.deltaTime;
		}else if (Input.GetKey (KeyCode.D)) {
			snake.transform.Rotate (snake.transform.TransformDirection(Vector3.up)*rSpeed*Time.deltaTime);
			rota += rSpeed * Time.deltaTime;
		}
		moveHead ();
	}
}
