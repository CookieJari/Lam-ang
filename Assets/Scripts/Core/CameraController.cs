/*
 * Title: Biag ni Lam-ang -  A platformer game about the Ilokano Folklore of Biag ni Lam-ang
 * 
 * Programmers:  Asher Manangan
 * 
 * Sub-System: Animation System, Combat System, Health System
 * 
 * Date written: August 23, 2022    Date Revised: November 4, 2023
 * 
 * Purpose: Controls the camera
 * 
 * Data Structures, algorithms, and control: Arrays,
 * 
 * */
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Room Camera
   [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow Player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    private void Update()
    {
        //Room Camera
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), 
        //ref velocity, speed);
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}