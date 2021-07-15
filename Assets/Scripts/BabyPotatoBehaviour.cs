using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyPotatoBehaviour : MonoBehaviour
{
    private GameObject chefRef;
    private Vector3 randomPotatoMovement;
    private float potatoSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        chefRef = GameObject.FindGameObjectWithTag("Chef");
        StartCoroutine(MovePotato());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, chefRef.transform.position) > 5)
        {
            this.transform.position = new Vector3(Vector3.Lerp(this.transform.position, randomPotatoMovement, Time.deltaTime * potatoSpeed).x, this.transform.position.y, Vector3.Lerp(this.transform.position, randomPotatoMovement, Time.deltaTime * potatoSpeed).z);
        }
        else
        {
            this.transform.position = new Vector3(Vector3.Lerp(this.transform.position, chefRef.transform.position, Time.deltaTime * potatoSpeed).x, this.transform.position.y, Vector3.Lerp(this.transform.position, chefRef.transform.position, Time.deltaTime * potatoSpeed).z);
        }
    }

    IEnumerator MovePotato()
    {
        randomPotatoMovement = new Vector3(this.transform.position.x + (Random.insideUnitSphere.x * potatoSpeed), 0, this.transform.position.z + (Random.insideUnitSphere.z * potatoSpeed));
        yield return new WaitForSeconds(1f);
        StartCoroutine(MovePotato());
    }
}
