using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController : MonoBehaviour
{

    enum State
    {
        preGame,

        inGame,

        finishGame,

        failGame,

    }
    private State _currentState = State.preGame;
    HandMover handMover;    
    public Animator playerAnim;
    private Vector3 firstTouchPosition;
    private Vector3 curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f;
    private float finalTouchX;
    private float xBound = 4f;
    private bool canMove = true;
    
    [SerializeField] private GameObject StartPanel;

    private void Awake()
    {
        playerAnim.GetComponent<Animator>();
        StartPanel.SetActive(true);
        Time.timeScale = 0;
        
    }

    void Update()
    {
        switch (_currentState)
        {
            case State.preGame:
                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 1;

                    StartPanel.SetActive(false);

                    _currentState = State.inGame;

                }

                break;
            case State.inGame:
                Move();
                
                playerAnim.SetTrigger("Run");
                



                break;

        }


    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;

            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);

            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);

            firstTouchPosition = Input.mousePosition;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conveyor"))
        {
           // anim.SetTrigger("Idle");
            canMove = false;
            Forward.insance.speed = 0;
        }
    }
}
