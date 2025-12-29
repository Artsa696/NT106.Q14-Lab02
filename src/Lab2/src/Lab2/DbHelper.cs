using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab2
{
    public static class DbHelper
    {
        private static string DataFile => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
        private static readonly object fileLock = new object();

        private record NguoiDungRecord(int IDNCC, string HoVaTen, string QuyenHan);
        private record MonAnRecord(int IDMA, string TenMonAn, string HinhAnh, int IDNCC);
        private record DbFileData(List<NguoiDungRecord> Users, List<MonAnRecord> Foods);

        public static void InitDatabase()
        {
            lock (fileLock)
            {
                if (!File.Exists(DataFile))
                {
                    var data = new DbFileData(new List<NguoiDungRecord>(), new List<MonAnRecord>());
                    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(DataFile, json);
                }
            }
        }

        private static DbFileData ReadData()
        {
            lock (fileLock)
            {
                if (!File.Exists(DataFile))
                {
                    return new DbFileData(new List<NguoiDungRecord>(), new List<MonAnRecord>());
                }
                var json = File.ReadAllText(DataFile);
                try
                {
                    var data = JsonSerializer.Deserialize<DbFileData>(json);
                    return data ?? new DbFileData(new List<NguoiDungRecord>(), new List<MonAnRecord>());
                }
                catch
                {
                    return new DbFileData(new List<NguoiDungRecord>(), new List<MonAnRecord>());
                }
            }
        }

        private static void WriteData(DbFileData data)
        {
            lock (fileLock)
            {
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(DataFile, json);
            }
        }

        public static void InsertNguoiDung(int id, string hoVaTen, string quyenHan)
        {
            var data = ReadData();
            var users = data.Users;
            var existing = users.FirstOrDefault(u => u.IDNCC == id);
            if (existing != null)
            {
                users.RemoveAll(u => u.IDNCC == id);
            }
            users.Add(new NguoiDungRecord(id, hoVaTen ?? string.Empty, quyenHan ?? string.Empty));
            WriteData(new DbFileData(users, data.Foods));
        }

        public static void InsertMonAn(int id, string ten, string hinhAnh, int idNcc)
        {
            var data = ReadData();
            var foods = data.Foods;
            foods.RemoveAll(f => f.IDMA == id);
            foods.Add(new MonAnRecord(id, ten ?? string.Empty, hinhAnh ?? string.Empty, idNcc));
            WriteData(new DbFileData(data.Users, foods));
        }

        public static List<(int IDMA, string TenMonAn, string HinhAnh, int IDNCC, string HoVaTen)> LoadMonAnWithNguoiDung()
        {
            var data = ReadData();
            var users = data.Users.ToDictionary(u => u.IDNCC, u => u.HoVaTen);
            var list = new List<(int, string, string, int, string)>();
            foreach (var f in data.Foods)
            {
                users.TryGetValue(f.IDNCC, out var hovat);
                list.Add((f.IDMA, f.TenMonAn, f.HinhAnh, f.IDNCC, hovat ?? string.Empty));
            }
            return list;
        }

        public static (int IDMA, string TenMonAn, string HinhAnh, int IDNCC, string HoVaTen)? GetRandomMonAn()
        {
            var items = LoadMonAnWithNguoiDung();
            if (items.Count == 0) return null;
            var rnd = new Random();
            return items[rnd.Next(items.Count)];
        }

        public static List<(int IDNCC, string HoVaTen, string QuyenHan)> LoadNguoiDung()
        {
            var data = ReadData();
            var list = new List<(int, string, string)>();
            foreach (var u in data.Users)
            {
                list.Add((u.IDNCC, u.HoVaTen, u.QuyenHan));
            }
            return list;
        }

        public static int GetNextUserId()
        {
            var data = ReadData();
            if (data.Users.Count == 0) return 1;
            return data.Users.Max(u => u.IDNCC) + 1;
        }
    }
}
