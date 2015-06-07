using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    /// <summary>
    /// There is a Mapping for each App we support (and the users can create mappings)
    /// The mapping transforms the event that comes from the Arduino to a Keystroke.
    /// </summary>
    public class Mapping
    {
        public String AppName { get; private set; }

        private Dictionary<EventType, String> mapping;

        public Mapping()
            : this("")
        { }

        public Mapping(String appName)
        {
            this.AppName = appName;
            this.mapping = new Dictionary<EventType, string>();
        }

        public static Mapping ByName(String name)
        {
            Mapping m = new Mapping(name);
            m.Load();
            return m;
        }

        public static string[] GetAvailableMappings()
        {
            string[] files = Directory.GetFiles("config");
            List<String> mappings = new List<string>();
            Regex mappingNameRegex = new Regex(@"^[\w\d_]+$");
            foreach (string filename in files)
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line = sr.ReadLine();
                    if (mappingNameRegex.IsMatch(line))
                        mappings.Add(line);
                }
            }
            return mappings.ToArray();
        }

        private void Load()
        {
            string path = @"config\";
            if (AppName == null)
            {
                Console.WriteLine("AppName is not set. Can't read from file.\n");
            }
            path += AppName.ToLower().Replace(' ', '_') + ".conf";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    if (sr.ReadLine() != this.AppName)
                    {
                        throw new Exception("Inconsistent Mapping object.");
                    }
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.Length == 0) continue;
                        string[] parts = line.Split(new char[] { '=' });
                        if (parts.Length != 2)
                        {
                            throw new Exception("Bad format in config file");
                        }
                        string eventName = parts[0];
                        string action = parts[1];
                        EventType type = EventType.INVALID;
                        try
                        {
                            type = (EventType)Enum.Parse(typeof(EventType), eventName, true);
                        }
                        catch (ArgumentException)
                        {
                            // eventName is invalid.
                            continue;
                        }
                        if (type != EventType.INVALID) mapping.Add(type, action);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public bool SaveToFile()
        {
            string path = @"config\";
            path += AppName.ToLower().Replace(' ', '_') + ".conf";
            if (File.Exists(path))
            {
                // TODO ask for overwriting
                DialogResult result = MessageBox.Show("Já existe uma configuração com este nome, deseja substituir?", "Confirme", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.No:
                        return false;
                    case DialogResult.Yes:
                        break;
                }
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(this.AppName);
                foreach (KeyValuePair<EventType, String> item in mapping)
                {
                    sw.WriteLine("{0}={1}", item.Key.ToString(), item.Value);
                }
                sw.Flush();
            }
            return true;
        }

        public String GetAction(EventType ev)
        {
            string result;
            if (mapping.TryGetValue(ev, out result))
            {
                return result;
            }
            else return null;
        }

        public void AddAction(EventType t, String command)
        {
            if (mapping.Keys.Contains<EventType>(t))
                mapping[t] = command;
            else mapping.Add(t, command);
        }
    }

}
