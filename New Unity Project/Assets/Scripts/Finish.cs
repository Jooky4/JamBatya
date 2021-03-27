using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private GameObject checkObject;
    [SerializeField]
    private GameObject[] victoryPanel;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int rnd = Random.Range(0,3);
        Debug.Log("Finish" + rnd);
        victoryPanel[rnd].SetActive(true);
        gameManager.StopCameraAndPlayer();



            
    }


   

}
