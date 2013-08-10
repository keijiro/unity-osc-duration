using UnityEngine;
using System.Collections;

public class ParticleModifier : MonoBehaviour {
    void OnOscMessageCurve(float value) {
        particleSystem.emissionRate = value * 30.0f;
    }
}
