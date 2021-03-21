using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleArea : MonoBehaviour
{
    [SerializeField]
    private GameObject SideSprite1;
    [SerializeField]
    private GameObject SideSprite2;




    // Start is called before the first frame update
    void Start()
    {
        SideSprite1.SetActive(true);
        SideSprite2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("InSide");
            SideSprite1.SetActive(false);
            SideSprite2.SetActive(false);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("OutSide");
            SideSprite1.SetActive(true);
            SideSprite2.SetActive(true);
        }
    }
}
