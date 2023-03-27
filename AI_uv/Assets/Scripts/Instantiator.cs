using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    [SerializeField] GameObject _pefabBackCard;
    [SerializeField] GameObject _prefabNoMoreProfile;
    [SerializeField] int _maxProfile = 20;
    [SerializeField] int _maxProfileLiked = 4;
    [SerializeField] GameObject _outOfLike;
    bool _endReached = false;
    GameManager _gameManager;
    public int MaxProfile { get => _maxProfile; }
    public int MaxLike { get => _maxProfileLiked; }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 2)
        {
            OutOfChances();
            InstantiateEndCard();
            InstantiateNewBackCard();
        }
    }

    private void InstantiateNewBackCard()
    {
        if (_gameManager.SetNbProfilePassed >= _maxProfile - 1) return;

        GameObject newCard = Instantiate(_pefabBackCard, transform, false);
        newCard.transform.SetAsFirstSibling();
    }

    private void InstantiateEndCard()
    {
        if (_gameManager.SetNbProfilePassed < _maxProfile - 1) return;
        if (_endReached) return;

        GameObject newCard = Instantiate(_prefabNoMoreProfile, transform, false);
        newCard.transform.SetAsFirstSibling();
        _endReached = true;
    }

    private void OutOfChances()
    {
        if (_gameManager.SetNbLikedProfile < _maxProfileLiked) return;
        if (_endReached) return;

        _endReached = true;
        Instantiate(_outOfLike, _gameManager.GetInGameUI.transform);
        GameObject firstCard = FindObjectOfType<SwipeEffect>().gameObject;
        Destroy(firstCard.GetComponent<SwipeEffect>());
    }
}
