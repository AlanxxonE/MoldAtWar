using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemBehaviour : MonoBehaviour
{
    public bool checkDestruct = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<ParticleSystem>().isStopped && checkDestruct)
        {
            Destroy(this.gameObject);
        }
    }
}
