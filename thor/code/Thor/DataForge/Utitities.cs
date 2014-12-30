using System;
using System.IO;
using System.Collections.Generic;

namespace Thor.DataForge
{

public class Utilities
{
    private static Logger m_Logger = new Logger();

    public static Logger Log
    {
        get
        {
            return m_Logger;
        }
    }

    public static string TrimQuotes(string str)
    {
        if (str.Length > 2)
            return str.Substring(1, str.Length - 2);
        else
            return "";
    }

    public static string AddQuotes(string str)
    {
        return string.Format("\"{0}\"", str);
    }

    public static string GetRelativePath(string path, string relativeTo, string newExt)
    {
        Uri fromUri = new Uri(relativeTo + "\\");
        Uri toUri = new Uri(path);

        Uri relativeUri = fromUri.MakeRelativeUri(toUri);
        String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

        path = relativePath.Replace('/', Path.DirectorySeparatorChar);

        if (newExt != null)
            path = Path.ChangeExtension(path, newExt);

        return path;
    }

    public static T GetOption<T>(List<Option> options) where T : Option
    {
        if (options == null)
            return null;

        foreach(var o in options)
        {
            T t = o as T;
            if (t != null)
                return t;
        }

        return null;
    }
}

public class Logger
{
    private StreamWriter log = new StreamWriter(Console.OpenStandardOutput());

    void RedirectStream(Stream st)
    {
        log = new StreamWriter(st);
    }

    public void Write(string text)
    {
        log.Write(text);
        log.Flush();
    }

    public void WriteLine(string text)
    {
        log.WriteLine(text);
        log.Flush();
    }

    public void RedirectStream(string file)
    {
        log = new StreamWriter(file);
    }

    public void WriteLine(object obj)
    {
        log.WriteLine(obj);
        log.Flush();
    }

    public void PrintExceptionInfo(Exception e)
    {
        WriteLine(e.Message);
        //WriteLine(e.StackTrace);
    }
}

}