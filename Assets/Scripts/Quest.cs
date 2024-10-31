using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] int numberOfCrates = 5;
    [SerializeField] int cratesDesttroyed;

    [SerializeField] GameObject map;

    enum QuestState
    {
        Inactive,
        Active,
        Complete
    }

    [SerializeField] QuestState myQuest;

    // Start is called before the first frame update
    void Start()
    {
        myQuest = QuestState.Inactive;
        MyEvents.Update.AddListener(UpdateQuest);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateQuest(float xPos, float yPos, float zPos)
    {
        cratesDesttroyed++;

        if (cratesDesttroyed == numberOfCrates)
        {
            myQuest = QuestState.Complete;
            map.SetActive(true);
            map.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
