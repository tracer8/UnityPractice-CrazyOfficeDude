using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	
    void Awake()
    {
        DisableMeshRender();
    }

    private void DisableMeshRender()
    {
        MeshRenderer meshRender = this.GetComponentInChildren<MeshRenderer>();
        meshRender.enabled = false;
    }
}
