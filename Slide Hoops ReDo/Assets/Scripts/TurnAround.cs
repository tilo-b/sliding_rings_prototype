using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public float rotSpeed = 1f;
    public GameObject rotateThis;
    private Rigidbody rb;
    private bool dragging = false;
    public GameObject winText;
    public int ringsToGet = 3;
    public int ringsInGoal = 0;

    private void Start()
    {
        rb = rotateThis.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(3f, 0f, -1.5f);
    }

    private void OnMouseDrag()
    {
        dragging = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX |
                             RigidbodyConstraints.FreezePositionY |
                             RigidbodyConstraints.FreezePositionZ |
                             RigidbodyConstraints.FreezeRotationX |
                             RigidbodyConstraints.FreezeRotationY |
                             RigidbodyConstraints.FreezeRotationZ;
            dragging = false;
        }
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX |
                             RigidbodyConstraints.FreezePositionY |
                             RigidbodyConstraints.FreezePositionZ |
                             RigidbodyConstraints.FreezeRotationX |
                             RigidbodyConstraints.FreezeRotationZ;
            float xRotation = Input.GetAxis("Mouse X") * rotSpeed;
            Vector3 rotation = new Vector3(0, -xRotation, 0);
            rb.AddRelativeTorque(rotation, ForceMode.Impulse);
        }
    }

    public void RingCollected()
    {
        ringsInGoal++;
        if (ringsInGoal >= ringsToGet)
        {
            WeDidIt();
        }
    }

    public void WeDidIt()
    {
        winText.SetActive(true);
    }
}
