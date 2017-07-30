using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlavourTextSelector : MonoBehaviour
{
	void Start ()
	{
		var DataStoreObject = GameObject.Find ("DataStore");
		if (DataStoreObject != null)
		{
			var _store = DataStoreObject.GetComponent<GameDataStore> ();
			if (_store != null)
			{
				List<string> flavourText = _store.Store ["flavourtext"] as List<string>;
				GetComponent<Text> ().text = flavourText [Random.Range (0, flavourText.Count)].ToLower ();
			}
		}
	}
}
