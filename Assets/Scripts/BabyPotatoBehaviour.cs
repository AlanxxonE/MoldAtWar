using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyPotatoBehaviour : MonoBehaviour
{
    public GameObject pickUpKnifeRef;
    private GameObject chefRef;
    private Vector3 randomPotatoMovement;
    private float potatoSpeed = 2.0f;
    private int amountOfKnives = 0;

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
            var lookPos = chefRef.transform.position - this.transform.position;
            if (this.transform.eulerAngles.y < 90)
            {
                lookPos.y = 0.1f;
            }
            else
            {
                lookPos.y = 0.0f;
            }
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * potatoSpeed * 2.0f);
        }
    }

    IEnumerator MovePotato()
    {
        int randomDistanceX = Random.Range(-10, 11);
        int randomDistanceZ = Random.Range(-10, 11);
        randomPotatoMovement = Vector3.Lerp(this.transform.position,new Vector3(this.transform.position.x + (randomDistanceX * 10), 0,this.transform.position.z + (randomDistanceZ * 10)), Time.deltaTime * potatoSpeed);
        yield return new WaitForSeconds(1f);
        StartCoroutine(MovePotato());
    }

    public void SmashedPotato()
    {
        amountOfKnives = 0;
        amountOfKnives++;

        if (amountOfKnives <= 1)
        {
            GameObject pickUpKnifeClone = Instantiate(pickUpKnifeRef);
            pickUpKnifeClone.transform.position = this.transform.position;
            pickUpKnifeClone.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * 10;
        }
        Destroy(this.gameObject);
    }
}
