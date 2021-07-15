using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyPotatoBehaviour : MonoBehaviour
{
    public GameObject pickUpKnifeRef;
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
            Vector3 potatoDirection = new Vector3((randomPotatoMovement.x - this.transform.position.x), 0, (randomPotatoMovement.z - this.transform.position.z));

            Vector3 newPotatoRot = Vector3.RotateTowards(this.transform.forward, potatoDirection,Time.deltaTime * potatoSpeed, 0.0f);

            this.transform.rotation = Quaternion.LookRotation(newPotatoRot);

            this.transform.position = new Vector3(Vector3.Lerp(this.transform.position, randomPotatoMovement, Time.deltaTime * potatoSpeed).x, this.transform.position.y, Vector3.Lerp(this.transform.position, randomPotatoMovement, Time.deltaTime * potatoSpeed).z);
        }
        else
        {
            this.transform.position = new Vector3(Vector3.Lerp(this.transform.position, chefRef.transform.position, Time.deltaTime * potatoSpeed).x, this.transform.position.y, Vector3.Lerp(this.transform.position, chefRef.transform.position, Time.deltaTime * potatoSpeed).z);
            this.transform.LookAt(chefRef.transform.position);
        }
    }

    IEnumerator MovePotato()
    {
        randomPotatoMovement = new Vector3(this.transform.position.x + (Random.insideUnitSphere.x * potatoSpeed), 0, this.transform.position.z + (Random.insideUnitSphere.z * potatoSpeed));
        yield return new WaitForSeconds(1f);
        StartCoroutine(MovePotato());
    }

    public void SmashedPotato()
    {
        GameObject pickUpKnifeClone = Instantiate(pickUpKnifeRef);
        pickUpKnifeClone.transform.position = this.transform.position;
        pickUpKnifeClone.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;
        Destroy(this.gameObject);
    }
}
