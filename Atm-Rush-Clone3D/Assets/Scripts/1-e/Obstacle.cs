using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            if (CollectList.instance.inventory.Count-1 == CollectList.instance.inventory.IndexOf(other.gameObject)) //listenin son eleman� ise
            {
                CollectList.instance.inventory.Remove(other.gameObject);
                Destroy(other.gameObject);
                CollectList.instance.ScoreUpdate();
            }

            else
            {
                int crashObjIndex = CollectList.instance.inventory.IndexOf(other.gameObject);
                int lastIndex = CollectList.instance.inventory.Count - 1;

                for (int i = crashObjIndex; i <= lastIndex; i++)
                {
                    RemoveList(CollectList.instance.inventory[crashObjIndex]);
                    CollectList.instance.ScoreUpdate();
                }
            }
        }

        else if (other.CompareTag("Character"))
        {
            StartCoroutine(Crash());
            other.transform.DOMove(other.transform.position - new Vector3(0, 0,2), 1).SetEase(Ease.OutBounce);
        }
    }

    IEnumerator Crash()
    {
        Forward.insance.speed = 0;
        yield return new WaitForSeconds(1.5f);
        Forward.insance.speed = 10;
    }

    public void RemoveList(GameObject crashObj)
    {
        CollectList.instance.inventory.Remove(crashObj);
        crashObj.tag = "Money";
        crashObj.GetComponent<BoxCollider>().isTrigger = true;
        crashObj.GetComponent<Collect>().enabled = false;

        GameObject bounceMoney = Instantiate(crashObj,RandomPos(transform),Quaternion.identity);
        Destroy(bounceMoney.GetComponent<Rigidbody>());
        bounceMoney.transform.DOMove(bounceMoney.transform.position - new Vector3(0, 2, 0), 1).SetEase(Ease.OutBounce);
        Destroy(crashObj);      
    }

    public Vector3 RandomPos(Transform obstacle)
    {
        float x = Random.Range(-4, 4);
        float z = Random.Range(10, 20);
        Vector3 posisiton = new Vector3(x, 3, obstacle.position.z + z);
        return posisiton;
    }
}
