using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject presentSequense;

    [FormerlySerializedAs("Sequencepresent")] [FormerlySerializedAs("presentSequence")]
    public List<GameObject> sequencePresent = new List<GameObject>();

    public List<GameObject> sequenceSymbols = new List<GameObject>();

    [FormerlySerializedAs("sequanceParts")]
    public List<GameObject> sequenceParts = new List<GameObject>();

    [FormerlySerializedAs("sequanceObjects")]
    public List<GameObject> sequenceObjects = new List<GameObject>();

    private float timer = 0;
    private int currentIndex = 0;
    private float waitTime = 2.0f;
    private bool sequenceRunning = false;
    
    void Update()
    {
        GameObject newObj = null;
        GameObject presentObj = null;

        if (Input.GetKeyDown(KeyCode.Alpha1) && sequenceParts.Count > 0 && sequenceSymbols.Count > 0)
        {
            newObj = Instantiate(sequenceParts[0], parent.transform);
            presentObj = Instantiate(sequenceSymbols[0], presentSequense.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && sequenceParts.Count > 1 && sequenceSymbols.Count > 1)
        {
            newObj = Instantiate(sequenceParts[1], parent.transform);
            presentObj = Instantiate(sequenceSymbols[1], presentSequense.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && sequenceParts.Count > 2 && sequenceSymbols.Count > 2)
        {
            newObj = Instantiate(sequenceParts[2], parent.transform);
            presentObj = Instantiate(sequenceSymbols[2], presentSequense.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && sequenceParts.Count > 3 && sequenceSymbols.Count > 3)
        {
            newObj = Instantiate(sequenceParts[3], parent.transform);
            presentObj = Instantiate(sequenceSymbols[3], presentSequense.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && sequenceParts.Count > 4 && sequenceSymbols.Count >4)
        {
            newObj = Instantiate(sequenceParts[4], parent.transform);
            presentObj = Instantiate(sequenceSymbols[4], presentSequense.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && sequenceParts.Count > 5 && sequenceSymbols.Count >5)
        {
            newObj = Instantiate(sequenceParts[5], parent.transform);
            presentObj = Instantiate(sequenceSymbols[5], presentSequense.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) && sequenceParts.Count > 6 && sequenceSymbols.Count >6)
        {
            newObj = Instantiate(sequenceParts[6], parent.transform);
            presentObj = Instantiate(sequenceSymbols[6], presentSequense.transform);
        }

        if (sequenceParts.Count == 0)
        {
            return;
        }

        if (sequencePresent.Count == 15)
        {
            sequenceRestart();
        }
        
        
        
        if (newObj != null && presentObj != null)
        {
            newObj.SetActive(false);
            
            newObj.transform.SetSiblingIndex(currentIndex);
            
            sequenceObjects.Insert(currentIndex, newObj);

            presentObj.SetActive(true);
            presentObj.transform.SetSiblingIndex(currentIndex);
            sequencePresent.Insert(currentIndex, presentObj);
        
            for (int i = 0; i < sequencePresent.Count; i++)
            {
                Vector3 newPos = presentSequense.transform.position;
                newPos.x += i * 0.5f;
                sequencePresent[i].transform.position = newPos;
            }

            if (sequenceObjects.Count == 1)
            {
                sequenceRunning = true;
            }
        }

        if (sequenceRunning)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                if (currentIndex < sequenceObjects.Count)
                {
                    sequenceObjects[currentIndex].SetActive(true);
                    Debug.Log(sequenceObjects[currentIndex]);
                }

                if  (currentIndex > 0 && currentIndex - 1 < sequenceObjects.Count)
                {
                    
                        sequenceObjects[currentIndex - 1].SetActive(false);
                    
                }

                currentIndex++;

                if (currentIndex >= sequenceObjects.Count)
                {
                    Invoke("LastSequance", 2.0f);
                }

                timer = 0f;
            }
        }
    }

    void LastSequance()
    {
        if (sequenceObjects.Count > 0 && currentIndex > 0 && currentIndex - 1 < sequenceObjects.Count)

        {
            sequenceObjects[currentIndex - 1].SetActive(false);
        }

        currentIndex = 0;
    }

    void sequenceRestart()
    {
        foreach (var obj in sequenceObjects)
        {
            Destroy(obj);
        }
        foreach (var obj in sequencePresent)
        {
            Destroy(obj);
        }
        
        sequenceObjects.Clear();
        sequencePresent.Clear();

        currentIndex = 0;
        sequenceRunning = false;
        timer = 0;
    }
}


// IEnumerator ActivateObjectsInSequence(float waitTime)
// {
//     int i = 0;
//
//     while (true)
//     {
//         sequanceObjects[i].SetActive(true);
//         yield return new WaitForSeconds(waitTime);
//
//         if (i > 0)
//         {
//             sequanceObjects[i - 1].SetActive(false);
//         }
//
//         i++;
//
//         if (i >= sequanceObjects.Count)
//         {
//             sequanceObjects[i - 1].SetActive(false);
//             i = 0;
//         }
//     }
// }