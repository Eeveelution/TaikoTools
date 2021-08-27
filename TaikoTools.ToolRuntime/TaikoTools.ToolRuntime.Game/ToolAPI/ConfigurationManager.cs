using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaikoTools.ToolRuntime.Game.ToolAPI {
    public class ConfigurationManager {
        private Dictionary<string, string> _configuration;

        private string _filename;

        public ConfigurationManager(string filename) {
            this._filename = filename;

            if (!File.Exists(filename)) {
                File.WriteAllText(filename, "");
            }

            string[] fileData = File.ReadAllLines(filename);

            foreach (string s in fileData) {
                string[] iniSplit = s.Split("=");

                if (iniSplit.Length != 2)
                    throw new Exception("Configuration could not be parsed correctly, most likely corrupt!");

                string key = iniSplit[0];
                string val = iniSplit[1];

                bool success = this._configuration.TryAdd(key, val);

                if (!success)
                    throw new Exception($"Could not add Key {key} to Dictionary, most likely duplicate keys exist.");
            }
        }

        public string Get(string key) {
            bool found = this._configuration.TryGetValue(key, out string outVal);

            return !found ? null : outVal;
        }

        public void Set(string key, string value) {
            if (!this._configuration.ContainsKey(key)) {
                this._configuration.Add(key, value);

                this.Save();

                return;
            }

            this._configuration[key] = value;
        }

        public void Save() {
            List<string> file = this._configuration.Select(entry => $"{entry.Key}={entry.Value}").ToList();

            File.WriteAllLines(this._filename, file.ToArray());
        }
    }
}
