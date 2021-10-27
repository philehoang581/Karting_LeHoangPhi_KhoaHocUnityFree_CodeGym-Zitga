using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using KartGame.KartSystems;

[RequireComponent(typeof(Rigidbody))]
public class MyPlayer : MonoBehaviour
{
    public Rigidbody carRigidbody;

    public static MyPlayer instance;
    public UnityEvent<float> updateKmh;

    private float kmh;
    private Vector3 tempPositionCar;

    public AudioSource collectionsItem;

    [Header("Kiem tra IsGround")]
    private bool grounded;



    //Cập nhật tốc độ
    public ArcadeKart KartController;
    public bool AutoFindKart = true;
    void Start()
    {

        //kiem tra ArcadeKart đa
        instance = this;
        gameObject.GetComponent<Rigidbody>();


        //Kiem tra ArcadeKart đã có trên scene chưa
        if (AutoFindKart)
        {
            ArcadeKart kart = FindObjectOfType<ArcadeKart>();
            KartController = kart;
        }

        if (!KartController)
        {
           // gameObject.SetActive(false);
        }

    }


    
    private void FixedUpdate()
    {


        //Cập nhật tốc độ.
        float speed = KartController.Rigidbody.velocity.magnitude;

        //Speed.text = string.Format($"{Mathf.FloorToInt(speed * 3.6f)} km/h");
        var tempVelocity = Mathf.FloorToInt(speed * 3.6f);
        UpdateKmh(tempVelocity);





        

        
       

    }

    // Update is called once per frame
    void UpdateKmh(float _kmh)
    {

        updateKmh?.Invoke(_kmh);

    }

    ///Play audio khi thu thap items
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            tempPositionCar = other.transform.position;
            //Debug.Log($"Lay vi tri item: {tempPositionCar}");
            collectionsItem.Play();

        }

        if (other.gameObject.CompareTag("Boundary"))
        {
            // Đưa Player về Item gần nhất khi Player văng ra khỏi đường đua
            transform.position = tempPositionCar;
            ////transform.rotation = transform.rotation;
            Debug.Log("Cham vao Boundary");

        }
    }
}
