using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    private void Start()
    {       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            if (!CollectList.instance.inventory.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false; 
                other.gameObject.tag = "Collected";
                other.gameObject.GetComponent<Collect>().enabled = true;
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true; 

                CollectList.instance.Stack(other.gameObject, CollectList.instance.inventory.Count - 1);
            }
        }
    }
}

