using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambienceSource;
    [SerializeField] private AudioMixerGroup sfxGroup;

    public SoundData MusicaEjemplo;
    public SoundData AmbienteEjemplo;
    public SoundData sfxEjemplo;


    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        transform.parent = null;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Reproduce un SFX en un punto del mundo con variación de pitch y volumen
    public void PlaySFX(SoundData data, Vector3 position)
    {
        GameObject tempGO = new GameObject("TempAudio_" + data.name);
        tempGO.transform.position = position;

        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sfxGroup;   

        audioSource.clip = data.clip;

        float pitch = data.pitch + Random.Range(-data.randomPitchRange, data.randomPitchRange);
        float volume = data.volume + Random.Range(-data.randomVolumeRange, data.randomVolumeRange);

        audioSource.pitch = Mathf.Clamp(pitch, 0.1f, 3f);
        audioSource.volume = Mathf.Clamp01(volume);
        audioSource.spatialBlend = 1f; 
        audioSource.minDistance = 1f;
        audioSource.maxDistance = 20f;

        audioSource.Play();
        Destroy(tempGO, data.clip.length / audioSource.pitch + 0.1f);
    }
    public void PlaySFXWorld(SoundData data)
    {
        GameObject tempGO = new GameObject("TempAudio_" + data.name);

        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sfxGroup;

        audioSource.clip = data.clip;

        float pitch = data.pitch + Random.Range(-data.randomPitchRange, data.randomPitchRange);
        float volume = data.volume + Random.Range(-data.randomVolumeRange, data.randomVolumeRange);

        audioSource.pitch = Mathf.Clamp(pitch, 0.1f, 3f);
        audioSource.volume = Mathf.Clamp01(volume);
        audioSource.spatialBlend = 1f;
        audioSource.minDistance = 1f;
        audioSource.maxDistance = 20f;

        audioSource.Play();
        Destroy(tempGO, data.clip.length / audioSource.pitch + 0.1f);
    }

    // Reproduce música de fondo
    public void PlayMusic(SoundData data)
    {
        if (musicSource == null) return;

        musicSource.clip = data.clip;
        musicSource.volume = data.volume;
        musicSource.pitch = data.pitch;
        musicSource.loop = data.loop;
        musicSource.Play();
    }
    public void StopMusic()
    {
        if (musicSource == null) return;
        musicSource.Stop();
    }
    public void PlayAmbience(SoundData data)
    {
        if (ambienceSource == null) return;

        ambienceSource.clip = data.clip;
        ambienceSource.volume = data.volume;
        ambienceSource.pitch = data.pitch;
        ambienceSource.loop = data.loop;
        ambienceSource.Play();
    }

}

