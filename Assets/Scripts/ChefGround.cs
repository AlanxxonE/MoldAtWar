using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefGround : MonoBehaviour
{
    private bool isGrounded;
    private bool wasOnBread = false;
    private Rigidbody chefRb;
    private ChefMovement chefMov;

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public bool GetWasOnBread()
    {
        return wasOnBread;
    }

    // Start is called before the first frame update
    void Start()
    {
        chefRb = this.transform.parent.GetComponent<Rigidbody>();
        chefMov = this.transform.parent.GetComponent<ChefMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;

        if(other.CompareTag("Bread"))
        {
            GameObject.Find("BreadLoaf").GetComponent<ChefBread>().SetSliceCounter(0);
            GameManager gmRef = GameObject.Find("BreadLoaf").GetComponent<ChefBread>().gMRef;
            gmRef.SetBreadAplha(1.0f);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Bread"))
        {
            wasOnBread = true;
        }
        else
        {
            wasOnBread = false;
        }

        if (other.CompareTag("Ground") || other.CompareTag("Bread") || other.CompareTag("Tomato") || other.CompareTag("BabyPotato"))
        {
            if(chefMov.GetCompenetrateCheck())
            {
                chefMov.SetCompenetrateCheck(false);
            }
            isGrounded = true;
        }
        else if(!other.CompareTag("BabyPotato"))
        {
            if (!chefMov.GetCompenetrateCheck())
            {
                chefMov.SetCompenetrateCheck(true);
            }
            chefRb.AddForce(-this.transform.parent.forward / 2, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != null)
        {
            if (other.CompareTag("BabyPotato") && wasOnBread)
            {
                other.GetComponent<BabyPotatoBehaviour>().SmashedPotato();
            }
        }

        if(other.CompareTag("SpawnTrigger"))
        {
            this.transform.parent.position = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().spawnPoint.position;
        }
    }
}
