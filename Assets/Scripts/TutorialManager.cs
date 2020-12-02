using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex = 0;
    public GameObject speedUp;
    public GameObject phasePower;
    public GameObject player;
    public GameObject slime;
    public GameObject freeze;
    public GameObject jumpPower;

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i==popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex <= 2)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                popUpIndex += 1;
            }
        }
        else if(popUpIndex == 3)
        {
            if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
            {
                popUpIndex += 1;
            }
        }
        else if(popUpIndex==4)
        {
            if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.sKey.wasPressedThisFrame)
            {
                popUpIndex += 1;
            }
        }
        else if(popUpIndex == 5)
        {
            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                popUpIndex += 1;
            }    
        }
        else if (popUpIndex == 6)
        {
            if (!speedUp.activeSelf)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 7)
        {
            if (Vector3.Distance(player.transform.position, phasePower.transform.position) <= 90)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 8)
        {
            if (!slime.activeSelf)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 9)
        {
            if (!phasePower.activeSelf)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 10)
        {
            if (!freeze.activeSelf)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 11)
        {
            if (Vector3.Distance(player.transform.position, freeze.transform.position) > 50)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 12)
        {
            if (!jumpPower.activeSelf)
            {
                popUpIndex += 1;
            }
        }
        else if (popUpIndex == 13)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                popUpIndex += 1;
            }
        }

    }
}
