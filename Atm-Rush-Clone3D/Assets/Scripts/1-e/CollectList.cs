using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CollectList : MonoBehaviour
{
    public static CollectList instance;

    public List<GameObject> inventory = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public Transform player;
    [HideInInspector] public int score;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Follow();
    }

    public void Stack(GameObject obj, int index)
    {
        obj.transform.parent = player;
        Vector3 newPos = inventory[index].transform.localPosition;

        if (inventory[index].CompareTag("Character"))
        {
            newPos += new Vector3(0, 0.5f, 2);
        }
        else
        {
            newPos.z += 1;
        }       
        
        obj.transform.localPosition = newPos;
        inventory.Add(obj);
        StartCoroutine(CubeScale());
        ScoreUpdate();
    }

    public void Follow()
    {
        for (int i = 1; i < inventory.Count; i++)
        {
            if (inventory[i].transform.localPosition != null)
            {
                Vector3 pos = inventory[i].transform.localPosition;
                pos.x = inventory[i - 1].transform.localPosition.x;
                inventory[i].transform.DOLocalMove(pos, 0.1f);
            }
        }
    }

    public IEnumerator CubeScale()
    {
        for (int i = inventory.Count - 1; i >= 1; i--)
        {
            int index = i; 
            Vector3 scale = Vector3.one * 1.5f;
            inventory[index].transform.DOScale(scale, 0.1f).OnComplete(() => inventory[index].transform.DOScale(Vector3.one, 0.1f));
            yield return new WaitForSeconds(0.03f);
        }
    }

    public void ScoreUpdate()
    {
        score = 0;
        for (int i = 1; i < inventory.Count; i++)
        {
            score += inventory[i].GetComponent<Money>().value;
        }

        scoreText.text = score.ToString();
    }
}
