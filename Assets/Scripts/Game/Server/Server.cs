/*using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Server
{
    TcpListener server;
    public List<TcpClient> clients = new List<TcpClient>();

    public void StartServer()
    {
        server = new TcpListener(IPAddress.Any, 7777);
        server.Start();
        server.BeginAcceptTcpClient(OnClientConnected, null);
        Debug.Log("Server started on port 7777");
    }

    void OnClientConnected(IAsyncResult ar)
    {
        TcpClient client = server.EndAcceptTcpClient(ar);
        clients.Add(client);
        Debug.Log("มีผู้เล่นใหม่เชื่อมต่อเข้ามา");

        server.BeginAcceptTcpClient(OnClientConnected, null);
    }
}*/


using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Server : MonoBehaviour
{
    public bool isServer = true; // เพิ่มตรงนี้ให้ตั้งค่าใน Inspector ได้
    private TcpListener listener;
    private List<TcpClient> clients = new List<TcpClient>();

    void Start()
    {
        if (!isServer) return; // ใช้ bool จาก Inspector
        
        listener = new TcpListener(IPAddress.Any, 7777);
        listener.Start();
        listener.BeginAcceptTcpClient(OnClientConnected, null);
        Debug.Log("Server started on port 7777");
    }

    void OnClientConnected(IAsyncResult ar)
    {
        TcpClient client = listener.EndAcceptTcpClient(ar);
        clients.Add(client);
        Debug.Log("Client connected: " + client.Client.RemoteEndPoint.ToString());
        listener.BeginAcceptTcpClient(OnClientConnected, null);
    }
}
