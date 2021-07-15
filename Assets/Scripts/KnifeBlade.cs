using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBlade : MonoBehaviour
{
    public GameObject knifeShutterParticleRef;

    //private Rigidbody knifeRb;

    // Start is called before the first frame update
    void Start()
    {
        //knifeRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 200), Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject knifeParticleClone = Instantiate(knifeShutterParticleRef);
        knifeParticleClone.transform.position = this.transform.position;
        knifeParticleClone.GetComponent<ParticleSystemBehaviour>().checkDestruct = true;
        Destroy(this.gameObject);
    }
}
