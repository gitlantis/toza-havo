using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonnitorAPI
{
    public class Constants
    {
        static public int diffMins = 3;
        static public string connectionStrings = "Host=localhost; Database=stationdb; Username=postgres; Password=S_ltek2023";
        static public string JWT_SecureKey = "ca721231-b28d-412e-9a3e-9cd6cc6b864d";
        static public string JWT_Issuer = "https://api.webscada.uz";
        static public string JWT_Audience = "https://api.webscada.uz";
        static public int JWT_Expire = 1;

        static public string FirebaseSecret = "AIzaSyBr34QbVS74ydez93fgavHgL80h9nRF5DY";//"OA4QKAKnS5wwys2hLMz47QIwutkh1x0UYT1Gc8RY",
        static public string FirebaseUrl = "https://friendlychat-43477.firebaseapp.com/";//"https://devconsole-f3fdb-default-rtdb.firebaseio.com/"
        static public string baseTree = "InputData";

        //redis server
        static public string redis = "localhost:6379,password='OMZ23HCGu8WTA93z4dNglkoArdCjTOVfSaRndgZ0Wyk/w01aA6Zb33kMybEEYwpXWmT6NgmYtEyk8BIl'";

        static public Dictionary<string, string> InstantValues = new Dictionary<string, string>() {
            { "temperature", "temperature"},
            { "humadity", "humadity"},
            { "pressure", "pressure"},
            { "wind", "wind"},
            { "radiation", "radiation"}
        };
    }
}
