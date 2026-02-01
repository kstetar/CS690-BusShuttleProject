namespace BusShuttle.Tests;

using BusShuttle;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests() {
        testFileName = "test-doc.txt";
        fileSaver = new FileSaver(testFileName);
    }

    [Fact]
    public void Test_FileSaver_Append()
    {
        fileSaver.AppendLine("Hello, World!");
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal(contentFromFile,"Hello, World!"+Environment.NewLine);
    }
    [Fact]
    public void Test_FileSaver_AppendData()
    {
        Stop sampleStop = new Stop("MyStop");
        Loop sampleLoop = new Loop("MyLoop");
        Driver sampleDriver = new Driver("Sample");
        PassengerData sampleData = new PassengerData(5,sampleStop,sampleLoop,sampleDriver);
        fileSaver.AppendData(sampleData);
        var contentFromFile = File.ReadAllText(testFileName);
        Assert.Equal(contentFromFile,"Sample:MyLoop:MyStop:5"+Environment.NewLine);
    }

}