using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUp : MonoBehaviour
{
    public AudioManager audioManagerRef;
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
                audioManagerRef.audioList[5].Play();
                knifeHolderRef.GetComponent<KnifeThrow>().checkKnife = true;
                Destroy(this.gameObject);
            }
            else
            {
                audioManagerRef.audioList[7].Play();
                GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;
            }
        }
    }
}
