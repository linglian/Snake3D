using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public GameObject snake;
	public GameObject gameOverCanvas;
	public GameObject gameStartCanvas;
	public GameObject gameStatusCanvas;
	public GameObject snakeBody;
	public GameObject apple;
	public GameObject boom;
	public int mapWidth;
	public int mapHeight;
	GameObject text;
	public float speed;
	public float rSpeed;
	public int firstFood;
	Text tex;
	int food;
	int life;
	int point;
	bool isThird = false;
	Queue bodyQueue;
	Queue appleQueue;
	Queue boomQueue;
	float moveCount = 0;
	float maxMoveCount = 1f;
	float rota;
	bool isAlive;
	bool isTouchLeft;
	bool isTouchRight;
	Vector3 forward;
	CharacterController controller;
	// Use this for initialization
	void Start ()
	{
		tex = gameStatusCanvas.transform.GetComponentInChildren<Text> ();
		gameStatusCanvas.SetActive (false);
		gameOverCanvas.SetActive (false);
		gameStartCanvas.SetActive (true);
		isAlive = false;
	}
	public void changePlay(){
		if (isThird) {
			isThird = false;
			firstPlay ();
		} else {
			isThird = true;
			thirdPlay ();
		}
	}
	void thirdPlay(){
		Vector3 third = snake.transform.position;
		third.y = 15f;
		gameStatusCanvas.transform.Find ("Button").transform.Find ("Text").GetComponent<Text> ().text = "第一人称";
		snake.transform.Find ("mainCamera").transform.position = third;
		snake.transform.Find ("mainCamera").transform.Rotate (Vector3.right * 90f);
	}
	void firstPlay(){
		Vector3 first= snake.transform.position;
		first.y += 0.5f;
		gameStatusCanvas.transform.Find ("Button").transform.Find ("Text").GetComponent<Text> ().text = "第三人称";
		snake.transform.Find ("mainCamera").transform.position = first;
		snake.transform.Find ("mainCamera").transform.Rotate (Vector3.left * 90f);
	}
	public void gameOver ()
	{
		if (isThird) {
			isThird = true;
			firstPlay ();
		}
		gameOverCanvas.SetActive (true);
		gameStatusCanvas.SetActive (false);
		isAlive = false;
		while (bodyQueue.Count != 0) {
			Destroy ((GameObject)bodyQueue.Dequeue ());
		}
		while (appleQueue.Count != 0) {
			Destroy ((GameObject)appleQueue.Dequeue ());
		}
		while (boomQueue.Count != 0) {
			Destroy ((GameObject)boomQueue.Dequeue ());
		}
		snake.transform.position = Vector3.zero; 
	}

	public void addFood ()
	{
		setFood ();
		food++;
		life++;
		point++;
		if (point % 10 == 0) {
			speed++;
		}
	}

	public void setBoom(){
		Vector3 p = Vector3.zero;
		p.x = Random.Range (-(mapWidth/2f-3f-0.5f), (mapWidth/2f-3f-0.5f));
		p.z = Random.Range (-(mapWidth/2f-3f-0.5f), (mapWidth/2f-3f-0.5f));
		p.y = 0.5f;
		boomQueue.Enqueue (Instantiate (boom, p, Quaternion.identity));
	}
	public void setFood ()
	{
		Vector3 p = Vector3.zero;
		p.x = Random.Range (-(mapWidth/2f-3f-0.5f), (mapWidth/2f-3f-0.5f));
		p.z = Random.Range (-(mapWidth/2f-3f-0.5f), (mapWidth/2f-3f-0.5f));
		p.y = 0.5f;
		appleQueue.Enqueue (Instantiate (apple, p, Quaternion.identity));
		setBoom ();
	}

	public void rePlay ()
	{
		point = 0;
		isTouchLeft = false;
		isTouchRight = false;
		food = firstFood;
		life = firstFood;
		transform.Find ("Status").transform.Find ("startFight").GetComponent<donghua> ().start ();
		gameStatusCanvas.SetActive (true);
		gameOverCanvas.SetActive (false);
		gameStartCanvas.SetActive (false);
		isAlive = true;
		snake.transform.position = Vector3.zero; 
		bodyQueue = new Queue ();
		appleQueue = new Queue ();
		boomQueue = new Queue ();
		maxMoveCount /= speed;
		controller = snake.GetComponent<CharacterController> ();
		setFood ();
	}

	void moveHead ()
	{
		forward = snake.transform.TransformDirection (Vector3.forward) * speed;
		moveCount += Time.fixedDeltaTime;
		controller.Move (forward * Time.fixedDeltaTime);
		if (moveCount >= maxMoveCount / 0.24 / speed) {
			moveCount = 0;
			GameObject body = (GameObject)Instantiate (snakeBody, snake.transform.position + snake.transform.TransformDirection (Vector3.back), Quaternion.identity);
			body.transform.SetParent (this.transform);
			bodyQueue.Enqueue (body);
			moveTail ();
		}
	}

	void moveTail ()
	{
		if (food == 0) {
			Destroy ((GameObject)bodyQueue.Dequeue ());
		} else {
			food--;
		}
	}

	void run ()
	{
		if (Input.multiTouchEnabled) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				if (Input.GetTouch (0).position.x <= Screen.width / 2) {
					isTouchLeft = true;
				} else {
					isTouchRight = true;
				}
			} else if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Canceled) {
				isTouchRight = false;
				isTouchRight = false;
			}
		}
		if (Input.GetKey (KeyCode.A)||isTouchLeft) {
			snake.transform.Rotate (snake.transform.TransformDirection (Vector3.up) * -rSpeed * Time.deltaTime);
			rota -= rSpeed * Time.fixedDeltaTime;
		} else if (Input.GetKey (KeyCode.D)||isTouchRight) {
			snake.transform.Rotate (snake.transform.TransformDirection (Vector3.up) * rSpeed * Time.deltaTime);
			rota += rSpeed * Time.fixedDeltaTime;
		}
		moveHead ();
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (isAlive) {
			run ();
			tex.text = "积分:" + point+"   生命:"+life;
		}
	}
}
