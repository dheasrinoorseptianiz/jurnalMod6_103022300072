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
        if (title == null)
        {
            throw new ArgumentNullException("Judul Video Tidak boleh Null.");
        }

        if (title.Length > 200)
        {
            throw new ArgumentException("Judul Video tidak boleh lebih dari 200 karakter.");
        }

        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Play count tidak boleh negatif.");
        }

        if (count > 25000000)
        {
            throw new ArgumentException("Play count tidak boleh lebih dari 25000000.");
        }

        checked
        {
            try
            {
                this.playCount++;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Play count melebihi batas maksimum.");
            }
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + this.id);
        Console.WriteLine("Video Title: " + this.title);
        Console.WriteLine("Video Play Count: " + this.playCount);
    }

    public int GetPlayCount()
    {
        return playCount;
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
        if (username == null)
        {
            throw new ArgumentNullException("Username tidak boleh Null.");
        }

        if (username.Length > 100)
        {
            throw new ArgumentException("Username tidak boleh lebih dari 100 karakter.");
        }

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
        if (video == null)
        {
            throw new ArgumentNullException("Video yang ditambahkan tidak boleh Null.");
        }   

        if (video.GetPlayCount() >= int.MaxValue) 
        {
            throw new ArgumentException("Play count video terlalu besar.");
        }

        uploadesVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + this.username);
        for (int i = 0; i < Math.Min(uploadesVideos.Count, 8); i++)
        {
            Console.WriteLine("Video" + " " + (i + 1) + " judul: " + uploadesVideos[i].GetTitle());
        }
    }
}

class jurnalMod6_103022300072
{
    public static void Main()
    {
        try
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

            // uji coba overflow play count
            SayaTubeVideo testVideo = new SayaTubeVideo("Test Overflow Video");
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    testVideo.IncreasePlayCount(25000000);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception terjadi " + e.Message);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception di Main " + e.Message);
        }
    }
}
