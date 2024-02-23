using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMouvement : MonoBehaviour
{
    [SerializeField] Transform camTarget; //The object the camera is going to follow (The player in this case)
    
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
   
    float hRotation;
    float vRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LateUpdate()
    {
      
    }
}
