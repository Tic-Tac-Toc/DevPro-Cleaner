using DevProCleaner.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevProCleaner
{
    public class Cleaner
    {
        public string[] files;

        public Cleaner()
        {
            LoadFiles();
            Console.WriteLine("Scripts loaded (" + files.Count() + " scripts).");
        }

        private void LoadFiles()
        {
            files = Directory.GetFiles(Path.Combine(Program.path, "script"));
        }

        public void Clean()
        {
            int i = 1;
            int d = 0;
            foreach (var script in files)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("\rCleaning : " + i + "/" + files.Count() + ". Deleted : " + d + " scripts.");
                int id = GetScriptId(script);
                if (id != -1)
                {
                    if (!CardManager.ContainsCard(id))
                    {
                        File.Delete(Path.Combine(Program.path, "script", script));
                        d++;
                    }
                }
                i++;
            }
        }

        private int GetScriptId(string s)
        {
            s = Path.GetFileName(s);
            string[] parts = s.Split('.');
            int id;
            if (parts[0].Length < 1)
                return -1;
            if (!int.TryParse(parts[0].Substring(1).Trim(), out id))
                return -1;
            return id;
        }
    }
}
