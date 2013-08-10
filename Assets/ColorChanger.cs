using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {
    void OnOscMessageColor(Color color) {
        Camera.main.backgroundColor = color;
    }
}
