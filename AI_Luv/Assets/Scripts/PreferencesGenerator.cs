using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreferencesGenerator : MonoBehaviour
{
    [SerializeField] Text Pref1;
    [SerializeField] Text Pref2;
    [SerializeField] Text Dislike;

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager == null) return;
        int one = ChooseLikedPhysiqueFeature();
        int two = ChooseLikedBiographyFeature();
        ChooseNotLikedFeature(one, two);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int ChooseLikedPhysiqueFeature()
    {
        int one = Random.Range(0, _gameManager.GetPreferedFeatureList.Count);

        List<Sprite> list1 = _gameManager.GetPreferedFeatureList[one];


        _gameManager.GetFPF = list1[Random.Range(0, list1.Count)];

        Pref1.text = _gameManager.GetFPF.name;

        return one;
    }

    private int ChooseLikedBiographyFeature()
    {
        int one = Random.Range(0, _gameManager.GetBioList.Count);

        List<string> list1 = _gameManager.GetBioList[one];

        _gameManager.GetFBF = list1[Random.Range(0, list1.Count)];

        Pref2.text = _gameManager.GetFBF;

        return one;
    }

    private void ChooseNotLikedFeature(int physicalListChoosed, int bioListChoosed)
    {
        int ran = Random.Range(0, 1);

        if (ran == 0)
        {
            while (true)
            {
                ran = Random.Range(0, _gameManager.GetPreferedFeatureList.Count);

                if (ran != physicalListChoosed)
                {
                    _gameManager.GetUPF = _gameManager.GetPreferedFeatureList[ran]
                        [Random.Range(0, _gameManager.GetPreferedFeatureList[ran].Count)];

                    Dislike.text = _gameManager.GetUPF.name;
                    break;

                }
            }
        }
        else
        {
            while (true)
            {
                ran = Random.Range(0, _gameManager.GetBioList.Count);

                if (ran != physicalListChoosed)
                {
                    _gameManager.GetUBF = _gameManager.GetBioList[ran]
                        [Random.Range(0, _gameManager.GetBioList[ran].Count)];

                    Dislike.text = _gameManager.GetUBF;
                    break;
                }
            }
        }
    }
}
