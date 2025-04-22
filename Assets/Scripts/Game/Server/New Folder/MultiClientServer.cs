using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class MultiClientServer : MonoBehaviour
{
    private TcpListener tcpListener;
    private List<TcpClient> clients = new List<TcpClient>();

    void Start()
    {
        tcpListener = new TcpListener(IPAddress.Any, 7777);
        tcpListener.Start();
        tcpListener.BeginAcceptTcpClient(OnClientConnected, null);
        Debug.Log("Server started on port 7777");
    }

    void OnClientConnected(IAsyncResult ar)
    {
        TcpClient client = tcpListener.EndAcceptTcpClient(ar);
        clients.Add(client);
        Debug.Log("Client connected: " + client.Client.RemoteEndPoint.ToString());

        // ฟังข้อมูลจาก client ใหม่
        ReceiveData(client);

        // รอรับ client ต่อไป
        tcpListener.BeginAcceptTcpClient(OnClientConnected, null);
    }

    void ReceiveData(TcpClient client)
    {
        NetworkStream networkStream = client.GetStream();
        byte[] buffer = new byte[1024];
        networkStream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, new Tuple<TcpClient, byte[]>(client, buffer));
    }

    void OnDataReceived(IAsyncResult result)
    {
        Tuple<TcpClient, byte[]> asyncState = (Tuple<TcpClient, byte[]>)result.AsyncState;
        TcpClient client = asyncState.Item1;
        byte[] buffer = asyncState.Item2;
        NetworkStream networkStream = client.GetStream();

        int bytesRead = networkStream.EndRead(result);

        if (bytesRead > 0)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Debug.Log("Received from " + client.Client.RemoteEndPoint + ": " + message);
        }

        // ฟังข้อมูลต่อไป
        ReceiveData(client);
    }

    void SendDataToAllClients(string message)
    {
        foreach (TcpClient client in clients)
        {
            NetworkStream networkStream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            networkStream.Write(buffer, 0, buffer.Length);
        }
    }

    void OnApplicationQuit()
    {
        foreach (TcpClient client in clients)
        {
            client.Close();
        }
        tcpListener.Stop();
    }
}
