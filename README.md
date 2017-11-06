# README #

## Demo Project ##
https://github.com/KaneMuay/Juliet-Unity-Web-Request-API-Client

## Juliet-Unity-Web-Request-API
*Juliet-Unity-Web-Request-API is a Unity3D plugin for request API data with support REST API

## Support Device ##
* Android
* iOS
* PC Standalone

## How do I get set up? ##
1. Add a DLL file to Unity Project

## Unity Version Support ##
* 5.xx and above version
* Run on .NET 4.6

## How To Use ##

### Create Juliet instance ###
```csharp
  _juliet = new Juliet(DebugMode.Enable);
```
### Set header request ###
![Screenshot](https://s1.postimg.org/84un6xdjjz/image.png)

### Set optional header request ###
```csharp
  JulietConfigure.Instance.SetOptionalKeyHeader("X-Access-Token", "X-User");
  JulietConfigure.Instance.SetOptionalValueHeader(accessToken, id);
  JulietConfigure.Instance.UpdateHeader();
```

### Calling API Login ###
```csharp
   _juliet.Request.LoginRequest()
     .SetURL("https://api-server.com/auth/login", MethodType.POST)
     .SetUsername(request.username)
     .SetPassword(request.password)
     .SetRefreshToken(request.refreshToken)
     .Send(OnLogin, OnLoginFailed);
```

### Calling API Request Data ###
```csharp
   _juliet.Request.CommonRequest()
     .SetURL("https://api-server.com/characters/{0}", MethodType.GET, characterId)
     .Send(OnRequestCharacter, FailCallback ?? OnRequestFailed);
```

### Checking Response ###

Data will return json string format, you can serialize json format to object class.
```csharp
   public void OnRequestFailed(string result)
    {
        ResponseMessage response = JsonUtility.FromJson<ResponseMessage>(result);
    }
```

### Warning ###
at currently still not support PATCH method, it will be update on next version.

## License
Juliet-Unity-Web-Request-API is licensed under the MIT license:
www.opensource.org/licenses/MIT

## Copyright
Copyright (c) 2017 Garvil Villadiego.
