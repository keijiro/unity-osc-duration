using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    Quaternion spin;

    void Start ()
    {
        spin = Quaternion.AngleAxis (Random.Range (60, 120), Vector3.up);
        spin *= Quaternion.AngleAxis (Random.Range (60, 120), Vector3.right);
    }
    
    void Update ()
    {
        transform.localRotation =
            Quaternion.Slerp (Quaternion.identity, spin, Time.deltaTime) *
            transform.localRotation;
        transform.localScale = Vector3.Lerp (Vector3.one, transform.localScale, Mathf.Exp (-10.0f * Time.deltaTime));
    }

    void OnOscMessageBang ()
    {
        transform.localScale = Vector3.one * 3.0f;
    }
}
