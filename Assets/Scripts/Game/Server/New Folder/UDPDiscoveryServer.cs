using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using System.Text;
using System.Threading;

public class UDPDiscoveryServer : MonoBehaviour
{
    private UdpClient udpServer;
    private IPEndPoint udpEndPoint;

    void Start()
    {
        udpServer = new UdpClient();
        udpEndPoint = new IPEndPoint(IPAddress.Broadcast, 4445); // พอร์ตที่ใช้ค้นหา
        udpServer.EnableBroadcast = true;

        // เริ่มส่งการตอบกลับให้กับ Client
        BroadcastResponse();
    }

    void BroadcastResponse()
    {
        string message = "GAME_SERVER_FOUND";
        byte[] data = Encoding.ASCII.GetBytes(message);

        udpServer.Send(data, data.Length, udpEndPoint); // ส่งคำตอบให้กับทุกเครื่องใน LAN
        Debug.Log("Broadcasting server availability...");

        // รอรับคำขอจาก Client ใหม่
        udpServer.BeginReceive(ReceiveRequest, null);
    }

    void ReceiveRequest(IAsyncResult ar)
    {
        byte[] receivedData = udpServer.EndReceive(ar, ref udpEndPoint);
        string message = Encoding.ASCII.GetString(receivedData);

        if (message == "GAME_DISCOVERY_REQUEST")
        {
            BroadcastResponse(); // เมื่อรับคำขอจาก Client ให้ตอบกลับด้วยการ Broadcast
        }

        udpServer.BeginReceive(ReceiveRequest, null);
    }

    void OnApplicationQuit()
    {
        udpServer.Close();
    }
}