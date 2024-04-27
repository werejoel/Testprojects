using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // A List of tracks
        List<Track> tracks = new List<Track>();

        // Loop which will prompt the user to enter the track details until they stop
        while (true)
        {
            Console.WriteLine("Enter Track Details (weight and Destination), or type 'stop' to finish");

            // Read user input and Check if the user wants to stop
            string input = Console.ReadLine();
            if (input.ToLower() == "stop")
                break;

            // Split the input into weight and destination
            string[] parts = input.Split(' ');

            // checking the validation
            if (parts.Length != 2)
            {
                Console.WriteLine("Invalid input format. Please enter weight separated with a space");
                continue;
            }

            // Parse weight
            if (!int.TryParse(parts[0], out int weight))
            {
                Console.WriteLine("Invalid weight: Please enter a valid integer");
                continue;
            }

            // Using Add function to add tracks to  the track to the list
            tracks.Add(new Track(weight, parts[1]));
        }

        // Calculating total weight of all tracks
        int Totalweight = 0;
        foreach (Track track in tracks)
        {
            Totalweight += track.Weight;
        }
        // Output summary of the Details
        Console.WriteLine($"Summary of Loaded tracks: ");
        Console.WriteLine($"Total Number of Tracks: {tracks.Count}");
        Console.WriteLine($"Total weight of tracks: {Totalweight} ");
        Console.WriteLine($"Destination");

        // Dictionary to store weight per destination
        Dictionary<string, int> destinationWeight = new Dictionary<string, int> ();
        // Calculate weight per destination
        foreach (Track track in tracks)
        {
            if (destinationWeight.ContainsKey(track.Destination))
            {
                destinationWeight[track.Destination] += track.Weight;
            }
            else
            {
                destinationWeight[track.Destination] = track.Weight;
            }
        }

        // Output weight per destination
        foreach (var entry in destinationWeight)
        {
            Console.WriteLine($"- {entry.Key}: {entry.Value}");
        }

    }
}

//class Track 
class Track
{
    // Instance variables
    public int Weight { get; set; }
    public string Destination { get; set; }

    // Constructor to initialize our track class
    public Track(int weight, string destination)
    {
        // Checking  if weight is positive
        if (weight <= 0)
        {
            throw new ArgumentException("Weight must be a positive integer!");
        }
        Weight = weight;
        Destination = destination;
    }
}



