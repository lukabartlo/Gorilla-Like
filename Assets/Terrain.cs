using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain2 : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum;
    [SerializeField] GameObject Dirt, Grass;

    void Start()
    {
        PreGeneration();
        Generation();
        PostGeneration();
    }

    void PreGeneration()
    {
        int x = -26 - 16;
        height = maxHeight + 30;
        while (x < -26)
        {
            GenerateFlatPlatform(x);
            x++;
        }
    }

    void PostGeneration()
    {
        int x = width;
        height = maxHeight + 30;
        while (x < width + 16)
        {
            GenerateFlatPlatform(x);
            x++;
        }

    }

    void Generation()
    {
        int repeatValue = 0;
        for (int x = -26; x < width; x++)        //spawn tile on X axis
        {
            if (repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;
            }
            else
            {
                GenerateFlatPlatform(x);
                repeatValue--;
            }
        }
    }

    void GenerateFlatPlatform(int x)
    {
        for (int y = -15; y < height; y++)      //Spawn tile on Y axis
        {
            SpawnObj(Dirt, x, y);
        }
        SpawnObj(Grass, x, height);
    }

    void SpawnObj(GameObject obj, int width, int height)     //makes a child of my procedural generation
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
