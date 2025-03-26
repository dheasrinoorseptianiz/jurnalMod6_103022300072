// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        playCount += count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + this.id);
        Console.WriteLine("Video Title: " + this.title);
        Console.WriteLine("Video Play Count: " + this.playCount);
    }

    public int GetPlayCount()
    {
        return this.playCount;
    }

    public string GetTitle()
    {
        return this.title;
    }
}

public class  SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadesVideos;
    private String username;

    public SayaTubeUser(String username)
    {
        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.username = username;
        this.uploadesVideos = new List<SayaTubeVideo>();
    }

    public int GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;

        foreach (SayaTubeVideo video in this.uploadesVideos)
        {
            totalPlayCount += video.GetPlayCount();
        }
        return totalPlayCount;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        this.uploadesVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + this.username);
        for (int i = 0; i < this.uploadesVideos.Count; i++)
        {
            Console.WriteLine("Video" + " " + (i + 1) + " judul: " + uploadesVideos[i].GetTitle());
        }
    }
}

class jurnalMod6_103022300072
{
    public static void Main()
    {
        SayaTubeUser user = new SayaTubeUser("Dhea Sri Noor Septianiz");
        List<String> judulFilm = new List<String>
        {
            "Review Film The Lord Of The Rings",
            "Review Film Inception",
            "Review Film The Dark Knight",
            "Review Film Interstellar",
            "Review Film Tenet",
            "Review Film Dunkirk",
            "Review Film The Prestige",
            "Review Film The Hungers Games",
            "Review Film The Hobbit",
            "Review Film Captain America The First Avengers"
        };

        foreach (String judul in judulFilm)
        {
            SayaTubeVideo video = new SayaTubeVideo(judul);
            video.IncreasePlayCount(100);
            user.AddVideo(video);
        }

        user.PrintAllVideoPlaycount();
    }
}
