using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour
{
	public Transform Exit;

	public Transform Player;

	private Text _text;

	private GameDataStore _store;

	void Start ()
	{
		_text = GetComponent<Text> ();
		var dataStoreObject = GameObject.Find ("DataStore");
		if (dataStoreObject != null)
		{
			_store = dataStoreObject.GetComponent<GameDataStore> ();
		}
	}

	void Update ()
	{
		int distance = Mathf.RoundToInt((Exit.position - Player.position).magnitude);
		_text.text = string.Format ("{0} yards", distance);

		if (_store.Store.ContainsKey ("distance"))
		{
			_store.Store["distance"] = distance;
		}
		else
		{
			_store.Store.Add ("distance", distance);
		}
	}
}
