using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClientGenerator : MonoBehaviour
{
    int index;

    [SerializeField] Image ClientPic;
    [SerializeField] Text ClientName;


    [SerializeField] List<Sprite> ClientPics;
    [SerializeField] List<string> ClientNames;

    // Start is called before the first frame update
    void Start()
    {
        index = Random.Range(0, ClientNames.Capacity);
        ClientPic.sprite = ClientPics[index];
        ClientName.text = ClientNames[index];
        FindObjectOfType<GameManager>().GetClientName = ClientName.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
