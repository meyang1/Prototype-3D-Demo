using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLeaveCanvas : MonoBehaviour
{
    public GameObject canvasQuest;
    public bool isActive1;
    public void OnClickTwice()
    {
        canvasQuest.SetActive(!canvasQuest.activeSelf);
    }

    public void OnComplete()
    {
        if (canvasQuest.activeSelf == true)
        {
            canvasQuest.SetActive(canvasQuest.activeSelf);
        }
        else
        {
            canvasQuest.SetActive(!canvasQuest.activeSelf);
        }
    }
}
