using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/// <summary>Almacén simple de usuarios en App_Data/users.txt (usuario|correo|salt|hash).</summary>
public static class UserStore
{
    static readonly object _lock = new object();
    static string FilePath { get { return HttpContext.Current.Server.MapPath("~/App_Data/users.txt"); } }

    public static string Hash(string password, string salt)
    {
        using (var kdf = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000))
            return Convert.ToBase64String(kdf.GetBytes(32));
    }

    public static string NewSalt()
    {
        var b = new byte[16];
        using (var rng = new RNGCryptoServiceProvider()) rng.GetBytes(b);
        return Convert.ToBase64String(b);
    }

    public static bool Exists(string user)
    {
        lock (_lock)
        {
            if (!File.Exists(FilePath)) return false;
            return File.ReadAllLines(FilePath).Any(l => l.Split('|')[0].Equals(user, StringComparison.OrdinalIgnoreCase));
        }
    }

    public static void Add(string user, string email, string password)
    {
        string salt = NewSalt();
        lock (_lock)
            File.AppendAllText(FilePath, string.Join("|", user, email, salt, Hash(password, salt)) + Environment.NewLine);
    }

    public static bool Validate(string user, string password)
    {
        lock (_lock)
        {
            if (!File.Exists(FilePath)) return false;
            foreach (var l in File.ReadAllLines(FilePath))
            {
                var p = l.Split('|');
                if (p.Length == 4 && p[0].Equals(user, StringComparison.OrdinalIgnoreCase))
                    return p[3] == Hash(password, p[2]);
            }
        }
        return false;
    }
}
