namespace FileSaver;
public class DataManager
{
    string fileName;
    public DataManager(string fileName)
    {
        this.fileName = fileName;
        File.Create(this.fileName).Close();
    }
    public void AppendLine(string line)
    {
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }
}
