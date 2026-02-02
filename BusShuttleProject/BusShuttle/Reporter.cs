namespace BusShuttle;
public class Reporter 
{
    public static Stop FindBusiestStop(List<PassengerData> data) {
        Dictionary<string, int> passengerCountsPerStop = new Dictionary<string, int>();
        
        // Build the count structure
        foreach(var piece in data) {
            if(!passengerCountsPerStop.ContainsKey(piece.Stop.Name)) {
                passengerCountsPerStop.Add(piece.Stop.Name, 0);
            }
            passengerCountsPerStop[piece.Stop.Name] += piece.Boarded;
        }
        // Find the highest
        String highestStop = null;
        int highest = -1;
        foreach(var stopCountPair in passengerCountsPerStop) {
            if(stopCountPair.Value>highest) {
                highest = stopCountPair.Value;
                highestStop = stopCountPair.Key;
            }
        }
        return new Stop(highestStop);
    }
}
