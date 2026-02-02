namespace BusShuttle;
public class DataManager {
    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; }
    FileSaver fileSaver;
    public DataManager() {
        fileSaver = new FileSaver("passenger-data.txt");
        
        Loops = new List<Loop>();
        Loops.Add(new Loop("Red"));
        Loops.Add(new Loop("Green"));
        Loops.Add(new Loop("Blue"));
        Loops.Add(new Loop("Orange"));
        
        Stops = new List<Stop>();
        var stopsFileContent = File.ReadAllLines("stops.txt");
        foreach(var stopName in stopsFileContent) {
            Stops.Add(new Stop(stopName));
        }

        
        Loops[0].Stops.Add(Stops[0]);
        Loops[0].Stops.Add(Stops[1]);
        Loops[0].Stops.Add(Stops[2]);
        Loops[0].Stops.Add(Stops[3]);
        Loops[0].Stops.Add(Stops[4]);

        Drivers = new List<Driver>();
        Drivers.Add(new Driver("Usual Driver"));
        Drivers.Add(new Driver("Alternate Driver"));
        
        PassengerData = new List<PassengerData>();
        if(File.Exists("passenger-data.txt")) {
            var passengerDataContent = File.ReadAllLines("passenger-data.txt");
            foreach(var line in passengerDataContent) {
                var splitted = line.Split(":",StringSplitOptions.RemoveEmptyEntries);
                var driverName = splitted[0];
                var driver = new Driver(driverName);
                var loopName = splitted[1];
                var loop = new Loop(loopName);
                var stopName = splitted[2];
                var stop = new Stop(stopName);
                var boarded = int.Parse(splitted[3]);
                PassengerData.Add(new PassengerData(boarded,stop,loop,driver));
            }
        }
    }
    public void AddNewPassengerData(PassengerData data) {
        this.PassengerData.Add(data);
        this.fileSaver.AppendData(data);
    }

    public void SynchronizeStops() {
        File.Delete("stops.txt");
        foreach(var stop in Stops) {
            File.AppendAllText("stops.txt",stop.Name+Environment.NewLine);
        }
    }
    public void AddStop(string newStopName) {
        this.Stops.Add(new Stop(newStopName));
        this.SynchronizeStops();
    }
    public void RemoveStop(Stop toRemove) {
        this.Stops.Remove(toRemove);
        this.SynchronizeStops();
    }

}
