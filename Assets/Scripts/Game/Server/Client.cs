/*using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Client
{
    TcpClient client;

    public void ConnectToServer(string ip)
    {
        client = new TcpClient();
        client.Connect(ip, 7777);
        Debug.Log("เชื่อมต่อกับเซิร์ฟเวอร์แล้ว");
    }
}*/

using System;
using System.Net.Sockets;
using UnityEngine;

public class Client : MonoBehaviour
{
    public bool isClient = true; // เพิ่มตรงนี้ให้ตั้งค่าใน Inspector ได้
    private TcpClient client;


    void Start()
    {
        if (!isClient) return;
        
        client = new TcpClient();
        client.BeginConnect("127.0.0.1", 7777, OnConnected, null); // เปลี่ยน IP ตามเครื่อง server
    }

    void OnConnected(IAsyncResult ar)
    {
        client.EndConnect(ar);
        Debug.Log("Connected to server!");
    }
    
}
