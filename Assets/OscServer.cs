using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;

public class OscServer : MonoBehaviour
{
    public int listenPort = 6666;
    UdpClient udpClient;
    IPEndPoint endPoint;
    Osc.Parser osc = new Osc.Parser ();
    
    void Start ()
    {
        endPoint = new IPEndPoint (IPAddress.Any, listenPort);
        udpClient = new UdpClient (endPoint);
    }

    void Update ()
    {
        while (udpClient.Available > 0) {
            osc.FeedData (udpClient.Receive (ref endPoint));
        }

        while (osc.MessageCount > 0) {
            var msg = osc.PopMessage ();

            Debug.Log (msg);

            var target = GameObject.Find (msg.path.Replace ("/", "_"));
            if (target) {
                if (msg.data.Length == 0) {
                    target.SendMessage ("OnOscMessageBang");
                } else if (msg.data.Length == 1) {
                    target.SendMessage ("OnOscMessageCurve", (float)msg.data[0]);
                } else if (msg.data.Length == 3) {
                    var r = (int)msg.data[0] / 255.0f;
                    var g = (int)msg.data[1] / 255.0f;
                    var b = (int)msg.data[2] / 255.0f;
                    target.SendMessage ("OnOscMessageColor", new Color(r, g, b));
                }
            }
        }
    }
}