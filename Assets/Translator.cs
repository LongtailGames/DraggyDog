using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    [SerializeField] private float speed=1;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.x += speed * Time.fixedDeltaTime;
        transform.position = transformPosition;
    }
}
