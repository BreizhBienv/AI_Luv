using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOoL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PassToResults()
    {
        GameManager gamemanager = FindObjectOfType<GameManager>();

        gamemanager.GetInGameUI.SetActive(false);
        gamemanager.GetResultsUI.SetActive(true);
    }
}
