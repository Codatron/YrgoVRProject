using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using System;

public class HandContoller : MonoBehaviour
{
    public Camera head;
    public GameObject body;
    [SerializeField] private Vector3 angles;
    public ActionBasedController leftController;
    public ActionBasedController rightController;
    public Vector3 flightPath;
    public GameObject handOffset;

    [SerializeField] private BeeState beeState;
    [Tooltip("Keep me under 0.5 please.")]
    [SerializeField] private float speed;
    //[SerializeField] private float liftForce;
    //[SerializeField] private float dragForce;
    [SerializeField] private float liftDrag;
    [SerializeField] private float gravitationalDrag;
    [SerializeField] private float rotationSpeed = 45.0f;


    [SerializeField] private bool isFalling;
    private Vector3 targetForward;
    private Rigidbody rb;
    private float yDelta;

    Vector3 currentEulerAngles;
    Quaternion currentRotation;
    Vector3 direction;

    private void Awake()
    {
        rb = body.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //beeState = BeeState.NotFlying;
        //body.transform.localRotation = GetHeadRotation();

    }

    private void FixedUpdate()
    {
        Vector3 rightControllerPosition = GetRightControllerPosition();
        Vector3 leftControllerPosition = GetLeftControllerPosition();
        Vector3 centerVector = handOffset.transform.localPosition -(rightControllerPosition + leftControllerPosition);
        Debug.Log("Vector: " + centerVector.y);

        // OBS!!!
        // HandOffset and 0.5f on y-axis!!!
        centerVector.Normalize();
        Quaternion newRotation = Quaternion.Euler(new Vector3(centerVector.y, -centerVector.x, 0.0f) * 360);
        rb.rotation = newRotation;

        //Debug.Log("Rotation: " + newRotation);

        //if (GetTriggerButton() > 0.1f)
        //{
        //    beeState = BeeState.Flying;

        //    if (GetRightThumbAxisValue().y > 0.1f)
        //    {
        //        speed += GetRightThumbAxisValue().y * 0.02f;
        //    }
        //    {
        //    else if (GetRightThumbAxisValue().y < -0.1f)
        //        speed += GetRightThumbAxisValue().y * 0.02f;
        //    }
        //}
        //else
        //{
        //    beeState = BeeState.NotFlying;
        //    rb.rotation = GetHeadRotation();
        //}

        // Check Altitude and BeeState
        //if (GetRightTrigger() > 0.1f)
        //{
        //    //beeState = BeeState.Flying;
        //    IncreaseAltitude();
        //}
        //else if (GetLeftTrigger() > 0.1f)
        //{
        //    //beeState = BeeState.Flying;
        //    DecreaseAltitude();
        //}
        //else if (GetRightTrigger() <= 0.1f && GetLeftTrigger() <= 0.1f)
        //{
        //    //beeState = BeeState.Hovering;
        //}

        //ChangeFlightPathWithControllerPosition();
        //Fly();

        // YESTERDAY 13/09/2022
        //Vector3 handOriginPoint = handOffset.transform.localPosition;
        //Vector3 rightControllerPosition = GetRightControllerPosition();
        //Vector3 leftControllerPosition = GetLeftControllerPosition();

        //Vector3 newVector = rightControllerPosition + leftControllerPosition;
        //direction = newVector - handOriginPoint;
        ////Vector3 readOffset = leftControllerPosition - handOriginPoint;
        ////Vector3 readOffsetright = rightControllerPosition - handOriginPoint;

        ////Vector3 realOffset = readOffset - readOffsetright;
        ////realOffset.y = 0.0f;
        ////direction.y = 0.0f;

        //if (direction.sqrMagnitude > 0.05f)
        //{
        //    //rb.AddForce(direction * 60.0f * Time.deltaTime, ForceMode.VelocityChange);
        //    rb.velocity = /*body.transform.localRotation * */direction.normalized * 60.0f * Time.deltaTime;
        //}

        // Check forward/backward flight path
        //if (beeState == BeeState.Flying)
        //{

        //    //ChangeFlightPathWithController();
        //}

        //body.transform.localRotation = GetHeadRotation();

        //Quaternion angle = Quaternion.Euler(readOffset);
        //body.transform.localRotation = angle;







        ////modifying the Vector3, based on input multiplied by speed and time
        //currentEulerAngles += new Vector3(position.x, position.y, position.z) * Time.deltaTime * rotationSpeed;

        ////moving the value of the Vector3 into Quanternion.eulerAngle format
        //currentRotation.eulerAngles = currentEulerAngles;

        ////apply the Quaternion.eulerAngles change to the gameObject
        //body.transform.localRotation = currentRotation;

        //var localRotation = body.transform.localRotation;
        //localRotation *= Quaternion.Euler(0.0f, 0.0f, currentEulerAngles.z);
        //localRotation *= Quaternion.Euler(currentEulerAngles.x, 0.0f, 0.0f);
        //localRotation = Quaternion.Euler(-currentEulerAngles.y, 0.0f, 0.0f);
        //localRotation = Quaternion.Euler(-currentEulerAngles);

        //body.transform.localRotation = localRotation;
        //rb.velocity = body.transform.localRotation *  body.transform.forward * (speed * Time.fixedDeltaTime);


        // Changes camera view to match facing direction --- BAAAAAAD!!!!
        //if (GetRightGrip() > 0.1f && beeState == BeeState.Flying)
        //{
        //    Debug.Log(GetRightGrip());
        //    body.transform.localRotation = GetHeadRotation();
        //    Vector3 newFlightPath = GetHeadRotation() * body.transform.forward.normalized * speed * GetRightThumbAxis().y;
        //    rb.AddForce(newFlightPath, ForceMode.VelocityChange);
        //}
    }

    private void ChangeFlightPathWithController()
    {
        body.transform.localRotation = GetRightControllerRotation();
        targetForward = GetRightControllerRotation() * body.transform.forward;
        body.transform.localPosition += targetForward * speed * Time.deltaTime;

        Debug.Log(GetRightControllerRotation());
    }

    private void ChangeFlightPathWithControllerPosition()
    {
        Vector3 controllerPosition = GetRightControllerPosition();
        //Quaternion newRotation = Quaternion.LookRotation(controllerPosition, Vector3.up);
        body.transform.localEulerAngles = controllerPosition;

        Debug.Log("Controller Vector: " + GetRightControllerPosition() + "  " + "Quaternion: " + body.transform.localEulerAngles);
    }

    private void ChangeFlightPathWithHeadset()
    {
        body.transform.localRotation = GetHeadRotation();
        targetForward = GetHeadRotation() * body.transform.forward;
        body.transform.localPosition += targetForward * speed * Time.deltaTime;
    }

    private void FlyWithController()
    {
        body.transform.localRotation = GetRightControllerRotation();
        Vector3 forwardFlightPath = GetRightControllerRotation() * body.transform.forward;
        body.transform.localPosition += forwardFlightPath * speed * Time.deltaTime;
    }

    private void Fly()
    {
        //rb.velocity = Camera.main.transform.forward.normalized * speed;
        //rb.velocity = GetHeadRotation() * body.transform.forward * speed * inputValue;
        //rb.MovePosition(body.transform.localPosition + (GetHeadRotation() * body.transform.forward * speed));
        //flightPath = rb.velocity;

        //body.transform.localRotation = GetHeadRotation();
        //body.transform.localRotation = rb.rotation;


        //body.transform.localRotation = GetHeadRotation();
        //Vector3 input = GetLeftThumbAxis();
        //Quaternion newRotation = new Quaternion(input.x, input.y, 0.0f, 1.0f);
        //body.transform.localRotation = new Quaternion(input.x, input.y, input.z, 1.0f);
        //targetForward = newRotation * body.transform.forward;
        //body.transform.localPosition += targetForward * speed * Time.deltaTime;

        // FLight with headset as rotation
        //Vector3 newFlightPath = GetHeadRotation() * body.transform.forward.normalized * speed * GetRightThumbAxis().y;
        //rb.AddForce(newFlightPath, ForceMode.VelocityChange);

        // Flight with controller as rotation
        Vector3 newFlightPath = GetHeadRotation() * body.transform.forward.normalized * speed * GetRightThumbAxis().y;
        rb.AddForce(newFlightPath, ForceMode.VelocityChange);

        // This is now in IncreaseAltitude()
        //rb.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
    }

    private void IncreaseAltitude()
    {
        rb.drag = liftDrag;
        float thrust = Mathf.Clamp(GetRightTrigger(), 0.1f, 0.35f);
        rb.AddForce(direction + Vector3.up * thrust, ForceMode.Impulse);
    }

    private void DecreaseAltitude()
    {
        rb.drag = gravitationalDrag;
        float thrust = Mathf.Clamp(GetRightTrigger(), 0.1f, 0.35f);
        rb.AddForce(Vector3.down * thrust, ForceMode.Impulse);
    }

    private void GetAngles()
    {
        angles.x = body.transform.eulerAngles.x;
        angles.y = body.transform.eulerAngles.y;
        angles.z = body.transform.eulerAngles.z;
    }

    private Quaternion GetHeadRotation() => head.transform.localRotation;

    private float GetRightTrigger() => rightController.activateAction.action.ReadValue<float>();

    private float GetLeftTrigger() => leftController.activateAction.action.ReadValue<float>();

    private float GetRightGrip() => rightController.selectAction.action.ReadValue<float>();

    private float GetLeftGrip() => leftController.selectAction.action.ReadValue<float>();

    // X: Pitch, Y: 
    private Vector2 GetRightThumbAxis() => rightController.translateAnchorAction.action.ReadValue<Vector2>();

    private Vector2 GetLeftThumbAxis() => leftController.rotateAnchorAction.action.ReadValue<Vector2>();

    private Quaternion GetRightControllerRotation() => rightController.rotationAction.action.ReadValue<Quaternion>();

    private Quaternion GetLeftControllerRotation() => leftController.rotationAction.action.ReadValue<Quaternion>();

    private Vector3 GetRightControllerPosition() => rightController.positionAction.action.ReadValue<Vector3>();

    private Vector3 GetLeftControllerPosition() => leftController.positionAction.action.ReadValue<Vector3>();
}