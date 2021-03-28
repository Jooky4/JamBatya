using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public float PlayerStamina;//переменная выносливость
    //public Slider slider;
    public float fatigue = 2f; //переменная усталость


    void Update()
    {
        //PlayerStamina = Mathf.Clamp(0, 100);
        PlayerStamina = 100 - fatigue * Time.time;
        // slider.value = PlayerStamina;
        PlayerStamina = Mathf.Clamp(PlayerStamina, 0, 100);


        //Debug.Log(PlayerStamina);


    }
}
