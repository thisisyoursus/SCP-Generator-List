using System;
using Exiled.Loader;
using Exiled.API.Features;
using RueI.Displays;
using RueI.Elements;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace Generator_List_for_SCPs
{
    public class Main:Plugin<Config>
    {
        public static Main Instance;
        public override string Author => "HyperBeast";
        public override string Name => "079GeneratorList";
        public override Version Version => new Version(1,0,0);
        public override Version RequiredExiledVersion => new Version(9, 1, 1);
        public override void OnEnabled()
        {
            Instance = this;
            AutoElement DisplayText = new AutoElement(RueI.Displays.Roles.Scps, new DynamicElement(Text, Main.Instance.Config.Vertical))
            {
                UpdateEvery = new AutoElement.PeriodicUpdate(TimeSpan.FromSeconds(1))
            };
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
        internal static string Text(DisplayCore Core)
        {
            Log.Info("Entered Text Function");
            StringBuilder broadcast = new StringBuilder();
            broadcast.Append($"<align={Main.Instance.Config.Horizontal.ToLower()}><size={Main.Instance.Config.Size}><b><color={Main.Instance.Config.Color.ToLower()}>Generator List:</color></b></size></align>");
            int EnabledGenerators = 0;
            int i = 1;
            
            foreach (Generator generator in Generator.List)
                if (generator.IsActivating)
                {
                    string Room = generator.Room.Name;
                    Room=Room.Replace('_', ' ');
                    Room=Room.Replace("(Clone)"," ");
                    broadcast.Append($"<align={Main.Instance.Config.Horizontal.ToLower()}><size={Main.Instance.Config.Size}><b><color={Main.Instance.Config.Color.ToLower()}>\n\tGenerator {i}:\n\t\tLocation:</color></b>{Room}<b><color={Main.Instance.Config.Color.ToLower()}>Time Left:</color></b>{generator.CurrentTime}</size></align>");
                    i++;
                    EnabledGenerators++;
                }
            if (EnabledGenerators == 0)
                return "";
            return broadcast.ToString();
        }
    }
}
