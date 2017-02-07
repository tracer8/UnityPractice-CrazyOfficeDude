using UnityEngine;
using System.Collections;

public class Poster : MonoBehaviour {

    public NotificationsManager notificationManager = null;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown && notificationManager != null)
            notificationManager.PostNotification(this, "OnKeyboardDown");
	}
}
