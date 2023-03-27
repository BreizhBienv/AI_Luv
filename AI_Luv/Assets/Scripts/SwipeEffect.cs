using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Range(0, 1)]
    [SerializeField] float _distanceToKill = 0.3f;
    [SerializeField] float _disperseSpeed = 5f;
    [Range(0.1f, 1f)]
    [SerializeField] float _moveSpeed = 0.2f;
    [Range(0, 360)]
    [SerializeField] float _angleRotation = 30f;
    [SerializeField] float _maxDistance = 300f;

    float _distanceMoved;
    private Vector3 _initialPos;
    private bool _swipeLeft;
    private Image _image;

    public float GetDistanceToKill { get => _distanceToKill; set => _distanceToKill = value; }
    public float GetDisperseSpeed { get => _disperseSpeed; set => _disperseSpeed = value; }
    public float GetMoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float GetAngleRotation { get => _angleRotation; set => _angleRotation = value; }
    public Vector3 GetInitialPos { get => _initialPos; }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPos = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPos.x);

        if (gameObject.tag != "ClientCard" && gameObject.tag != "EndCard")
            FindObjectOfType<MatchButton>().SetPercentage = (_distanceMoved * 100) / _maxDistance;

        //card follow drag
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

        if (transform.localPosition.x > _initialPos.x)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -_angleRotation,
                (_initialPos.x + transform.localPosition.x) / (Screen.width / 2)));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, +_angleRotation,
             (_initialPos.x - transform.localPosition.x) / (Screen.width / 2)));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPos.x);
        //when released, goes back to initial pos
        if (_distanceMoved < _distanceToKill * Screen.width)
        {
            transform.localPosition = _initialPos;
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            if (transform.localPosition.x > _initialPos.x)
                _swipeLeft = false;
            else
                _swipeLeft = true;

            FindObjectOfType<MatchButton>().SetPercentage = 0;
            //fade in the direction released
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;

        if (_image == null)
        {
            _image = GetComponent<Image>();
        }

        GameManager gameManager = FindObjectOfType<GameManager>();

        while (gameObject.GetComponent<CanvasGroup>().alpha != 0)
        {
            time += Time.deltaTime;

            if (_swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x - Screen.width, _moveSpeed * time), transform.localPosition.y, 0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x + Screen.width, _moveSpeed * time), transform.localPosition.y, 0);
            }

            gameObject.GetComponent<CanvasGroup>().alpha = Mathf.SmoothStep(1, 0, _disperseSpeed * time);

            yield return null;
        }

        if (gameObject.tag != "ClientCard" && gameObject.tag != "EndCard")
        {
            gameManager.SetNbProfilePassed += 1;
            gameManager.SwipeCounter.text = gameManager.SetNbProfilePassed + " / " + FindObjectOfType<Instantiator>().MaxProfile;
        }

        if (!_swipeLeft && gameObject.tag != "ClientCard" && gameObject.tag != "EndCard")
        {
            ProfileGenerator profileGenerator = transform.GetComponent<ProfileGenerator>();
            gameManager.GetLikedProfiles.Add(profileGenerator.GetElements);
            gameManager.GetLikedBios.Add(profileGenerator.GetBio);
            gameManager.GetLikedNames.Add(profileGenerator.GetName);

            gameManager.SetNbLikedProfile += 1;
            gameManager.LikeCounter.text = gameManager.SetNbLikedProfile + " / " + FindObjectOfType<Instantiator>().MaxLike;
        }

        if (gameObject.tag == "EndCard")
        {
            gameManager.GetInGameUI.SetActive(false);
            gameManager.GetResultsUI.SetActive(true);
        }

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        BackCardToFrontCard();
    }

    private void BackCardToFrontCard()
    {
        BackCard backCard = FindObjectOfType<BackCard>();

        if (backCard == null) return;

        SwipeEffect swipeEffect = backCard.gameObject.AddComponent<SwipeEffect>();
        swipeEffect.GetAngleRotation = _angleRotation;
        swipeEffect.GetDisperseSpeed = _disperseSpeed;
        swipeEffect.GetDistanceToKill = _distanceToKill;
        swipeEffect.GetMoveSpeed = _moveSpeed;

        FindObjectOfType<MatchButton>().SetCurrFrontCard = swipeEffect;
        Destroy(backCard.GetComponent<BackCard>());
    }
}
