using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HandMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandMove()
    {
        Debug.Log("Girmiş mi");
        transform.DOMoveX(transform.position.x - 5.4f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);  
    }
    
}
