using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Prefered Features")]
    [SerializeField] List<Sprite> Eyes;
    [SerializeField] List<Sprite> Mouth;
    [SerializeField] List<Sprite> Hair;
    //[SerializeField] List<GameObject> Characteristics;

    [Header("Other Features")]
    [SerializeField] List<Sprite> BackGround;
    [SerializeField] List<Sprite> Head;
    [SerializeField] List<Sprite> Body;

    [Header("Biography")]
    [SerializeField] List<string> SystèmeExploitation;
    [SerializeField] List<string> SourceAlimentation;
    [SerializeField] List<string> CapacitéMémoire;

    private List<List<Sprite>> PreferedFeatures;
    private List<List<Sprite>> OtherFeatures;
    private List<List<string>> Biography;

    private Sprite _favoredPhysicalFeature = null;
    private string      _favoredBioFeature = null;
    private Sprite _unfavoredPhysicalFeature = null;
    private string      _unfavoredBioFeature = null;

    [Header("Gestion")]
    [SerializeField] GameObject _inGameUI;
    [SerializeField] GameObject _ResultsUI;
    private int _nbLikedProfile = 0;
    private int _numberProfilePassed = 0;
    private string _customerName = null;
    [SerializeField] Text _swipeCounter;
    [SerializeField] Text _likeCounter;
    [SerializeField] List<string> _names;

    List<List<Sprite>> _likedProfileElements;
    List<List<string>> _likeProfileBio;
    List<string> _likedNames;

    public List<List<Sprite>> GetPreferedFeatureList { get => PreferedFeatures; }
    public List<List<Sprite>> GetOtherFeatureList { get => OtherFeatures; }
    public List<List<string>> GetBioList { get => Biography; }
    public Sprite GetFPF { get => _favoredPhysicalFeature; set => _favoredPhysicalFeature = value; }
    public Sprite GetUPF { get => _unfavoredPhysicalFeature; set => _unfavoredPhysicalFeature = value; }
    public string GetFBF { get => _favoredBioFeature; set => _favoredBioFeature = value; }
    public string GetUBF { get => _unfavoredBioFeature; set => _unfavoredBioFeature = value; }
    public GameObject GetInGameUI { get => _inGameUI; }
    public GameObject GetResultsUI { get => _ResultsUI; }
    public int SetNbLikedProfile { get => _nbLikedProfile; set => _nbLikedProfile = value; }
    public int SetNbProfilePassed { get => _numberProfilePassed; set => _numberProfilePassed = value; }
    public List<List<Sprite>> GetLikedProfiles { get => _likedProfileElements; set => _likedProfileElements = value; }
    public List<List<string>> GetLikedBios { get => _likeProfileBio; set => _likeProfileBio = value; }
    public string GetClientName { get => _customerName; set => _customerName = value; }
    public Text LikeCounter { get => _likeCounter; }
    public Text SwipeCounter { get => _swipeCounter; }
    public List<string> GetNameList { get => _names; }
    public List<string> GetLikedNames { get => _likedNames; set => _likedNames = value; }

    private void Awake()
    {
        AddListToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        _likedProfileElements = new List<List<Sprite>>();
        _likeProfileBio = new List<List<string>>();
        _likedNames = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddListToList()
    {
        PreferedFeatures = new List<List<Sprite>>();

        PreferedFeatures.Add(Eyes);
        PreferedFeatures.Add(Mouth);
        PreferedFeatures.Add(Hair);
        //PreferedFeatures.Add(Characteristics);

        OtherFeatures = new List<List<Sprite>>();

        OtherFeatures.Add(BackGround);
        OtherFeatures.Add(Head);
        OtherFeatures.Add(Body);

        Biography = new List<List<string>>();

        Biography.Add(SystèmeExploitation);
        Biography.Add(SourceAlimentation);
        Biography.Add(CapacitéMémoire);
    }
}
