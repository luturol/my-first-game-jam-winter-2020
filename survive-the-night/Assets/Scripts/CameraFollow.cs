using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraTemp = transform.position;
        cameraTemp.x = playerTransform.position.x;

        if(playerTransform.position.y > 0 || playerTransform.position.y < 0)
        {
            cameraTemp.y = playerTransform.position.y;
        }
        
        transform.position = cameraTemp;
    }
}
