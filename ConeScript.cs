using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeScript : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + -2f * Time.deltaTime);
    }
}
