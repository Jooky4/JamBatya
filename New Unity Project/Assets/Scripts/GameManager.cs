using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabPlayer;
    [SerializeField]
    private Transform pointSpawn;
    [SerializeField]
    private Transform pointFinish;
    private GameObject Player;
    [SerializeField]
    private Slider sliderAlcohol;
    [SerializeField]
    private Text bottleText;
    private int bottle;
    private Alcohol alcohol;
    private CharacterController2D cC2D;
    [SerializeField]
    private GameObject[] panelLoss;




    private float valueAlcohol;

    // Start is called before the first frame update
    void Start()
    {
        Player = Instantiate(prefabPlayer, pointSpawn.position, Quaternion.identity);
        alcohol = Player.GetComponent<Alcohol>();
        cC2D = Player.GetComponent<CharacterController2D>();


    }

    // Update is called once per frame
    void Update()
    {

        sliderAlcohol.value = alcohol.alcohol;
        bottleText.text = alcohol.bottle.ToString();

        if (alcohol.alcohol == 1 && cC2D.isLive)
        {
           
            cC2D.isLive = false;
            int rnd = Random.Range(0, 3);
            Debug.Log("Belka " + rnd );
            panelLoss[rnd].SetActive(true);
        }


    }
}
