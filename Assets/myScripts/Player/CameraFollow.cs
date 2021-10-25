using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject car;

    private Vector3 offsetPosition;


    [Header("Smooth")]
   // public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;


    private void Awake()
    {
        
    }
    private void Start()
    {
        car = GameObject.FindWithTag("Player");
        if (car == null)
        {
            return;
            //car = GameObject.FindGameObjectWithTag("KartClassic_Player");
            //car = GameObject.FindWithTag("Player");
        }
        
        offsetPosition = transform.position - (car.transform.position);
        

    }

    private void LateUpdate()
    {
        //transform.position = car.transform.position + car.transform.rotation * offsetPosition;
        Vector3 target = car.transform.position + car.transform.rotation * offsetPosition;

        

        //Smooth
        // Define a target position above and behind the target transform
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime);

        transform.LookAt(car.transform);


    }
    
}
