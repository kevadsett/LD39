
using UnityEngine;
using UnityEngine.UI;

public class DistanceResultText : MonoBehaviour {

	void Start ()
	{
		var DataStoreObject = GameObject.Find ("DataStore");
		if (DataStoreObject != null)
		{
			var _store = DataStoreObject.GetComponent<GameDataStore> ();
			if (_store != null)
			{
				GetComponent<Text> ().text = string.Format ("{0} yards", _store.Store ["distance"]);
				_store.Store.Remove ("distance");
			}
		}
	}
}
