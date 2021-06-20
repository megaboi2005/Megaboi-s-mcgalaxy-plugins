//reference System.dll;
//reference System.Net.Http.dll
using System;
using System.IO;
using System.Net;
using MCGalaxy;
using System.Text;

namespace MCGalaxy {
	public class Example : Plugin {
		public override string name { get { return "random joke"; } }
		public override string MCGalaxy_Version { get { return "1.9.3.2"; } }
		public override int build { get { return 1; } }
		public override string creator { get { return "megaboi"; } }
		public override bool LoadAtStartup { get { return true; } }

		public override void Load(bool startup) {
            Chat.MessageGlobal("%eLOL");
            Command.Register(new Cmdjoke());
			//LOAD YOUR PLUGIN WITH EVENTS OR OTHER THINGS!

		}
                        
		public override void Unload(bool shutdown) {
			//UNLOAD YOUR PLUGIN BY SAVING FILES OR DISPOSING OBJECTS!
            Chat.MessageGlobal("%eLOL");
            
		}
                        
		public override void Help(Player p) {
			//HELP INFO!
            Command.Unregister(Command.Find("joke"));
		}
	}
        public class Cmdjoke : Command2 {
            public override string name { get { return "joke"; } }
            public override string shortcut { get { return "lol"; }}
            public override string type { get { return "other"; } }
            public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        
            public override void Use(Player p, string message) {
            string result = null;
                using (WebClient client = new WebClient()) {
                    string url = "http://v2.jokeapi.dev/joke/Any?blacklistFlags=religious,racist,sexist&format=txt";
                    result = client.DownloadString(url);

                p.Message(result);
            }
            }

            public override void Help(Player p) {
                p.Message("%T/joke %S- its for the shits and giggles");
        }
    }
}
