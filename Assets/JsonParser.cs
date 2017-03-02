using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;

public class JsonParser : MonoBehaviour {

	public int id;
	public Text name;
	public Text height;
	public Text weight;

	private string jsonData;

	IEnumerator Start () {
		
		string url = "https://gist.githubusercontent.com/anonymous/4db1ffcbf9ab5e576dfa10e8b1b089b4/raw/846638148b2a9a8b48c60c7de13fe83507c087bf/star_store.json";
		WWW www = new WWW (url);
		yield return www;

		if (www.error == null) {
			jsonData = www.text;
		}


		JSONNode jsonNode = SimpleJSON.JSON.Parse(jsonData);

//		print (jsonNode[id-1]["name"]);
		name.text = jsonNode [id - 1] ["name"] + " - $" + jsonNode [id - 1] ["price"];
		height.text = "Height - "+ jsonNode [id - 1] ["height"];
		weight.text = "Weight - "+ jsonNode [id - 1] ["weight"];

	}

}
