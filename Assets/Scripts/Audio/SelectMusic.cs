using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectMusic : MonoBehaviour
{
    private int _musicIndex = 0;
    private AudioManager _audioManager;
    public Button LeftButton;
    public Button RightButton;
    public TextMeshProUGUI TextMusicTitle;
    public TextMeshProUGUI TextMusicAuthor;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicIndex"))
            _musicIndex = PlayerPrefs.GetInt("musicIndex");
        ChangeText();
        HandleBoundaryButtons();
    }

    public void IncrementMusicIndex()
    {
        if (_musicIndex == _audioManager.Musics.Count) return;
        _audioManager.ChangeMusic(++_musicIndex);
        ChangeText();
        HandleBoundaryButtons();
    }

    public void DecrementMusicIndex()
    {
        if (_musicIndex == 0) return;
        _audioManager.ChangeMusic(--_musicIndex);
        ChangeText();
        HandleBoundaryButtons();
    }

    private void ChangeText()
    {
        string fullMusicName = _audioManager.Musics[_musicIndex].name;
        string[] nameParts = fullMusicName.Split('-');

        if (nameParts.Length == 2)
        {
            TextMusicTitle.text = nameParts[0].Trim();
            TextMusicAuthor.text = "- " + nameParts[1].Trim();
        }
        else
        {
            TextMusicTitle.text = fullMusicName;
            TextMusicAuthor.text = "";
        }
    }

    private void HandleBoundaryButtons()
    {
        LeftButton.gameObject.SetActive(true);
        RightButton.gameObject.SetActive(true);

        if (_musicIndex == 0)
            LeftButton.gameObject.SetActive(false);
        if (_musicIndex == _audioManager.Musics.Count - 1)
            RightButton.gameObject.SetActive(false);
    }
}
