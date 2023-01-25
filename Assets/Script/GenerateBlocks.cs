using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using Randomize = UnityEngine.Random;

public class GenerateBlocks : MonoBehaviour
{
    public List<GameObject> blocksType;
    List<GameObject> activeBlocks;

    public int blocksNum;
    public float speed;
    public bool isMoving;

    int hiddenBlocks;
    float blockLength = 36;
    bool firstBlock = true;

    // Start is called before the first frame update
    void Start()
    {
        activeBlocks = new List<GameObject>();

        int indexType = 0;

        for (int i = 0; i < blocksNum; i++)
        {
            indexType = i;

            if (i >= blocksType.Count)
            {
                indexType = i - blocksType.Count;
            }

            activeBlocks.Add(Instantiate(blocksType[indexType], new Vector3(transform.position.x, transform.position.y, blockLength * i), Quaternion.identity, gameObject.transform));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            transform.Translate(new Vector3(0, 0, -(speed * Time.deltaTime)));
        }

        hideBlock();

        randomizeBlocks();
    }

    void hideBlock()
    {
        for (int i = 0; i < activeBlocks.Count; i++)
        {
            if (activeBlocks[i].activeSelf)
            {
                if (activeBlocks[i].transform.position.z + blockLength < 0)
                {
                    activeBlocks[i].SetActive(false);
                    hiddenBlocks++;
                }
            }
        }
    }

    void randomizeBlocks()
    {
        if (hiddenBlocks == 5)
        {
            int numBlock = hiddenBlocks;
            hiddenBlocks = 0;

            shuffle(activeBlocks);

            for (int i = 0; i < activeBlocks.Count; i++)
            {
                if (!activeBlocks[i].activeSelf)
                {
                    activeBlocks[i].transform.position = new Vector3(0, 0, blockLength * numBlock);
                    numBlock++;
                    activeBlocks[i].SetActive(true);
                }
            }
        }
    }

    void shuffle(List<GameObject> list)
    {
        Random rng = new Random();
        int index;
        int limit;

        if (firstBlock)
        {
            firstBlock = !firstBlock;

            index = list.Count / 2;
            limit = 1;
        }
        else
        {
            firstBlock = !firstBlock;

            index = list.Count;
            limit = index / 2;
        }

        while (index > limit)
        {
            index--;
            int k = rng.Next(index + 1);
            GameObject value = list[k];
            list[k] = list[index];
            list[index] = value;
        }
    }

    private void FixedUpdate()
    {

    }
}
