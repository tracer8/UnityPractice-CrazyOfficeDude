using UnityEngine;
using System.Collections;

public class HeadBobEffect : MonoBehaviour {

    public float amplitude;
    public float frenquency;

    //Neutral head height position
    public float neutralHeadHeightPosition = 1.0f;

    private float elapsedTime = 0f;
    private Transform thisTransform;

	// Use this for initialization
	void Start ()
    {
        thisTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MakeHeadBob();
    }

    private void MakeHeadBob()
    {
        if (GameManager.Instance.IsAllowInput == false)
            return;

        Vector3 newCameraPosition = GetNewPosition();
        thisTransform.position = newCameraPosition;
    }

    private Vector3 GetNewPosition()
    {
        // Get player movement
        float verticalMoveAxis = Mathf.Abs(Input.GetAxis("Vertical"));
        float horizontalMoveAxis = Mathf.Abs(Input.GetAxis("Horizontal"));

        // Calculate elapsed time 
        float totalMovementAxis = verticalMoveAxis + horizontalMoveAxis;
        totalMovementAxis = Mathf.Clamp(totalMovementAxis, 0f, 1f);

        if (totalMovementAxis > 0)
            elapsedTime += Time.deltaTime;
        else
            elapsedTime = 0;

        // Calculate new YOffset by sine wave formula
        float YOffset = Mathf.Sin(elapsedTime * frenquency) * amplitude;

        // Calculate new position
        Vector3 newPosition = this.gameObject.transform.position;
        newPosition.y = neutralHeadHeightPosition + YOffset * totalMovementAxis;

        return newPosition;
    }
}
