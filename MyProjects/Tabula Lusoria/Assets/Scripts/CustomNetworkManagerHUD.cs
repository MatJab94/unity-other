namespace UnityEngine.Networking
{
	public class CustomNetworkManagerHUD : MonoBehaviour
	{
		public NetworkManager netMgr;
		[SerializeField] bool showGUI = true;
		[SerializeField] int offsetX;
		[SerializeField] int offsetY;

		bool showServer = false;

		void Update()
		{
			if (!showGUI)
				return;

			if (!NetworkClient.active && !NetworkServer.active && netMgr.matchMaker == null)
			{
				if (Input.GetKeyDown(KeyCode.S))
				{
					netMgr.StartServer();
				}
				if (Input.GetKeyDown(KeyCode.H))
				{
					netMgr.StartHost();
				}
				if (Input.GetKeyDown(KeyCode.C))
				{
					netMgr.StartClient();
				}
			}
			if (NetworkServer.active && NetworkClient.active)
			{
				if (Input.GetKeyDown(KeyCode.X))
				{
					netMgr.StopHost();
				}
			}
		}

		void OnGUI()
		{
			if (!showGUI)
				return;

			int xpos = 10 + offsetX;
			int ypos = 40 + offsetY;
			int spacing = 24;

			if (!NetworkClient.active && !NetworkServer.active && netMgr.matchMaker == null)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Host(H)"))
				{
					netMgr.StartHost();
				}
				ypos += spacing;

				if (GUI.Button(new Rect(xpos, ypos, 105, 20), "LAN Client(C)"))
				{
					netMgr.StartClient();
				}
				netMgr.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 95, 20), netMgr.networkAddress);
				ypos += spacing;

				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Server Only(S)"))
				{
					netMgr.StartServer();
				}
				ypos += spacing;
			}
			else
			{
				if (NetworkServer.active)
				{
					GUI.Label(new Rect(xpos, ypos, 300, 20), "Server: port=" + netMgr.networkPort);
					ypos += spacing;
				}
				if (NetworkClient.active)
				{
					GUI.Label(new Rect(xpos, ypos, 300, 20), "Client: address=" + netMgr.networkAddress + " port=" + netMgr.networkPort);
					ypos += spacing;
				}
			}

			if (NetworkClient.active && !ClientScene.ready)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Client Ready"))
				{
					ClientScene.Ready(netMgr.client.connection);

					if (ClientScene.localPlayers.Count == 0)
					{
						ClientScene.AddPlayer(0);
					}
				}
				ypos += spacing;
			}

			if (NetworkServer.active || NetworkClient.active)
			{
				if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Stop (X)"))
				{
					netMgr.StopHost();
				}
				ypos += spacing;
			}

			if (!NetworkServer.active && !NetworkClient.active)
			{
				ypos += 10;

				if (netMgr.matchMaker == null)
				{
					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Enable Match Maker (M)"))
					{
						netMgr.StartMatchMaker();
					}
					ypos += spacing;
				}
				else
				{
					if (netMgr.matchInfo == null)
					{
						if (netMgr.matches == null)
						{
							if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create Internet Match"))
							{
								netMgr.matchMaker.CreateMatch(netMgr.matchName, netMgr.matchSize, true, "", "", "", 0, 0, netMgr.OnMatchCreate);
							}
							ypos += spacing;

							GUI.Label(new Rect(xpos, ypos, 100, 20), "Room Name:");
							netMgr.matchName = GUI.TextField(new Rect(xpos + 100, ypos, 100, 20), netMgr.matchName);
							ypos += spacing;

							ypos += 10;

							if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Find Internet Match"))
							{
								netMgr.matchMaker.ListMatches(0, 20, "", true, 0, 0, netMgr.OnMatchList);
							}
							ypos += spacing;
						}
						else
						{
							foreach (var match in netMgr.matches)
							{
								if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Join Match:" + match.name))
								{
									netMgr.matchName = match.name;
									netMgr.matchSize = (uint)match.currentSize;
									netMgr.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, netMgr.OnMatchJoined);
								}
								ypos += spacing;
							}
						}
					}

					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Change MM server"))
					{
						showServer = !showServer;
					}
					if (showServer)
					{
						ypos += spacing;
						if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Local"))
						{
							netMgr.SetMatchHost("localhost", 1337, false);
							showServer = false;
						}
						ypos += spacing;
						if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Internet"))
						{
							netMgr.SetMatchHost("mm.unet.unity3d.com", 443, true);
							showServer = false;
						}
						ypos += spacing;
						if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Staging"))
						{
							netMgr.SetMatchHost("staging-mm.unet.unity3d.com", 443, true);
							showServer = false;
						}
					}

					ypos += spacing;

					GUI.Label(new Rect(xpos, ypos, 300, 20), "MM Uri: " + netMgr.matchMaker.baseUri);
					ypos += spacing;

					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Disable Match Maker"))
					{
						netMgr.StopMatchMaker();
					}
					ypos += spacing;
				}
			}
		}
	}
};
