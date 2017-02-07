using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NotificationsManager))]

public class GameManager : MonoBehaviour {

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("GameManager").AddComponent<GameManager>();

            return instance;
        }
    }

    private static NotificationsManager notification = null;
    
    public static NotificationsManager Notification
    {
        get
        {
            if (notification == null)
                notification = instance.gameObject.GetComponent<NotificationsManager>();

            return notification;
        }
    }

    private void Awake()
    {
        if(instance != null && instance.GetInstanceID() != this.GetInstanceID())
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
