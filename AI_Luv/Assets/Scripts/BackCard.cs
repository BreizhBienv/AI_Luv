using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCard : MonoBehaviour
{
    [Range(0.1f, 0.9f)]
    [SerializeField] float _scaleBackCard = 0.8f;
    private SwipeEffect _swipeEffect;
    private GameObject _firstCard;
    private Vector3 _initialScale;
    private Vector3 _scaleAfterResize;

    public Vector3 GetInitialScale { get => _initialScale; }
    public float GetScaleBackCard { get => _scaleBackCard; }

    // Start is called before the first frame update
    void Start()
    {
        _swipeEffect = FindObjectOfType<SwipeEffect>();
        _firstCard = _swipeEffect.gameObject;

        _initialScale = transform.localScale;
        transform.localScale *= _scaleBackCard;
        _scaleAfterResize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_firstCard == null) return;

        float distanceMoved = _firstCard.transform.localPosition.x;

        if (Mathf.Abs(distanceMoved) > 0)
        {
            float stepX = Mathf.SmoothStep(_scaleAfterResize.x, _initialScale.x,
                Mathf.Abs(distanceMoved) / (Screen.width / 2));
            float stepY = Mathf.SmoothStep(_scaleAfterResize.y, _initialScale.y,
                Mathf.Abs(distanceMoved) / (Screen.width / 2));
            float stepZ = Mathf.SmoothStep(_scaleAfterResize.z, _initialScale.z,
                Mathf.Abs(distanceMoved) / (Screen.width / 2));

            transform.localScale = new Vector3(stepX, stepY, stepZ);
        }
    }
}
