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
        lookatDirection.Normalize();

        // Rotate our object look at camera;
        Quaternion newRotation = Quaternion.LookRotation(-lookatDirection);
        newRotation.x = thisTransform.rotation.x;
        newRotation.z = thisTransform.rotation.z;

        thisTransform.rotation = newRotation;
    }
}
