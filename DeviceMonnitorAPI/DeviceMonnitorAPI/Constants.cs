using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceMonnitorAPI
{
    public class Constants
    {
        static public int diffMins = 3;
        static public string connectionStrings = "server=127.0.0.1; port=3306; database=_devcontroldb01; user=root; password=; Persist Security Info=False; Connect Timeout=300";
        static public string JWT_SecureKey = "ca721231-b28d-412e-9a3e-9cd6cc6b864d";
        static public string JWT_Issuer = "https://api.webscada.uz";
        static public string JWT_Audience = "https://api.webscada.uz";
        static public int JWT_Expire = 1;

        static public string FirebaseSecret = "AIzaSyBr34QbVS74ydez93fgavHgL80h9nRF5DY";//"OA4QKAKnS5wwys2hLMz47QIwutkh1x0UYT1Gc8RY",
        static public string FirebaseUrl = "https://friendlychat-43477.firebaseapp.com/";//"https://devconsole-f3fdb-default-rtdb.firebaseio.com/"
        static public string baseTree = "InputData";
        
        //redis server
        static public string redis = "localhsot:6379";

    }
}
