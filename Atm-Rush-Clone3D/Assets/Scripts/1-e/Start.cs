using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public Animator playerAnim;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("Girdi mi ");
            GameManager.insance.isGameStart = true;
            playerAnim.SetTrigger("Run");
            gameObject.SetActive(false);
        }
    }
}
