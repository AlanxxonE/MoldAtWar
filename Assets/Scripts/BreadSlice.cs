using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSlice : MonoBehaviour
{
    private float destroyCD;
    public GameObject breadCrumbsParticleRef;

    //private bool checkChef = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject breadParticleClone = Instantiate(breadCrumbsParticleRef);
        breadParticleClone.transform.position = this.transform.position;
        breadParticleClone.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        destroyCD += Time.deltaTime;

        //if(destroyCD > 5.0f && checkChef == false)
        //{
        //    SelfDestruct();
        //}

        if (destroyCD > 5.0f)
        {
            SelfDestruct();
        }
    }

    void SelfDestruct()
    {
        GameObject.Find("BreadLoaf").GetComponent<ChefBread>().SetSliceCounter(0);
        GameManager gmRef = GameObject.Find("BreadLoaf").GetComponent<ChefBread>().gMRef;
        Color temp = gmRef.breadImageRef.color;
        temp.a = 255;
        gmRef.breadImageRef.color = temp;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("ChefFeet"))
        //{
        //    checkChef = true;
        //}
    }
}
