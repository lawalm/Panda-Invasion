using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This persistant class handles the background music
/// </summary>
public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null;
    public AudioClip bgMusic;
    public AudioSource music;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        music.GetComponent<AudioSource>();
        music.clip = bgMusic;
        music.loop = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
