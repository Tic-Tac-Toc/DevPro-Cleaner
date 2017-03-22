using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevProCleaner.Database
{
    public static class CardManager
    {
        private static List<int> CardData = new List<int>();

        private static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic,
                              TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }

        public static bool LoadCDB(string dir, bool overwrite, bool clearData = false)
        {
            if (!File.Exists(dir))
                return false;

            if (clearData)
                CardData.Clear();

            SQLiteConnection connection = new SQLiteConnection("Data Source=" + dir);
            List<string[]> datas = new List<string[]>();

            try
            {
                connection.Open();
                datas = LoadData(connection);
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }

            foreach (string[] row in datas)
            {
                if (overwrite)
                    CardManager.UpdateOrAddCard(Int32.Parse(row[0]));
                else
                {
                    if (!CardManager.ContainsCard(Int32.Parse(row[0])))
                        CardManager.UpdateOrAddCard(Int32.Parse(row[0]));
                }
            }

            return true;
        }

        public static bool ContainsCard(int id)
        {
            return CardData.Contains(id);
        }

        public static int CardsCount()
        {
            return CardData.Count;
        }

        public static void UpdateOrAddCard(int id)
        {
            if (ContainsCard(id))
                return;
            else
                CardData.Add(id);
        }

        public static List<string[]> LoadData(SQLiteConnection connection)
        {
            SQLiteCommand datacommand = new SQLiteCommand("SELECT id FROM datas", connection);
            return DatabaseHelper.ExecuteStringCommand(datacommand, 11);
        }
    }
}