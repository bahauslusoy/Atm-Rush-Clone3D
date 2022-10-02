using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GiotinMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GuillotineMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GuillotineMove()
    {
       transform.DORotate(new Vector3(0, 0, -90), 2, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
