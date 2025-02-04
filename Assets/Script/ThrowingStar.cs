using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStar : MonoBehaviour
{
    public float rotationSpeed = 300f; // Rotation speed

    void Update()
    {
        // Rotate the throwing star in place
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
    }
}
