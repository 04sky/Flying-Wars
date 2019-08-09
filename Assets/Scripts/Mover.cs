using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        //赋予往前的速度
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
