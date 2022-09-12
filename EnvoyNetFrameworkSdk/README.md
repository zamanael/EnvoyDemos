# Target Framwork
.NET Framework 4.7.2

# ngrok cmd
ngrok http https://localhost:44318 --host-header=localhost:44318

# webhook
  <appSettings>
    <add key="MS_WebHookReceiverSecret_GenericJson" value="80ad19e357b01a04fe767067df7cd31b96a844e1" />
  </appSettings>

You can test this using postman with url {{webhook_base_url}}/api/webhooks/incoming/GenericJson?code=80ad19e357b01a04fe767067df7cd31b96a844e1
Method: POST; Json Body: {"event": "foo","foo":"bar"}