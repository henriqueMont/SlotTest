using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reel : MonoBehaviour
{

    private int randomValue;
    private float timeInterval;

    public bool reelStopped;
    //public string stoppedSlot;
    public string stoppedSlotL1;
    public string stoppedSlotL2;
    public string stoppedSlotL3;

    // Start is called before the first frame update
    void Start()
    {
        reelStopped = true;
        _gameController.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlotL1 = "";
        stoppedSlotL2 = "";
        stoppedSlotL3 = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        reelStopped = false;
        timeInterval = 0.025f;

        //movimento da reel, para iniciar e parar.
        for (int i = 0; i < 30; i++)
        {
            if(transform.position.y <= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            yield return new WaitForSeconds(timeInterval);
        }

        //Seta o valor que ira para o slot.
        randomValue = Random.Range(60, 100);
        switch (randomValue % 3)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        //movimento de aceleracao e desaceleracao
        for(int i=0; i< randomValue; i++)
        {
            if(transform.position.y <= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if(i>Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.05f;
            if(i>Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if(i>Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if(i>Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }


        switch (transform.position.y)
        {
            case -3.5f:
                stoppedSlotL2 = "Diamond";//
                stoppedSlotL1 = "Lemon";
                stoppedSlotL3 = "Crown";
                break;
            case -2.75f:
                stoppedSlotL2 = "Crown";//
                stoppedSlotL1 = "Melon";
                stoppedSlotL3 = "Diamond";
                break;
            case -2f:
                stoppedSlotL2 = "Melon";//
                stoppedSlotL1 = "Crown";
                stoppedSlotL3 = "Bar";
                break;
            case -1.25f:
                stoppedSlotL2 = "Bar";//
                stoppedSlotL1 = "Melon";
                stoppedSlotL3 = "Seven";
                break;
            case -0.5f:
                stoppedSlotL2 = "Seven";//
                stoppedSlotL1 = "Bar";
                stoppedSlotL3 = "Cherry";
                break;
            case 0.25f:
                stoppedSlotL2 = "Cherry";//
                stoppedSlotL1 = "Seven";
                stoppedSlotL3 = "Lemon";
                break;
            case 1f:
                stoppedSlotL2 = "Lemon";//
                stoppedSlotL1 = "Cherry";
                stoppedSlotL3 = "Diamond";
                break;
            case 1.75f:
                stoppedSlotL2 = "Diamond";
                stoppedSlotL1 = "Melon";
                stoppedSlotL3 = "Diamond";
                break;
        }

        reelStopped = true;
    }

    private void OnDestroy()
    {
        _gameController.HandlePulled -= StartRotating;
    }
}
