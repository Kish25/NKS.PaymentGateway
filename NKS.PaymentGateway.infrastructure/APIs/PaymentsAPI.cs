namespace NKS.Payments.Infrastructure.APIs
{
    using System;
    using Core.Entities;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class PaymentsApi : Core.Interfaces.IPaymentsAPI
    {
        private readonly IOptions<CheckoutBankAPISetting> _apiConfiguration;
        private readonly IFakeResultProvider _fakeResultProvider;
        private readonly HttpClient _client;
        private readonly ICalendar _calendar;

        public PaymentsApi(IOptions<CheckoutBankAPISetting> apiConfiguration,
                           IFakeResultProvider fakeResultProvider,
                           HttpClient client, ICalendar calendar)
        {
            _apiConfiguration = apiConfiguration;
            _fakeResultProvider = fakeResultProvider;
            _client = client;
            _calendar = calendar;
        }

        public async Task<PaymentAPIResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            if (!_apiConfiguration.Value.MakeRealApiCall)
                return _fakeResultProvider.ReturnSuccessResultAsync();

            if (string.IsNullOrEmpty(_apiConfiguration.Value.BaseUri) ||
                string.IsNullOrWhiteSpace(_apiConfiguration.Value.BaseUri))
                throw new UriFormatException("");

            HttpResponseMessage response = ExecuteRequest(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PaymentAPIResponse>(responseContent);
            result.ProcessedDate = _calendar.UtcDateTimeNow();

            return result;
        }

        private HttpResponseMessage ExecuteRequest(PaymentRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_apiConfiguration.Value.BaseUri, content).Result;
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
