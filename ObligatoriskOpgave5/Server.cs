using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Newtonsoft.Json;

namespace ObligatoriskOpgave5
{
    class Server
    {
        private List<FootballPlayer> playerList = new List<FootballPlayer>() { new FootballPlayer("Lars", 234, 46), new FootballPlayer("Karl", 645, 73) };
        public void Start()
        {
            TcpListener listen = new TcpListener(IPAddress.Loopback, 2121);
            listen.Start();
            
            while (true) {
                TcpClient socket = listen.AcceptTcpClient();
                Task.Run(
                    () => {
                        TcpClient tmpSocket = socket;
                        DoClient(tmpSocket);
                    } 
                    );
            }

        }

        public void DoClient(TcpClient socket) {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                sw.AutoFlush = true;

                sw.WriteLine("Available Inputs:\n" +
                    "'HentAlle'\n" +
                    "'Hent' [Enter] '{id}'\n" + 
                    "'Gem' [Enter] '{Object som Json}'");


                String Line1 = sr.ReadLine().ToLower();
                if(Line1 == null) {
                    sw.WriteLine("invalid Input");
                    return;
                }


                String Line2 = sr.ReadLine();
                if (Line1 != "hentalle" && Line2 == null) {
                    sw.WriteLine("Invalid Input");
                    return;
                }

                //If sentence for the "HentAlle" function
                if (Line1 == "hentalle") {
                    foreach (FootballPlayer player in playerList) {
                        sw.WriteLine(JsonConvert.SerializeObject(player));
                    }
                    return;
                }
                //If sentence for the "Hent" function
                else if (Line1 == "hent") {
                    int id = Convert.ToInt32(Line2);
                    foreach (FootballPlayer player in playerList) {
                        if (player.ID == id) sw.WriteLine(JsonConvert.SerializeObject(player));
                        return;
                    }
                    return;
                }
                //If sentence for the "Gem" function
                else if (Line1 == "gem") {
                    FootballPlayer newPlayer = JsonConvert.DeserializeObject<FootballPlayer>(Line2);
                    if (newPlayer != null) playerList.Add(newPlayer);
                }
            }
        }
    }
}
