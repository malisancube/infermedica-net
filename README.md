# infermedica-net
.NET library for InferMedica https://developer.infermedica.com/docs/api

### Setting up

Get you API key from infermedica.com and setup in the following way

Add the following nuget package https://www.nuget.org/packages/Infermedica.Net/1.0.0

and setup the following on your code

```
            var client = new HttpClient();
            var settings = new InferMedicaSettings
            {
                AppName = "MyApp",
                AppUrl = "https://api.infermedica.com/v2",
                AppId = "xxx",
                AppKey = "xxxxxx",
                DevMode = true
            };
            _inferMedicaClient = new InferMedicaClient(client, settings);
```

See the sample for usage 

### Demo

![](/docs/demo.gif)

### Contributing

Feel free to raise an issue. I accept Pull requests

