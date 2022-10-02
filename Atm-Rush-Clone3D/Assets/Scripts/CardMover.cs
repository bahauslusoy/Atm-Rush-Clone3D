using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CardMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CardMove()
    {
        transform.DOMoveX(transform.position.x - 11.7f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);  
    }
}
