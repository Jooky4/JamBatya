using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform endPosition;
    [SerializeField]
    public float stepMoveCamera = 1;
    private float speedMove;
    [SerializeField]
    private float positionCameraZ = -10f;
    [SerializeField]
    private float positionCameraY = 30f;
    public bool isMoveCamera = true;



    void Start()
    {

        transform.position = new Vector3(startPosition.transform.position.x, positionCameraY, positionCameraZ);

    }

    void Update()
    {

        if (isMoveCamera)
        {
            speedMove = stepMoveCamera * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, speedMove);
            transform.position = new Vector3(transform.position.x, positionCameraY, positionCameraZ);
        }
       
    }
}
