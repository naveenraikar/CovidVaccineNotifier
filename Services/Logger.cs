namespace CovidVaccineNotifier.Service
{
  using System;
  using System.IO;

  public class Logger
  {
    private static Logger instance = new Logger();

    private readonly string path = Directory.GetCurrentDirectory() + "\\log.txt";
    private readonly string errorPath = Directory.GetCurrentDirectory() + "\\errors.txt";

    private Logger() { }

    public static Logger Instance
    {
      get
      {
        return instance;
      }
    }

    public void Log(string contents)
    {
      var date = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:tt");
      contents = $"{date} : {contents}{Environment.NewLine}";
      Log(path, contents);
    }

    public void LogExeption(string exeption)
    {
      var date = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:tt");
      exeption = $"Exeption occurred on {date} : {Environment.NewLine}  {exeption}";
      Log(errorPath, exeption);
    }

    private void Log(string path, string text)
    {
      try
      {
        File.WriteAllText(path, text);
      }
      catch { }
    }
  }
}