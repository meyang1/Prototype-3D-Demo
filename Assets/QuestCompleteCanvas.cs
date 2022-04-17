using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompleteCanvas : MonoBehaviour
{
    public QuestLeaveCanvas canvasLeaveQuest;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(slowTime(4.1f));
    }

    IEnumerator slowTime(float timeDelay)
    { 
        yield return new WaitForSeconds(timeDelay);
        canvasLeaveQuest.OnComplete();
    }
}
