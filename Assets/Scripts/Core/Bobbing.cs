/*
 * Title: Biag ni Lam-ang -  A platformer game about the Ilokano Folklore of Biag ni Lam-ang
 * 
 * Programmers:  Zalman Hajari Parial
 * 
 * Sub-System: Animation System, Physics system
 * 
 * Date written: December 28, 2022    Date Revised: January 2, 2023
 * 
 * Purpose: Makes the object bob up and down
 * 
 * Data Structures, algorithms, and control: Sin function
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speed = 3f;
    //adjust this to change how high it goes
    [SerializeField]
    float height = 0.15f;

    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
