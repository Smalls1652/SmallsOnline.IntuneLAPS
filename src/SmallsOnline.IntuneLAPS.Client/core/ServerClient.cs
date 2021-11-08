using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using SmallsOnline.IntuneLAPS.Client.Core;
using SmallsOnline.IntuneLAPS.Lib.Models.Communication;
using SmallsOnline.IntuneLAPS.Lib.Models.Config;

namespace SmallsOnline.IntuneLAPS.Client.Core
{
    public class ServerClient : IDisposable
    {
        private bool _isDisposed;
        public ServerClient(LAPSConfig lapsConfig)
        {
            serverHttpClient = new();
            serverUri = lapsConfig.LAPSUri;
        }

        private readonly HttpClient serverHttpClient;
        private readonly Uri serverUri;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void UpdateAccountPassword(string password)
        {
            SetPasswordPost passwordPostBody = new(Environment.GetEnvironmentVariable("ComputerName"), password);

            HttpRequestMessage requestMessage = new(HttpMethod.Post, serverUri);
            requestMessage.Content = new StringContent(passwordPostBody.ToJsonString());

            Task sendMessageTask = Task.Run(() => SendClientMessage(requestMessage));
            Task.WaitAll(sendMessageTask);
            requestMessage.Dispose();
        }

        private async Task SendClientMessage(HttpRequestMessage requestMessage)
        {
            await serverHttpClient.SendAsync(requestMessage);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    serverHttpClient.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}