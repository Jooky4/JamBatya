using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drunking : MonoBehaviour
{
    [SerializeField] private Sprite spr1, spr2, spr3;
    [SerializeField] private GameObject SpritePlayer;
    //[SerializeField] private GameObject AnimPlayer;
   // [SerializeField] private Animator playerNot, playerDrink, playerDrunk;
    private Alcohol alcohol;
   // private Animator anim;
    // Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        alcohol = GetComponent<Alcohol>();
        //anim = GetComponent<Animator>();
    }
     void Update()
    {
          //условие для замены спрайта


         if (alcohol.alcohol < 0.3f) {
             SpritePlayer.GetComponent<SpriteRenderer>().sprite = spr1;
            // AnimPlayer.GetComponent<Animator>().runtimeAnimatorController = playerNot;

        }
         if (alcohol.alcohol > 0.5f) {
            SpritePlayer.GetComponent <SpriteRenderer> ().sprite = spr2;
            //AnimPlayer.GetComponent<Animator>().runtimeAnimatorController = playerDrink;
        }
        if (alcohol.alcohol > 0.8f)
        {
            SpritePlayer.GetComponent<SpriteRenderer>().sprite = spr3;
           // AnimPlayer.GetComponent<Animator>().runtimeAnimatorController = playerDrunk;
        }
      
       

      
    }
}
