using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace cat.itb.M6UF1EA3_GorriaranMarcos;

public class Driver
{
    public static void Main()
    {
        const string UsersPath = @"..\..\..\people.json";
        Console.WriteLine(ACT1ReadRertaurantIdent(UsersPath));
        ACT2UpdateNewFriend(UsersPath);
    }
    public static string ACT1ReadRertaurantIdent(string path)
    {
        StreamReader file = new StreamReader(path);
        List<User> users = new List<User>(JsonConvert.DeserializeObject<User[]>(file.ReadToEnd()));
        return System.Text.Json.JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
    }
    public static void ACT2UpdateNewFriend(string path)
    {
        StreamWriter fileWriter;
        StreamReader file = new StreamReader(path);
        List<User> users = new List<User>(JsonConvert.DeserializeObject<User[]>(file.ReadToEnd()));
        List<Friend> friends;
        file.Close();
        for(int i = 0; i < users.Count; i++)
        {
            if (users[i].name=="Julia Young")
            {
                friends = new List<Friend>(users[i].friends);
                friends.Add(new Friend()
                {
                    id=4,
                    name="Trinity Ford"
                });
                users[i].friends = friends.ToArray();
            }
            
        }
        fileWriter = new StreamWriter(path);
        fileWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(users.ToArray(), new JsonSerializerOptions { WriteIndented = true }));
    }
    public static void ACT3SelectAndStoreAdults(string path)
    {
        StreamWriter fileWriter;
        StreamReader file = new StreamReader(path);
        List<User> users = new List<User>(JsonConvert.DeserializeObject<User[]>(file.ReadToEnd()));
        List<User> adultUser = new List<User>();
        file.Close();

        for(int i = 0; i < users.Count; i++)
        {
            if (users[i].age > 25)
            {
                adultUser.Add(users[i]);
            }
        }
        fileWriter = new StreamWriter(path);
        fileWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(adultUser.ToArray(), new JsonSerializerOptions { WriteIndented = true }));
    }
}