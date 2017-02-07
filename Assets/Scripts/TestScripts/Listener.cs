using UnityEngine;
using System.Collections;

public class Listener : MonoBehaviour {

    public NotificationsManager notificationManager = null;

	// Use this for initialization
	void Start () {

        if (notificationManager != null)
            notificationManager.AddListener(this, "OnKeyboardDown");
	}
	
	// Update is called once per frame
	void OnKeyboardDown(Component sender)
    {
        Debug.Log("Keyboard have a input");
	}
}
