using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmPos : MonoBehaviour {
	
	public Vector2 startpos;
	public Camera cam;
	public GameObject p3;

	public GameObject[] arr;

	public int i;
	// Use this for initialization
	void Start () {

		arr = new GameObject[5];

		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && i<5) {
			startpos = cam.ScreenToWorldPoint (Input.mousePosition);

			arr [i] = Instantiate (p3, startpos, Quaternion.identity);
			i++;
			StartCoroutine (dests());
			Debug.Log (arr.Length);
		}
	}

	IEnumerator dests ()
	{

		yield return new WaitForSeconds(3f);



		Destroy (GameObject.Find ("p3(Clone)"));
		i--;

	}
}
