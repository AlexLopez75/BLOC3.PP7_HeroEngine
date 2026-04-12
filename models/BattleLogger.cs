namespace BLOC3.PP7_HeroEngine.models;

public static class BattleLogger
{
    private const string filePath = "Files/battleLog.txt";
    private const string separator = "======================================================";
    private const string logInitializeMSG = "               BATTLE LOG INITIALIZED              ";
    private const string fileNotFoundMSG = "[ERROR] Flie not found: {0}";
    private const string unableToWriteMSG = "[ERROR] Unable to write into log: {0}";
    
    public static void Initialize()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath, false)) //false lets us rewrite the file.
            {
                sw.WriteLine(separator);
                sw.WriteLine(logInitializeMSG);
                sw.WriteLine(separator);
                sw.WriteLine("");
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(fileNotFoundMSG, ex.Message);
        }
    }

    public static void Log(string message)
    {
        Console.WriteLine(message);

        try
        {
            using (StreamWriter sw = new StreamWriter(filePath, true)) //true lets us add text without rewriting the file.
            {
                sw.WriteLine(message);
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(unableToWriteMSG, ex.Message);
        }
    }
}