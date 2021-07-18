using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefBread : MonoBehaviour
{
    public GameManager gMRef;
    private GameObject breadSliceRef;
    private GameObject slicePreview;
    private GameObject sliceBackUp;
    private int sliceCounter = 0;

    public int GetSliceCounter()
    {
        return sliceCounter;
    }

    public void SetSliceCounter(int n)
    {
        sliceCounter = n;
    }

    // Start is called before the first frame update
    void Start()
    {
        breadSliceRef = GameObject.FindGameObjectWithTag("Bread");
        GameObject.FindGameObjectWithTag("Bread").SetActive(false);
        slicePreview = GameObject.FindGameObjectWithTag("SlicePreview");
        GameObject.FindGameObjectWithTag("SlicePreview").SetActive(false);
        sliceBackUp = GameObject.FindGameObjectWithTag("SliceBackUp");
        GameObject.FindGameObjectWithTag("SliceBackUp").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("LeftHand"))
        {
            if (slicePreview.GetComponent<SlicePreview>().GetCheckSlicePreview() == true)
            {
                slicePreview.GetComponent<SlicePreview>().SetCheckSlicePreview(false);
            }

            slicePreview.GetComponent<MeshRenderer>().material = slicePreview.GetComponent<SlicePreview>().niceRef;
        }

        if (Input.GetButtonDown("Feet"))
        {
            if (sliceBackUp.GetComponent<SlicePreview>().GetCheckSlicePreview() == true)
            {
                sliceBackUp.GetComponent<SlicePreview>().SetCheckSlicePreview(false);
            }

            sliceBackUp.GetComponent<MeshRenderer>().material = sliceBackUp.GetComponent<SlicePreview>().niceRef;
        }

        if (Input.GetButtonUp("Feet") && sliceCounter == 0 && !sliceBackUp.GetComponent<SlicePreview>().GetCheckSlicePreview())
        {
            gMRef.audioManagerRef.audioList[4].Play();
            GetComponentInParent<ChefMovement>().chefAnimator.SetTrigger("PlaceBread");
            sliceCounter = 1;
            gMRef.SetBreadAplha(0.5f);
            GameObject breadClone = Instantiate(breadSliceRef);
            breadClone.transform.position = sliceBackUp.transform.position;
            breadClone.transform.eulerAngles = sliceBackUp.transform.eulerAngles;
            breadClone.SetActive(true);
        }

        if (Input.GetButton("LeftHand") && Input.GetButtonUp("Jump") && sliceCounter == 0 && !slicePreview.GetComponent<SlicePreview>().GetCheckSlicePreview())
        {
            gMRef.audioManagerRef.audioList[4].Play();
            GetComponentInParent<ChefMovement>().chefAnimator.SetTrigger("PlaceBread");
            sliceCounter = 1;
            gMRef.SetBreadAplha(0.5f);
            GameObject breadClone = Instantiate(breadSliceRef);
            breadClone.transform.position = slicePreview.transform.position;
            breadClone.transform.eulerAngles = slicePreview.transform.eulerAngles;
            breadClone.SetActive(true);
        }
    }


}
