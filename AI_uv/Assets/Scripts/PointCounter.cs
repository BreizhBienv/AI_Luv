using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeField] GameObject _recapMatch;
    [SerializeField] GameObject _star;
    [SerializeField] GameObject _match;

    [SerializeField] GameObject _TauxStatisfaction;
    [SerializeField] GameObject _bigStar;

    GameManager _gameManager;
    List<int> _score;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _score = new List<int>();
        FinalResult();
        AssignStars();
        FillClientSatisfation();
        transform.Find("NomClient").GetComponent<Text>().text =
            FindObjectOfType<GameManager>().GetClientName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FinalResult()
    {
        for (int i = 0; i < _gameManager.GetLikedProfiles.Count; ++i)
        {
            int currentMatchupScore = 0;

            foreach (Sprite sprite in _gameManager.GetLikedProfiles[i])
            {
                if (sprite == _gameManager.GetFPF)
                    currentMatchupScore += 1;

                if (sprite == _gameManager.GetUPF)
                    currentMatchupScore -= 2;
            }

            foreach (string text in _gameManager.GetLikedBios[i])
            {
                if (text == _gameManager.GetFBF)
                    currentMatchupScore += 1;

                if (text == _gameManager.GetUBF)
                    currentMatchupScore -= 2;
            }

            _score.Add(currentMatchupScore);
        }
    }

    private void AssignStars()
    {
        int index = 0;

        foreach (int score in _score)
        {
            GameObject gameObject = Instantiate(_match, _recapMatch.transform);
            gameObject.transform.SetAsFirstSibling();

            GameObject ProfileName = gameObject.transform.Find("NomMatch").gameObject;
            ProfileName.GetComponent<Text>().text = _gameManager.GetLikedNames[index];
            index++;

            GameObject totalStar = gameObject.transform.Find("TotalEtoiles").gameObject;

            for (int i = 0; i < score + 3; ++i)
            {
                Instantiate(_star, totalStar.transform);
            }
        }
    }

    private void FillClientSatisfation()
    {
        float finalScore = 0;

        foreach (int score in _score)
            finalScore += (score + 3);

        finalScore /= _score.Count;

        Mathf.CeilToInt(finalScore);

        for (int i = 0; i < finalScore; ++i)
        {
            Instantiate(_bigStar, _TauxStatisfaction.transform);
        }
    }
}
