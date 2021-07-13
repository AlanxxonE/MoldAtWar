using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefGround : MonoBehaviour
{
    private bool isGrounded;

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Bread"))
        {
            isGrounded = true;
        }
    }
}
