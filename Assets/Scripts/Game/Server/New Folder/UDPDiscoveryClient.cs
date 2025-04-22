using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using System.Text;
using System.Threading; 

public class UDPDiscoveryClient : MonoBehaviour
{
    private UdpClient udpClient;
    private IPEndPoint udpEndPoint;

    void Start()
    {
        udpClient = new UdpClient();
        udpEndPoint = new IPEndPoint(IPAddress.Broadcast, 4445); // พอร์ตที่ใช้ค้นหา

        // ส่งคำขอหากำลังมองหา Server
        DiscoverServer();
    }

    void DiscoverServer()
    {
        string message = "GAME_DISCOVERY_REQUEST";
        byte[] data = Encoding.ASCII.GetBytes(message);
        udpClient.Send(data, data.Length, udpEndPoint); // ส่งคำขอค้นหาผ่าน UDP Broadcast
        Debug.Log("Searching for game server...");

        // รอรับการตอบกลับจาก Server
        udpClient.BeginReceive(ReceiveResponse, null);
    }

    void ReceiveResponse(IAsyncResult ar)
    {
        byte[] receivedData = udpClient.EndReceive(ar, ref udpEndPoint);
        string message = Encoding.ASCII.GetString(receivedData);

        if (message == "GAME_SERVER_FOUND")
        {
            // เชื่อมต่อไปยัง Server ที่พบ
            ConnectToServer();
        }

        // ถ้าไม่เจอ Server ก็จะเริ่มค้นหาต่อไป
        udpClient.BeginReceive(ReceiveResponse, null);
    }

    void ConnectToServer()
    {
        // ตรงนี้สามารถใช้ TCP หรือวิธีที่เหมาะสมในการเชื่อมต่อ
        Debug.Log("Found Server, connecting...");
    }

    void OnApplicationQuit()
    {
        udpClient.Close();
    }
}