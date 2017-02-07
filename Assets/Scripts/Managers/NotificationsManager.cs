using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationsManager : MonoBehaviour {

    // Group of listeners
    private Dictionary<string, List<Component>> Listeners = new Dictionary<string, List<Component>>();

    public void AddListener(Component listener, string notificationName)
    {
        if (!Listeners.ContainsKey(notificationName))
            Listeners.Add(notificationName, new List<Component>());

        Listeners[notificationName].Add(listener);
    }

    public void PostNotification(Component sender, string notificationName)
    {
        if (!Listeners.ContainsKey(notificationName))
            return;

        // Do function for all matching listener
        foreach(Component listener in Listeners[notificationName])
        {
            listener.SendMessage(notificationName, sender, SendMessageOptions.RequireReceiver);
        }
    }

    public void RemoveListener(Component listener, string notificationName)
    {
        if (!Listeners.ContainsKey(notificationName))
            return;

        // Use for loop decrease, cause if we remove some object inside, the loop will change if
        // we increase
        for(int i = Listeners.Count - 1; i >= 0; i--)
        {
            // If instance id same, remove this
            if (Listeners[notificationName][i].GetInstanceID() == listener.GetInstanceID())
                Listeners[notificationName].RemoveAt(i);
        }
    }

    public void RemoveRedundantListener()
    {
        Dictionary<string, List<Component>> tempListeners = new Dictionary<string, List<Component>>();

        foreach(KeyValuePair<string, List<Component>> item in Listeners)
        {
            for(int i = item.Value.Count - 1; i >= 0; i--)
            {
                if (item.Value[i] == null)
                    item.Value.RemoveAt(i);
            }

            if (item.Value.Count > 0)
                tempListeners.Add(item.Key, item.Value);
        }

        // Regenerate our listeners after remove all redundant listeners
        Listeners = tempListeners;
    }
}
