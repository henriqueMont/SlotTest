using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class _gameController : MonoBehaviour
{
    public static event Action HandlePulled = delegate {};

    [SerializeField]
    private Text prizeText;

    [SerializeField]
    private reel[] reels;

    [SerializeField]
    private Transform handle;

    [SerializeField]
    private SpriteRenderer[] slots;

    private int prizeValue;
    private bool resultsChecked = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quando todas as reels estão em movimento, zerar resultados
        if(!reels[0].reelStopped || !reels[1].reelStopped || !reels[2].reelStopped || reels[3].reelStopped || reels[4].reelStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
            SlotColorStop();
        }

        //Quando todas as reels estão paradas, mostrar resultado
        if(reels[0].reelStopped && reels[1].reelStopped && reels[2].reelStopped && reels[3].reelStopped && reels[4].reelStopped)
        {
            CheckResults();
            prizeText.enabled =  true;
            prizeText.text = "Prize: "+prizeValue;
        }
    }

    private void OnMouseDown()
    {
        if (reels[0].reelStopped && reels[1].reelStopped && reels[2].reelStopped && reels[3].reelStopped && reels[4].reelStopped)
        {
            StartCoroutine("PullHandle");
        }
    }

    private IEnumerator PullHandle()
    {
        for (int i = 0; i<15; i+=5)
        {
            handle.Rotate(0f,0f,i);
            yield return new WaitForSeconds(0.1f);
        }

        HandlePulled();

        for (int i = 0; i<15; i+=5)
        {
            handle.Rotate(0f,0f,-i);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CheckResults()
    {
 /*        
        #MANEIRA CANSATIVA
        if(reels[0].stoppedSlot == "Diamond" &&
            reels[1].stoppedSlot == "Diamond" &&
            reels[2].stoppedSlot == "Diamond")

            prizeValue = 200;

        else if(reels[0].stoppedSlot == "Crown" &&
            reels[1].stoppedSlot == "Crown" &&
            reels[2].stoppedSlot == "Crown")

            prizeValue = 400;
        
        else if(reels[0].stoppedSlot == "Melon" &&
            reels[1].stoppedSlot == "Melon" &&
            reels[2].stoppedSlot == "Melon")

            prizeValue = 600; 
            
                    for(int i = 0; i < 5; i++)
        {

            if(reels[0].stoppedSlot == reels[i].stoppedSlot)
            {
                slotsInLine += 1;
            }
        }

        if(slotsInLine == 5)
        {
            switch(reels[0].stoppedSlot)
            {
                case "Diamond":
                    prizeValue = 100;
                    SlotColorWin();
                    break;
                case "Crown":
                    prizeValue = 200;
                    SlotColorWin();
                    break;
                case "Bar":
                    prizeValue = 300;
                    SlotColorWin();
                    break;
                case "Seven":
                    prizeValue = 400;
                    SlotColorWin();
                    break;
                case "Cherry":
                    prizeValue = 500;
                    SlotColorWin();
                    break;
                case "Lemon":
                    prizeValue = 600;
                    SlotColorWin();
                    break;
            }

            resultsChecked = true;
        }   */
        //MANEIRA MELHORADA 1


        //Verificacao 1

        //---
        if(reels[0].stoppedSlotL2 == reels[1].stoppedSlotL2 && 
            reels[0].stoppedSlotL2 == reels[2].stoppedSlotL2 &&
            reels[0].stoppedSlotL2 == reels[3].stoppedSlotL2 &&
            reels[0].stoppedSlotL2 == reels[4].stoppedSlotL2
            )
        {
            setPrizeValue(reels[0].stoppedSlotL2);
            SlotColorWin1();
            resultsChecked = true;
        }

        //-\_
        else if (reels[0].stoppedSlotL1 == reels[1].stoppedSlotL1 && 
                        reels[0].stoppedSlotL1 == reels[2].stoppedSlotL1 &&
                        reels[0].stoppedSlotL1 == reels[3].stoppedSlotL3 &&
                        reels[0].stoppedSlotL1 == reels[4].stoppedSlotL3)
        {
            setPrizeValue(reels[0].stoppedSlotL1);
            SlotColorWin2();
            resultsChecked = true;
        }
        //_/-
        else if (reels[0].stoppedSlotL3 == reels[1].stoppedSlotL3 && 
                        reels[0].stoppedSlotL3 == reels[2].stoppedSlotL3 &&
                        reels[0].stoppedSlotL3 == reels[3].stoppedSlotL1 &&
                        reels[0].stoppedSlotL3 == reels[4].stoppedSlotL1)
        {
            setPrizeValue(reels[0].stoppedSlotL3);
            SlotColorWin3();
            resultsChecked = true;
        }
        //V
         else if (reels[0].stoppedSlotL1 == reels[1].stoppedSlotL2 && 
                        reels[0].stoppedSlotL1 == reels[2].stoppedSlotL3 &&
                        reels[0].stoppedSlotL1 == reels[3].stoppedSlotL2 &&
                        reels[0].stoppedSlotL1 == reels[4].stoppedSlotL1)
        {
            setPrizeValue(reels[0].stoppedSlotL1);
            SlotColorWin4();
            resultsChecked = true;
        }




    }

    void setPrizeValue(string stoppedSlotPrize)
    {
        switch(stoppedSlotPrize)
            {
                case "Diamond":
                    prizeValue = 100;
                    
                    break;
                case "Crown":
                    prizeValue = 200;
                    break;
                case "Bar":
                    prizeValue = 300;
                    break;
                case "Seven":
                    prizeValue = 400;
                    break;
                case "Cherry":
                    prizeValue = 500;
                    break;
                case "Lemon":
                    prizeValue = 600;
                    break;
            }
    }

    void SlotColorWin1()
    {
        slots[5].color = Color.yellow;
        slots[6].color = Color.yellow;
        slots[7].color = Color.yellow;
        slots[8].color = Color.yellow;
        slots[9].color = Color.yellow;
    }

    void SlotColorWin2()
    {
        slots[0].color = Color.yellow;
        slots[1].color = Color.yellow;
        slots[7].color = Color.yellow;
        slots[13].color = Color.yellow;
        slots[14].color = Color.yellow;
    }
    void SlotColorWin3()
    {
        slots[10].color = Color.yellow;
        slots[11].color = Color.yellow;
        slots[7].color = Color.yellow;
        slots[3].color = Color.yellow;
        slots[4].color = Color.yellow;
    }
    void SlotColorWin4()
    {
        slots[0].color = Color.yellow;
        slots[6].color = Color.yellow;
        slots[12].color = Color.yellow;
        slots[8].color = Color.yellow;
        slots[4].color = Color.yellow;
    }

    void SlotColorStop()
    {
        slots[0].color = Color.white;
        slots[1].color = Color.white;
        slots[2].color = Color.white;
        slots[3].color = Color.white;
        slots[4].color = Color.white;
        slots[5].color = Color.white;
        slots[6].color = Color.white;
        slots[7].color = Color.white;
        slots[8].color = Color.white;
        slots[9].color = Color.white;
        slots[10].color = Color.white;
        slots[11].color = Color.white;
        slots[12].color = Color.white;
        slots[13].color = Color.white;
        slots[14].color = Color.white;
    }
}


/* switch(reels[0].stoppedSlotL2)
            {
                case "Diamond":
                    prizeValue = 100;
                    SlotColorWinL2();
                    break;
                case "Crown":
                    prizeValue = 200;
                    SlotColorWinL2();
                    break;
                case "Bar":
                    prizeValue = 300;
                    SlotColorWinL2();
                    break;
                case "Seven":
                    prizeValue = 400;
                    SlotColorWinL2();
                    break;
                case "Cherry":
                    prizeValue = 500;
                    SlotColorWinL2();
                    break;
                case "Lemon":
                    prizeValue = 600;
                    SlotColorWinL2();
                    break;
            }   */ 