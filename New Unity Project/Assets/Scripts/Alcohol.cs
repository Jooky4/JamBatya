using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcohol : MonoBehaviour
{
       
    [SerializeField]
    private float stepAlcohol = 0.1f;
    public float alcohol;
    public int bottle;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bottle")
        {
            Debug.Log("Bottle");
            Destroy(collision.gameObject, 0.2f);
           
            alcohol += stepAlcohol;
            bottle++;

            bottle = Mathf.Clamp(bottle, 0, 20);
            alcohol = Mathf.Clamp(alcohol, 0, 1);
        }

    }



}
