using UnityEngine;

public class HearComponent : MonoBehaviour
{
    //[SerializeField]
    //HearTrap[] traps = null;

    Vector3 lastSoundPos = Vector3.zero;

    [SerializeField, Range(0.1f, 10f)]
    float maxRememberTime = 3f;

    [SerializeField]
    float rememberTime = 0f;

    bool hearSound = false;

    public Vector3 LastSoundPos => lastSoundPos;

    public bool HearSound => hearSound;

    void Update() => UpdateRememberTime();

    void UpdateRememberTime()
    {
        if (!hearSound)
            return;

        rememberTime -= Time.deltaTime;
        rememberTime = rememberTime < 0f ? 0f : rememberTime;
        hearSound = rememberTime != 0f;
    }

    public void SetHearSound(Transform _heard)
    {
        lastSoundPos = _heard.position;
        hearSound = true;
        rememberTime = maxRememberTime;
        Debug.Log("cocou");
        Debug.Log(lastSoundPos);
    }
}
