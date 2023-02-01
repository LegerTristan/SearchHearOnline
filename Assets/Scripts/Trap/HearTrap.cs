using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(AudioSource))]
public class HearTrap : MonoBehaviour
{
    AudioSource src = null;

    [SerializeField]
    AudioClip trapClip = null;

    [SerializeField]
    SphereCollider trapSphere = null;

    [SerializeField, Range(1f, 100f)]
    float maxSoundRange = 1f;

    float currentSoundRange = 1f;

    [SerializeField, Range(1f, 100f)]
    float soundDecreaseSpeed = 1f;

    [SerializeField, Range(0.01f, 5f)]
    float clipVolume = 1f;

    bool soundWasPlayed = false;

    bool IsTrapValid => src && trapClip && trapSphere;

    void Start() => src = GetComponent<AudioSource>();

    void Update() => DecreaseSoundRange();

    void DecreaseSoundRange()
    {
        if (!IsTrapValid || !soundWasPlayed)
            return;

        currentSoundRange = Mathf.MoveTowards(currentSoundRange, 0f, Time.deltaTime * soundDecreaseSpeed);
        currentSoundRange = currentSoundRange < 0f ? 0f : currentSoundRange;
        soundWasPlayed = currentSoundRange > 0f;
        trapSphere.radius = currentSoundRange;
    }

    void PlaySoundTrap()
    {
        soundWasPlayed = true;
        src.PlayOneShot(trapClip, clipVolume);
        currentSoundRange = maxSoundRange;
    }

    void OnTriggerEnter(Collider _other)
    {
        if (!IsTrapValid)
            return;

        HearComponent _hearCompA = _other.gameObject.GetComponent<HearComponent>();

        if (!soundWasPlayed)
        {
            PlaySoundTrap();
            return;
        }

        HearComponent _hearComp = _other.gameObject.GetComponent<HearComponent>();

        if (_hearComp && soundWasPlayed)
        {
            _hearComp.SetHearSound(transform);
            return;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.Lerp(Color.red, Color.green, currentSoundRange / maxSoundRange);
        Gizmos.DrawWireSphere(transform.position, trapSphere.radius / 5);
    }
}
