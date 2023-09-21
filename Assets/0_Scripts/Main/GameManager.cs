using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingletone<GameManager>
{
    public int gold;
    public int gems;


    private void Start()
    {
    }

    public void SaveResources()
    {
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("gems", gems);
        PlayerPrefs.Save();
        StartCoroutine("WaitForOneSecond");
    }

    public void LoadResources()
    {
        gold = PlayerPrefs.GetInt("gold");
        gems = PlayerPrefs.GetInt("gems");
    }

    //Testing


    private IEnumerator WaitForOneSecond()
    {
        while (true)
        {
            // Wait for 1 second
            gold += 1;
            Debug.LogError(gold);
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void AddGold(int value)
    {
        gold += value;
        // dodao
    }

}
