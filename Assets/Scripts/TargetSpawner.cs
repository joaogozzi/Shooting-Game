using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mTargetRef;
    List<GameObject> mObjPool = new List<GameObject>();

    public bool stopGame { get; private set; }

    float mTimer = 0;
    float mMaxTime = 5f;

    private void Start()
    {
        int z = 0;

        for (int x = -10; x < 11; x += 2)
        {
            for (int y = 1; y < 21; y += 2)
            {
                GameObject clone = Instantiate(mTargetRef, new Vector3(x, y, z), Quaternion.identity);
                clone.transform.localScale = new Vector3(2, 2, 2);

                clone.SetActive(false);

                mObjPool.Add(clone);
            }
        }

        mTimer = mMaxTime;
    }

    private void Update()
    {
        if (stopGame)
            return;

        if (mTimer < mMaxTime)
        {
            mTimer += Time.deltaTime;
        }
        else
        {
            int randVal = Random.Range(0, mObjPool.Count);

            if (!mObjPool[randVal].activeInHierarchy)
            {
                mObjPool[randVal].SetActive(true);
            }
            else
            {
                while (mObjPool[randVal].activeInHierarchy)
                {
                    if (!mObjPool[randVal].activeInHierarchy)
                    {
                        mObjPool[randVal].SetActive(true);
                        break;
                    }

                    randVal = Random.Range(0, mObjPool.Count);
                }
            }

            mTimer = 0;
        }
    }

    public void RestartSpawn()
    {
        if (mObjPool.Count <= 0)
            return;

        mTimer = mMaxTime;

        for (int i = 0; i < mObjPool.Count; i++)
        {
            mObjPool[i].SetActive(false);
        }
    }

    public void StopSpawner(bool stop)
    {
        stopGame = stop;
    }
}