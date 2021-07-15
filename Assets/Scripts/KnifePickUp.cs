using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUp : MonoBehaviour
{
    public GameObject knifeHolderRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chef"))
        {
            if (!knifeHolderRef.GetComponent<KnifeThrow>().checkKnife)
            {
                knifeHolderRef.GetComponent<KnifeThrow>().checkKnife = true;
                Destroy(this.gameObject);
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;
            }
        }
    }
}
