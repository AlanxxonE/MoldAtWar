using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBlade : MonoBehaviour
{
    //private Rigidbody knifeRb;

    // Start is called before the first frame update
    void Start()
    {
        //knifeRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(Time.deltaTime * 200, 0, 0), Space.Self);
    }
}
