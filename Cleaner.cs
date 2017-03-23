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
        public string[] scriptfiles;
        public string[] picsfiles;
        public string[] thumbnailfiles;
        public string[] fieldfiles;

        public Cleaner()
        {
            LoadFiles();
            Console.WriteLine("Scripts loaded (" + scriptfiles.Count() + " scripts).");
            Console.WriteLine("Pics loaded (" + picsfiles.Count() + " pics).");
        }

        private void LoadFiles()
        {
            scriptfiles = Directory.GetFiles(Path.Combine(Program.path, "script"));
            picsfiles = Directory.GetFiles(Path.Combine(Program.path, "pics"));
            thumbnailfiles = Directory.GetFiles(Path.Combine(Program.path, "pics", "thumbnail"));
            fieldfiles = Directory.GetFiles(Path.Combine(Program.path, "pics", "field"));
        }

        public void Clean()
        {
            CleanScript();
            CleanPics();
            CleanThumbnail();
            CleanField();
        }

        private void CleanScript()
        {
            Console.WriteLine("");
            int i = 1;
            int d = 0;
            foreach (var script in scriptfiles)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("\rCleaning : " + i + "/" + scriptfiles.Count() + ". Deleted : " + d + " scripts.");
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

        private void CleanPics()
        {
            Console.WriteLine("");
            int i = 1;
            int d = 0;
            foreach (var pics in picsfiles)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("\rCleaning : " + i + "/" + picsfiles.Count() + ". Deleted : " + d + " pics.");
                int id = GetPicId(pics);
                if (id != -1)
                {
                    if (!CardManager.ContainsCard(id))
                    {
                        File.Delete(Path.Combine(Program.path, "pics", pics));
                        d++;
                    }
                }
                i++;
            }
        }

        private void CleanThumbnail()
        {
            Console.WriteLine("");
            int i = 1;
            int d = 0;
            foreach (var pics in thumbnailfiles)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("\rCleaning : " + i + "/" + thumbnailfiles.Count() + ". Deleted : " + d + " thumbnail pics.");
                int id = GetPicId(pics);
                if (id != -1)
                {
                    if (!CardManager.ContainsCard(id))
                    {
                        File.Delete(Path.Combine(Program.path, "pics", "thumbnail", pics));
                        d++;
                    }
                }
                i++;
            }
        }

        private void CleanField()
        {
            Console.WriteLine("");
            int i = 1;
            int d = 0;
            foreach (var pics in fieldfiles)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("\rCleaning : " + i + "/" + fieldfiles.Count() + ". Deleted : " + d + " field pics.");
                int id = GetPicId(pics);
                if (id != -1)
                {
                    if (!CardManager.ContainsCard(id))
                    {
                        File.Delete(Path.Combine(Program.path, "pics", "field", pics));
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

        private int GetPicId(string s)
        {
            s = Path.GetFileName(s);
            string[] parts = s.Split('.');
            int id;
            if (parts[0].Length < 1)
                return -1;
            if (!int.TryParse(parts[0], out id))
                return -1;
            return id;
        }
    }
}
