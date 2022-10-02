using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinObs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      WallMove();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WallMove()
    {
        transform.DORotate(new Vector3(0, 3600, 0), 20, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
