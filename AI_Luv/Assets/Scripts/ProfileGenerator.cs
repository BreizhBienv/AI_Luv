using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> ProfileElements;
    [SerializeField] List<Text> _bioPRofile;
    [SerializeField] Text _nameText;

    private GameManager _gameManager;

    private List<string> Bio;
    private List<Sprite> Elements;
    private string profileName;

    public List<Sprite> GetElements { get => Elements; }
    public List<string> GetBio { get => Bio; }
    public string GetName { get => profileName; }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null) return;
        SetProfileElements();
        SetBio();
        SetName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetProfileElements()
    {
        int index = 0;
        Elements = new List<Sprite>();

        foreach (List<Sprite> list in _gameManager.GetPreferedFeatureList)
        {
            Sprite sprite = list[Random.Range(0, list.Count)];
            ProfileElements[index].GetComponent<Image>().sprite = sprite;
            Elements.Add(sprite);
            index++;
        }

        foreach (List<Sprite> list in _gameManager.GetOtherFeatureList)
        {
            Sprite sprite = list[Random.Range(0, list.Count)];
            ProfileElements[index].GetComponent<Image>().sprite = sprite;
            Elements.Add(sprite);
            index++;
        }
    }

    void SetBio()
    {
        Bio = new List<string>();

        int index = 0;

        foreach (List<string> vs in _gameManager.GetBioList)
        {
            string temp = vs[Random.Range(0, vs.Count)];

            Bio.Add(temp);
            _bioPRofile[index].text = temp;
            index++;
        }
    }

    private void SetName()
    {
        string proName = _gameManager.GetNameList[Random.Range(0, _gameManager.GetNameList.Count)];
        _nameText.text = proName;
        profileName = proName;
    }
}
