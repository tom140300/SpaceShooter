using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] GameObject firstPositions;
    [SerializeField] GameObject secondPositions;
    [SerializeField] float objectSpeed;
    public int indexEnemy = 0;

    int nextPosIndex;
    public static bool isChap1, isMoveAround, isChap2;

    Transform nextPos;

    // Start is called before the first frame update
    void Start()
    {
        firstPositions = GameObject.Find("Chap1");
        secondPositions = GameObject.Find("Chap2");
        nextPos = firstPositions.transform.GetChild(0);
        isChap1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChap1) MoveGameObject();
        else if (isChap2)
        {
            MoveChap2();
        }
    }
    
    void MoveGameObject()
    {
        for (int i = 0; i < firstPositions.transform.childCount; i++)
        {
            if (indexEnemy == i)
            {
                if (transform.position == nextPos.position)
                {
                    nextPosIndex++;

                    if (nextPosIndex >= i)
                    {
                        nextPosIndex = i;
                        StartCoroutine(SetStateChap(5f));
                    }

                    nextPos = firstPositions.transform.GetChild(nextPosIndex);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPos.position,
                        objectSpeed * Time.deltaTime);
                }
            }
            
        }
    }

    private IEnumerator SetStateChap(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isChap1 = false;
        isChap2 = true;
    }

    void MoveChap2()
    {
        for (int i = 0; i < secondPositions.transform.childCount; i++)
        {
            if (indexEnemy == i)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    secondPositions.transform.GetChild(i).transform.position, objectSpeed * Time.deltaTime);
                StartCoroutine(SetStateMoveAround(5f));
            }
        }
    }

    private IEnumerator SetStateMoveAround(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isChap2 = false;
        isMoveAround = true;
    }
}