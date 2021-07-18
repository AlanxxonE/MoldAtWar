using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopUp : MonoBehaviour
{
    private GameObject chefRef;
    private Vector3 originalPopUpTransform;

    // Start is called before the first frame update
    void Start()
    {
        chefRef = GameObject.FindGameObjectWithTag("Chef");
        originalPopUpTransform = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, chefRef.transform.position) < 10)
        {
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
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * 5.0f);
        }
        else
        {
            this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, new Vector3(this.transform.eulerAngles.x, originalPopUpTransform.y, this.transform.eulerAngles.z), Time.deltaTime * 5.0f);
        }
    }
}
