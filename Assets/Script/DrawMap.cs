using UnityEngine;
using System.Collections;

public class DrawMap : MonoBehaviour {
	public int [][]map;
	// Use this for initialization
	void Start () {
		map = new int[50][50];
		for (int i = 0; i < 50; i++) {
			for (int j = 0; j < 50; j++) {
				if (i == 0 || j == 0 || i == 49 || j == 49) {
					map [i] [j] = 1;
				}
			}
		}
	}

	void drawMap(){
		for (int i = 0; i < 50; i++) {
			for (int j = 0; j < 50; j++) {
				switch(map[i][j]){
				case 0:
					break;
				case 1:
					break;
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
