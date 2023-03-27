using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchButton : MonoBehaviour
{
    [SerializeField] Image _likeButton;
    [SerializeField] Image _dislikeButton;
    private SwipeEffect _frontCard;
    [Range(0, 255)]
    [SerializeField] float _minAlpha = 60;
    [Range(0, 255)]
    [SerializeField] float _maxAlpha = 255;
    private float _percentage = 0f;
    private float _minPercA;
    private float _maxPercA;
    public SwipeEffect SetCurrFrontCard { set => _frontCard = value; }
    public float SetPercentage { set => _percentage = value; }

    // Start is called before the first frame update
    void Start()
    {
        _frontCard = FindObjectOfType<SwipeEffect>();
        _minPercA = _minAlpha * 100 / 255;
        _maxPercA = _maxAlpha * 100 / 255;
    }

    // Update is called once per frame
    void Update()
    {
        if (_frontCard == null) return;

        float distanceMoved = _frontCard.transform.localPosition.x;

        //use / 100 to get to a value between 0 and 1, accepteble to change Alpha
        float newA = _percentage / 100;
        newA = Mathf.Clamp(newA, _minPercA / 100, _maxPercA / 100);;

        if (distanceMoved < 0)
        {
            Color tempColor = _dislikeButton.color;
            tempColor.a = newA;
            _dislikeButton.color = tempColor;
        }
        else if (distanceMoved > 0)
        {
            Color tempColor = _likeButton.color;
            tempColor.a = newA;
            _likeButton.color = tempColor;
        }
    }
}
