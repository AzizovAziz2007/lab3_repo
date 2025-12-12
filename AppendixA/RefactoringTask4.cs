using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.AppendixA
{
    public class RefactoringTask4
    {
        // 1) Дублирование кода в if/else

        /*БЫЛО:
        private void set_mode(bool mod)
        {
            if (mod == true)
            {
                label1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                label1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }*/

        // СТАЛО:
        public void SetMode(bool isActive)
        {
            label1.Enabled = isActive;
            button1.Enabled = isActive;
            button2.Enabled = isActive;

            button3.Enabled = !isActive;
            button4.Enabled = !isActive;
        }


        // 2) Switch case с повторяющимися return

        /*БЫЛО:
        switch (driver.Status)
        {
            case ClientStatus.Unknown:
                return m_driverStatusNames[ClientStatus.Unknown];
            case ClientStatus.Free:
                return m_driverStatusNames[ClientStatus.Free];
            case ClientStatus.Busy:
                return m_driverStatusNames[ClientStatus.Busy];
            case ClientStatus.InWay:
                return m_driverStatusNames[ClientStatus.InWay];
            case ClientStatus.Work:
                return m_driverStatusNames[ClientStatus.Work];
            case ClientStatus.Break:
                return m_driverStatusNames[ClientStatus.Break];
            case ClientStatus.Alarm:
                return m_driverStatusNames[ClientStatus.Alarm];
        }*/

        // СТАЛО:
        public string GetStatusName(ClientStatus status)
        {
            return m_driverStatusNames.ContainsKey(status) ? m_driverStatusNames[status] : "Unknown";
        }


        // 3) Проверка на одну цифру через строку

        /*БЫЛО:
        uint i;
        …
        if (i.ToString().Length == 1)
        {
            ...
        }*/

        // СТАЛО:
        public void CheckSingleDigit(uint i)
        {
            if (i < 10)
            {
                // логика
            }
        }


        // 4) Конкатенация строк в цикле

        /*БЫЛО:
        string destination = null;
        for (int i = 0; i < 13; i++)
            destination += source[i];
        */

        // СТАЛО:
        public string BuildString(char[] source)
        {
            return new string(source, 0, Math.Min(source.Length, 13));
        }


        // 5) Проверка на число через Replace

        /*БЫЛО:
        Bool IsNumber (string str) {
            return (str.Replace ("0", "").Replace ("1", "").Replace ("2", "").Replace 
            ("3", "").Replace ("4", "").Replace ("5", "").Replace ("6", "").Replace 
            ("7", "").Replace ("8", "").Replace ("9", "").Length == 0);
        }*/

        // СТАЛО:
        public bool IsNumber(string str)
        {
            return !string.IsNullOrEmpty(str) && str.All(char.IsDigit);
        }


        // 6) Сложный foreach с сетевой логикой

        /*БЫЛО:
        foreach (DirectoryInfo dir in dirs.GetDirectories())
        {
            //create folder{16}
            stream.Write(new byte[] { (byte)NetworkMessage.MakeDir }, 0, 1);
            stream.Read(new byte[1],0, 1);

            stream.Write(BitConverter.GetBytes(Encoding.UTF8.GetBytes(
            SubFolder.Replace('\\', '/') + dir.Name.Replace('\\', '/')).Length), 0, 4);
            stream.Write(Encoding.UTF8.GetBytes(SubFolder.Replace('\\', '/') +
                dir.Name.Replace('\\', '/')),0,
                         Encoding.UTF8.GetBytes(SubFolder.Replace('\\', '/') +
                dir.Name.Replace('\\', '/')).Length);
                //send folder name
                stream.Read(new byte[1], 0, 1);//Ok
        }*/

        // СТАЛО:
        public void ProcessDirectories(IEnumerable<DirectoryInfo> directories, Stream stream)
        {
            foreach (var dir in directories)
            {
                SendDirectoryInfo(stream, dir);
            }
        }

        private void SendDirectoryInfo(Stream stream, DirectoryInfo dir)
        {
            string path = dir.Name.Replace('\\', '/');
            byte[] data = Encoding.UTF8.GetBytes(path);

            stream.Write(data, 0, data.Length);
            // ... чтение подтверждения ...
        }


        // 7) Switch для дней недели

        /*БЫЛО:
        String[] days = new String[7];
        for( int i = 0; i < 7; i++ ) {
            switch(i) {
                case 0: days[i] = "Monday"; break;
                case 1: days[i] = "Tuesday"; break;
                ...
                case 6: days[i] = "Sunday"; break;
            }
        }*/

        // СТАЛО:
        public void InitDays()
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        }


        // 8) Ручное форматирование времени

        /*БЫЛО:
        DateTime dt = DateTime.Now;
        string h=dt.Hour.ToString().PadLeft(2,'0'); 
        string m=dt.Minute.ToString().PadLeft(2,'0'); 
        string s=dt.Second.ToString().PadLeft(2,'0');
        Console.WriteLine("--"+h+":"+m+":"+s+"--");
        */

        // СТАЛО:
        public void PrintTime()
        {
            Console.WriteLine($"--{DateTime.Now:HH:mm:ss}--");
        }


        // 9) Странная проверка на нечетность/дробность

        /*БЫЛО:
        return ((int)(Counter / 2) != Counter / 2.00 && Counter != 0);
        */

        // СТАЛО:
        public bool IsOdd(int counter)
        {
            return counter != 0 && counter % 2 != 0;
        }


        // 10) Лишний else и дублирование

        /*БЫЛО:
        if (Connected == 0))
        {
            rez = setup();
            fl_end = true; // выход
        }
        else
            fl_end = true;
        */

        // СТАЛО:
        public void CheckConnection()
        {
            if (Connected == 0)
            {
                rez = Setup();
            }
            fl_end = true;
        }


        // 11) Пустой блок if

        /*БЫЛО:
        if (arr[i] > 100)
        {
        }
        else
            tmpArr.Add(arr[i]);
        */

        // СТАЛО:
        public List<int> FilterList(List<int> arr)
        {
            return arr.Where(x => x <= 100).ToList();
        }


        // 12) Проверка длины массива

        /*БЫЛО:
        var ids = form.Keys;
        if(ids.Length == 0 || ids.Length > 1) { throw Exception;}
        */

        // СТАЛО:
        public void CheckIds(string[] ids)
        {
            if (ids.Length != 1)
                throw new Exception("Expected exactly one ID");
        }


        // 13) Ручной парсинг имени

        /*БЫЛО:
        string[] nameParts = customer.Name.Split(' ');
        string firstName = nameParts[0];
        string lastName = customer.Name.Replace(nameParts[0], "").TrimStart(' ');
        */

        // СТАЛО:
        public void ParseName(string fullName)
        {
            var parts = fullName.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            string firstName = parts.Length > 0 ? parts[0] : "";
            string lastName = parts.Length > 1 ? parts[1] : "";
        }


        // 14) Foreach с break на первой итерации

        /*БЫЛО:
        foreach (string id in sourceIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            sourceId = Convert.ToInt32(id);
            break;
        }
        */

        // СТАЛО:
        public void GetFirstId(string sourceIDs)
        {
            string firstId = sourceIDs.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
            if (firstId != null)
            {
                sourceId = Convert.ToInt32(firstId);
            }
        }


        // 15) Генерация Email (массивы char, ручное копирование)

        /*БЫЛО:
        int i = PersonName.IndexOf(" ");
        char[] str1 = new char[i];
        PersonName.CopyTo(0, str1, 0, i);
        ...
        res += "@domain.ua";
        */

        // СТАЛО:
        public string GenerateEmail(string personName)
        {
            string cleanName = personName.Replace(" ", ".");
            if (cleanName.Length > 20)
                cleanName = cleanName.Substring(0, 20);
            return $"{cleanName}@domain.ua";
        }


        // 16) Дубликат примера 14

        /*БЫЛО:
        foreach (string id in sourceIDs.Split(...))
        {
            sourceId = Convert.ToInt32(id);
            break;
        }
        */

        // СТАЛО:
        // (См. решение пункта 14)


        // 17) GetTextDiv2 (Магические числа 5000)

        /*БЫЛО:
        int mid = text.Length / 2;
        int r = text.IndexOf(" ", mid); if (r < 0) r = 5000;
        int l = text.IndexOf(" ", 0, mid); if (l < 0) l = 5000;
        if (r - mid > mid - l) mid = l; else mid = r;
        if (mid == 5000) ...
        */

        // СТАЛО:
        public string InsertBreakClean(string text)
        {
            int mid = text.Length / 2;
            int right = text.IndexOf(' ', mid);
            int left = text.LastIndexOf(' ', mid);

            if (left == -1 && right == -1) return "&nbsp" + text;

            int splitIndex;
            if (left == -1) splitIndex = right;
            else if (right == -1) splitIndex = left;
            else splitIndex = (right - mid < mid - left) ? right : left;

            return "&nbsp" + text.Substring(0, splitIndex) + " <br/>&nbsp" + text.Substring(splitIndex);
        }


        // 18) Static readonly массивы char

        /*БЫЛО:
        private static readonly char SPECIFIER = "$"[0];
        private static readonly char DELIMITER = ":"[0];
        private static readonly char[] DELIMITER_ARRAY = new char[1] { DELIMITER };
        */

        // СТАЛО:
        private const char Specifier = '$';
        private const char Delimiter = ':';
        private static readonly char[] DelimiterArray = { Delimiter };


        // 19) Сложное чтение конфига (Тернарный оператор)

        /*БЫЛО:
        string mailTo = ((Config.GetSetting("AdminNotifications_EmailAddress") == null) ||
        (Config.GetSetting("AdminNotifications_EmailAddress").Length <= 0))? 
        Globals.GetHostPortalSettings().HostSettings["SMTPPassword"].ToString(): 
        Config.GetSetting("AdminNotifications_EmailAddress");
        */

        // СТАЛО:
        public string GetEmailConfig()
        {
            string email = Config.GetSetting("AdminNotifications_EmailAddress");
            if (string.IsNullOrEmpty(email))
            {
                return Globals.GetHostSettings("SMTPPassword");
            }
            return email;
        }


        // 20) 20 проверок if (CheckPath)

        /*БЫЛО:
        if (Directory.Exists(path + "SCLAD")) { n += 1; }
        if (Directory.Exists(path + "REAL")) { n += 1; }
        ... (еще 18 if) ...
        if (n == 20) { return true; }
        */

        // СТАЛО:
        public bool CheckPathFull(string path)
        {
            var requiredItems = new List<string>
            {
                "SCLAD", "REAL", "DOSTAVKA", "analit.dbf", "partner.dbf",
                Path.Combine("SCLAD", "mdoc.dbf") 
                // ... (и так далее все 20 файлов)
            };

            int foundCount = requiredItems.Count(item =>
                File.Exists(Path.Combine(path, item)) || Directory.Exists(Path.Combine(path, item)));

            return foundCount == requiredItems.Count;
        }


        // 21) Сборка CSV строки вручную

        /*БЫЛО:
        txtContacts.Text = "";
        bool first = true;

        foreach (string contact in contacts)
        {
            if (first != true) txtContacts.Text += ";";
            first = false;
            txtContacts.Text += contact;
        }
        */

        // СТАЛО:
        public void JoinContacts(List<string> contacts)
        {
            txtContacts.Text = string.Join(";", contacts);
        }


        // 22) Инверсия boolean (if true then false)

        /*БЫЛО:
        if (Game1.clou == true)
            {Game1.clou = false;}
        else
            { Game1.clou = true; }
        */

        // СТАЛО:
        public void ToggleClou()
        {
            Game1.clou = !Game1.clou;
        }

        // Заглушки для компиляции
        public dynamic label1, button1, button2, button3, button4, txtContacts;
        public Dictionary<ClientStatus, string> m_driverStatusNames;
        public int Connected, rez;
        public bool fl_end;
        public int sourceId;
        public dynamic Config, Globals, Game1;
        public enum ClientStatus { Unknown, Free }
        public int Setup() { return 1; }
    }
}