namespace BusShuttle.Tests;
using BusShuttle;
public class ReporterTests
{
    List<PassengerData> sampleData;
    public ReporterTests() {
        sampleData = new List<PassengerData>();
    }
    [Fact]
    public void Test_FindBusiestStop_Just2stops()
    {
        sampleData.Add(new PassengerData(4,new Stop("MyStop"),new Loop("MyLoop"),new Driver("MyDriver")));
        sampleData.Add(new PassengerData(5,new Stop("MyStop2"),new Loop("MyLoop2"),new Driver("MyDriver2")));
        var result = Reporter.FindBusiestStop(sampleData);
        Assert.Equal("MyStop2",result.Name);
    }

    [Fact]
    public void Test_FindBusiestStop_Just2stops_MoreData()
    {
        sampleData.Add(new PassengerData(4,new Stop("MyStop"),new Loop("MyLoop"),new Driver("MyDriver")));
        sampleData.Add(new PassengerData(5,new Stop("MyStop2"),new Loop("MyLoop2"),new Driver("MyDriver2")));
        sampleData.Add(new PassengerData(2,new Stop("MyStop"),new Loop("MyLoop"),new Driver("MyDriver")));
        var result = Reporter.FindBusiestStop(sampleData);
        Assert.Equal("MyStop",result.Name);
    }

}
