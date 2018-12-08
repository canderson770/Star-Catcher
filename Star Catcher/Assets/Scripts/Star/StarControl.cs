using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class StarControl : MonoBehaviour
{
    //Private Variables
    float dynamicVolume;
    float randomDir;
    Rigidbody starRB;
    AudioSource audio;
    Transform parent;
    Transform audioParent;

    //Prefabs
    public GameObject starSplash;
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    public float volume = 80;

    [Tooltip("Horizontal Force when the star spawns")]
    public float force = 100;

    [Tooltip("Amount of time before the star is destroyed")]
    public float lifetime = 3;

    void Start()
    {
        starRB = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        parent = GameObject.Find("Stars and VFX").transform;
        audioParent = GameObject.Find("Audio").transform;

        randomDir = Random.value;
        if (randomDir > .5f)
            randomDir = 1;
        else
            randomDir = -1;

        starRB.AddForce(new Vector3(Random.Range(force / 2, force) * randomDir, 0, 0), ForceMode.VelocityChange);

        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (starSplash != null)
        {
            if (coll.gameObject.layer == 8 /*Ground*/)
            {
                gameObject.layer = 17 /*StarBoundaryOff*/;
                foreach (ContactPoint contact in coll)
                {
                    GameObject temp = Instantiate(starSplash, contact.point + Vector3.up / 5, Quaternion.identity) as GameObject;
                    temp.transform.SetParent(parent);
                    Destroy(temp, 1);
                }

                dynamicVolume = Mathf.Abs(starRB.velocity.y / volume);

                MyPlayClipAtPoint._PlayClipAtPoint(clip, transform, dynamicVolume, audioParent, mixerGroup);
            }
        }
    }

}
