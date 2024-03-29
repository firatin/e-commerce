using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Summary description for Kontrol
/// </summary>
public class Kontrol
{
    public Kontrol()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string SiparisTutar(string metin)
    {
        string deger = metin;

        deger = deger.Replace("$", "");
        deger = deger.Replace("TL", "");
        deger = deger.Replace("Tek Çekim: ", "");
        deger = deger.Replace(" TL", "");
        deger = deger.Replace("12 Taksit: ", "");
        deger = deger.Replace("11 Taksit: ", "");
        deger = deger.Replace("10 Taksit: ", "");
        deger = deger.Replace("9 Taksit: ", "");
        deger = deger.Replace("8 Taksit: ", "");
        deger = deger.Replace("7 Taksit: ", "");
        deger = deger.Replace("6 Taksit: ", "");
        deger = deger.Replace("5 Taksit: ", "");
        deger = deger.Replace("4 Taksit: ", "");
        deger = deger.Replace("3 Taksit: ", "");
        deger = deger.Replace("2 Taksit: ", "");
        deger = deger.Replace("1 Taksit: ", "");
       

        return deger;
    }
    public static string ParaBirim(string metin)
    {
        string deger = metin;

        deger = deger.Replace(" Kdv Dahil", "");
        deger = deger.Replace("Kdv Dahil", "");
        deger = deger.Replace("TL", "");
        deger = deger.Replace("$", "");
        deger = deger.Replace("K", "");
        deger = deger.Replace("d", "");
        deger = deger.Replace("v", "");
        deger = deger.Replace("D", "");
        deger = deger.Replace("a", "");
        deger = deger.Replace("h", "");
        deger = deger.Replace("i", "");
        deger = deger.Replace("l", "");
        deger = deger.Replace("T", "");
        deger = deger.Replace("L", "");


        return deger;
    }
    public static string Excel(string metin)
    {
        string deger = metin;

        deger = deger.Replace("&#199;", "Ç");
        deger = deger.Replace("&#252;", "ü");
        deger = deger.Replace("&#246;", "ö");
        deger = deger.Replace("&#231;", "ç");
        deger = deger.Replace("&#220;", "Ü");
        deger = deger.Replace("&#214;", "Ö");
        deger = deger.Replace("&nbsp;", "");
        deger = deger.Replace("Ä±", "ı");



        return deger;
    }
    public static string EmailGirisTemizle(string metin)
    {
        string deger = metin;
        // mailler bu karakterlerden oluşmazlar.
        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("*", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("select", "");
        deger = deger.Replace("insert", "");
        deger = deger.Replace("update", "");
        deger = deger.Replace("delete", "");
        deger = deger.Replace("truncate ", "");
        deger = deger.Replace("char", "");
        deger = deger.Replace("union ", "");
        deger = deger.Replace("script ", "");

        return deger;
    }

    public static string AramaKontrol(string metin)
    {
        string deger = metin;

        deger = deger.Replace("&", "");
        //deger = deger.Replace("-", ""); stok kodunda olabilir diye kaldırdım
        deger = deger.Replace("'", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("=", "");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        //deger = deger.Replace(".", ""); para değerinde var diye kaldırdım
        deger = deger.Replace("“", "");
       // deger = deger.Replace("’", ""); ""      ""
        deger = deger.Replace("‘", "");
        deger = deger.Replace("”", "");
        deger = deger.Replace("--", "");
        deger = deger.Replace("++", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("\"", "");
        deger = deger.Replace("/", "");
        deger = deger.Replace("<>", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("?", "");
        deger = deger.Replace("!", "");
        deger = deger.Replace("<s", "");
        deger = deger.Replace("<S", "");
        deger = deger.Replace("<Script>", "");
        deger = deger.Replace("<Alert>", "");
        deger = deger.Replace("</Script>", "");
        deger = deger.Replace("<script>", "");
        deger = deger.Replace("<script", "");
        deger = deger.Replace("</<script>", "");
        deger = deger.Replace("<alert>", "");
        deger = deger.Replace("\\", "");



        return deger;
    }

    public static string Yonlendirme(string metin)
    {
        string deger = metin;

        deger = deger.Replace("<meta", "*meta");
        deger = deger.Replace("<META", "*META");
        deger = deger.Replace("http-equiv=\"refresh\"", "*");
        deger = deger.Replace("HTTP-EQUIV=\"Refresh\"", "*");
        deger = deger.Replace("CONTENT=\"", "");
        deger = deger.Replace("<script", "*");
        deger = deger.Replace("<SCRIPT", "*");
        deger = deger.Replace("document.location", "*");
        deger = deger.Replace("window.location", "window . location");
        deger = deger.Replace("</script>", "");
        deger = deger.Replace("</SCRIPT>", "");


        return deger;
    }
    public static string Temizle(string metin)
    {
        string deger = metin;

        deger = deger.Replace("'", "");
        deger = deger.Replace("<>", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("-", "");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace(".", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("“", "");
        deger = deger.Replace("’", "");
        deger = deger.Replace("‘", "");
        deger = deger.Replace("”", "");
        deger = deger.Replace("--", "");
        deger = deger.Replace("++", "");
        deger = deger.Replace("?", "");


        return deger;
    }

    public static string UrlSeo(string metin)
    {
        string deger = metin;
        deger = deger.Replace(",", "");
        deger = deger.Replace("!", "");
        deger = deger.Replace(" ", "_");
        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("ı", "i"); // türkçe karakterleri ing karışılı karakterelrde değiştir.
        deger = deger.Replace("ö", "o");
        deger = deger.Replace("ü", "u");
        deger = deger.Replace("ş", "s");
        deger = deger.Replace("ç", "c");
        deger = deger.Replace("ğ", "g");
        deger = deger.Replace("I", "i");// BÜYÜK türkçe karakterlerin ing karışılı karakterelrde değiştir.
        deger = deger.Replace("Ö", "o");
        deger = deger.Replace("Ü", "u");
        deger = deger.Replace("Ş", "s");
        deger = deger.Replace("Ç", "c");
        deger = deger.Replace("Ğ", "g");
        deger = deger.Replace(":", "");
        deger = deger.Replace("İ", "i");
        deger = deger.Replace("-", "_");
        deger = deger.Replace("%", "");
        deger = deger.Replace("+", "");
        deger = deger.Replace("{", "");
        deger = deger.Replace("(", "");
        deger = deger.Replace(".", "");
        deger = deger.Replace("}", "");
        deger = deger.Replace(")", "");
        deger = deger.Replace("/", "");
        deger = deger.Replace("\\", "");
        deger = deger.Replace("“", "");
        deger = deger.Replace("’", "");
        deger = deger.Replace("‘", "");
        deger = deger.Replace("”", "");
        deger = deger.Replace("--", "");
        deger = deger.Replace("++", "");
        deger = deger.Replace("?", "");





        string deger1 = "";

        deger = deger.Replace("" + '"' + deger1 + '"', "_");
        return deger;
    }

    public static string UrlTemizle(string metin)
    {
        string deger = metin;

        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");
        deger = deger.Replace("'a", "");
        deger = deger.Replace("A'", "");
        deger = deger.Replace("ı", "i"); // türkçe karakterleri ing karışılı karakterelrde değiştir.
        deger = deger.Replace("ö", "o");
        deger = deger.Replace("ü", "u");
        deger = deger.Replace("ş", "s");
        deger = deger.Replace("ç", "c");
        deger = deger.Replace("ğ", "g");
        deger = deger.Replace("I", "i");// BÜYÜK türkçe karakterlerin ing karışılı karakterelrde değiştir.
        deger = deger.Replace("Ö", "o");
        deger = deger.Replace("Ü", "u");
        deger = deger.Replace("Ş", "s");
        deger = deger.Replace("Ç", "c");
        deger = deger.Replace("Ğ", "g");
        deger = deger.Replace(" ", "_");
        deger = deger.Replace(",", "_");
        deger = deger.Replace(".", "_");
        deger = deger.Replace(":", "_");
        deger = deger.Replace("?", "_");
        deger = deger.Replace("/", "_");
        deger = deger.Replace("\\", "_");
        deger = deger.Replace("!", "_");
        deger = deger.Replace(",", "");
        deger = deger.Replace(":", "");
        deger = deger.Replace("?", "");
        string deger1 = "";

        deger = deger.Replace("" + '"' + deger1 + '"', "_");
        return deger;
    }
    public static string SayiKontrol(string text)
    {
        try
        {
            int x = Convert.ToInt32(text);

        }
        catch
        {
            text = "0";
        }
        return text;
    }

    public static string OzetCek(string metin, int karakter)
    {
        if (metin.Length >= karakter)
        {
            metin = metin.Substring(0, karakter);
        }
        return metin;
    }

    public static string Md5Sifrele(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    public static string SifreOlustur()
    {
        int length = 10;
        string chars = "aBcDeFgHiJkLmNoPrStUvUzWxQ1234567890+_*\"";

        StringBuilder Password = new StringBuilder();
        Random Rnd = new Random();
        for (int i = 0; i < length; i++)
        {
            Password = Password.Append(chars[Rnd.Next(0, chars.Length)]);
        }

        return Password.ToString();
    }
}