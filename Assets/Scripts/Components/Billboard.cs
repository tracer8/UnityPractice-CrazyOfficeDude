using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    private Transform thisTransform;

    void Start()
    {
        thisTransform = this.transform;
    }

    void LateUpdate()
    {
        LookAtCamera();
    }

    private void LookAtCamera()
    {
        Vector3 cameraPosition;
        cameraPosition = Camera.main.transform.position;

        Vector3 lookatDirection;
        lookatDirection = cameraPosition - thisTransform.position;
        lookatDirection.y = 0;
        lookatDirection.Normalize();

        // Rotate our object look at camera;
        thisTransform.rotation = Quaternion.LookRotation(lookatDirection);
    }
}
