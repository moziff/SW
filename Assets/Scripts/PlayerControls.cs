using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public GameObject[] waypoints;
	public GameObject[] info;

	private int index;

	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			
			if (index == 0) {
				info [info.Length - 1].gameObject.SetActive (false);
			} else {
				info [index - 1].gameObject.SetActive (false);
			}
			index++;
			if (index == waypoints.Length) {
				index = 0;
				transform.rotation = Quaternion.Euler(0, 0, 0);
				StartCoroutine(MoveToPosition(transform, waypoints[index].transform.position, 0.2f));	
			} else { 
				info [index - 1].gameObject.SetActive (true);
				StartCoroutine(MoveToPosition(transform, waypoints[index].transform.position, 0.2f));
			

			}
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			
			if (index == 0) {
				info [1].gameObject.SetActive (false);
			} else {
				info [index - 1].gameObject.SetActive (false);
			}
			index--;

			if (index < 0) {
				index = index+7;
			}

			if (index == 0) {
				transform.rotation = Quaternion.Euler(0, 0, 0);
				StartCoroutine(MoveToPosition(transform, waypoints[index].transform.position, 0.2f));	
			} else { 
				
				info [index - 1].gameObject.SetActive (true);
				StartCoroutine(MoveToPosition(transform, waypoints[index].transform.position, 0.2f));

			}
		}
		
	}

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
	{
		var currentPos = transform.position;
		var t = 0f;
		while(t < 1)
		{
			if (index == 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				transform.LookAt(info[index-1].transform);
			}
			t += Time.deltaTime / timeToMove;
			transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;

		}

	}


}
