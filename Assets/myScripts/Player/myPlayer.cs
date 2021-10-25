using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myPlayer : MonoBehaviour
{

    private float inputVerticel;
    private float inputHorizontal;

    public Rigidbody carRigidbody;
    //public float speed;
    private float moveDistance;

    private float angle;
    public float maxSteerAngle = 30;
    public float motorForce = 2000;

    public GameObject smokeLeft;
    public GameObject smokeRight;


    [Header("Wheel Collider")]
    public WheelCollider wheelForntLetf;
    public WheelCollider wheelForntRight;
    public WheelCollider wheelRearLetf;
    public WheelCollider wheelRearRight;

    [Header("Wheel Transform")]
    public Transform transformForntLetf;
    public Transform transformForntRight;
    public Transform transformRearLetf;
    public Transform transformRearRight;


    public Transform centerOfMass;

    private void Start()
    {
       // carRigidbody.GetComponent<Rigidbody>();
       // Debug.Log("test.....!");
    }

    #region ----Steer----


    #region ----Move by AddForce---
    private void CarMove()
    {
        var lastAngle = Vector3.up * maxSteerAngle;
        moveDistance = inputVerticel * motorForce;
        carRigidbody.AddForce(transform.forward * moveDistance);
        carRigidbody.AddTorque(lastAngle);
    }
    #endregion
    private void Steer()
    {
        //Goc quay cua banh xe toi da 30 do
        angle = inputHorizontal * maxSteerAngle*0.5f;

        wheelForntLetf.steerAngle = angle;
        wheelForntRight.steerAngle = angle;

        //wheelRearLetf.steerAngle = angle;
        //wheelRearRight.steerAngle = angle;
    }
    #endregion
    #region ----Accelerate----
    private void Accelerate()
    {
        //Them mot luc momen xoan vao banh xe
        wheelForntLetf.motorTorque = inputVerticel * motorForce;
        wheelForntRight.motorTorque = inputVerticel * motorForce;

        wheelRearLetf.motorTorque = inputVerticel * motorForce;
        wheelRearRight.motorTorque = inputVerticel * motorForce;
    }
    #endregion

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelForntLetf, transformForntLetf);
        UpdateWheelPose(wheelForntRight, transformForntRight);
        UpdateWheelPose(wheelRearLetf, transformRearLetf);
        UpdateWheelPose(wheelRearRight, transformRearRight);
    }


    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;

        //transform.position = _pos;
       // transform.rotation = _quat;
    }

    #region ----Input----
    public void GetInput()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVerticel = Input.GetAxis("Vertical");
    }
    #endregion


    private void FixedUpdate()
    {
        GetInput();
        //CarMove();
        Steer();
        Accelerate();
        //UpdateWheelPoses();
        //Update center of mass


        carRigidbody.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);

        float curentSpeed = carRigidbody.velocity.magnitude;
        //GameManager.Instance.UpdateSpeed(curentSpeed);

        
        /*
        //Update center of mass
        //carRigidbody.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);

        //Code thay day
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var angle = horizontalInput * Vector3.up;
        var lastAngle = angle * turnSpeed;

        //Move to base Input
        moveDistance = verticalInput * speed;
        //Debug.Log("Move distance: "+moveDistance);
        //Angel Rotation
        carRigidbody.AddTorque(lastAngle);
        carRigidbody.AddRelativeForce(transform.forward * moveDistance);
        //carRigidbody.AddForce(transform.forward * moveDistance);




        float curentSpeed = carRigidbody.velocity.magnitude;
        GameManager.Instance.UpdateSpeed(curentSpeed);

        */
        //Debug.Log(carRigidbody.centerOfMass);


        //var angle = horizontalInput * Vector3.up;
        //var lastAngle = angle * turnSpeed;

        //carRigidbody.MoveRotation(angle);
        //var _velocyti = Vector3.forward * speed * verticalInput;
        //Code tu hoc
        /*
        Vector3 angleVelocity = new Vector3(transform.rotation.x, horizontalInput * turnSpeed, transform.rotation.z);
        Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.deltaTime);

        carRigidbody.MoveRotation(carRigidbody.rotation * deltaRotation);
        carRigidbody.velocity = _velocyti;
        */
        

    }


}
