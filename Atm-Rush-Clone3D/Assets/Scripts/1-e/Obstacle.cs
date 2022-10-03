using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            if (CollectList.instance.inventory.Count - 1 == CollectList.instance.inventory.IndexOf(other.gameObject)) //listenin son eleman� ise
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
                    //gameManager.DestroyEffect(gameObject.transform);
                    RemoveList(CollectList.instance.inventory[crashObjIndex]);
                    CollectList.instance.ScoreUpdate();
                }
            }
        }
        else if (other.CompareTag("Character"))
        {
            StartCoroutine(Crash());
            other.transform.DOMove(other.transform.position - new Vector3(0, 0, 2), 0.5f).SetEase(Ease.OutBounce);
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

        GameObject bounceMoney = Instantiate(crashObj, RandomPos(transform), Quaternion.identity);
        Destroy(bounceMoney.GetComponent<Rigidbody>());
        bounceMoney.transform.DOMove(bounceMoney.transform.position - new Vector3(0, 3, 0), 1).SetEase(Ease.OutBounce);
        Destroy(crashObj);
    }

    public Vector3 RandomPos(Transform obstacle)
    {
        float x = Random.Range(-1.45f, 1.45f);
        float z = Random.Range(1, 3.5f);
        Vector3 pos_ = new Vector3(x, 3, obstacle.position.z + z);
        return pos_;
    }

}
