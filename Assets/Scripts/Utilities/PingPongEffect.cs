using UnityEngine;
using System.Collections;

public class PingPongEffect : MonoBehaviour {

    public Vector3 direction;
    public float speedMove;
    public float maxDistance;

    private Transform thisTransform;

	// Use this for initialization
	void Start ()
    {
        thisTransform = this.transform;

        StartCoroutine(DoPingPongEffect());
	}

    private IEnumerator DoPingPongEffect()
    {
        while(true)
        {
            this.direction *= -1;

            yield return StartCoroutine(MoveObject());
        }
    }

    private IEnumerator MoveObject()
    {
        float distanceTraveled = 0f;
        Vector3 distanceToTravel = Vector3.zero;

        while(true)
        {
            if (distanceTraveled >= maxDistance)
                yield break;

            distanceToTravel = direction * speedMove * Time.deltaTime;
            thisTransform.position += distanceToTravel;

            distanceTraveled += distanceToTravel.magnitude;

            yield return null;
        }
    }
	
}
