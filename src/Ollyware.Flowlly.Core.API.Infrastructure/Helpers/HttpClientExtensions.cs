using Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;
using Polly;
using System.Text;
using System.Text.Json;

namespace Ollyware.Flowlly.Core.API.Infrastructure.Helpers;

public static class HttpClientExtensions
{
    public static async Task<ApiResponse<TOut>> PostAsync<TIn, TOut>(this HttpClient httpClient, string url, TIn payload)
    {
        var serializedPayload = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        using var response = await httpClient.PostAsync(url, serializedPayload);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return ApiResponse<TOut>.Failure();
        }

        var result = JsonSerializer.Deserialize<TOut>(responseContent);

        if (result is null)
        {
            return ApiResponse<TOut>.Failure();
        }

        return ApiResponse<TOut>.Success(result);
    }

    public static async Task<ApiResponse<TOut>> PostWithRetry<TIn, TOut>(this HttpClient httpClient, string url, TIn payload, int numberOfRetries = 3)
    {
        var serializedPayload = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var policy = Policy<HttpResponseMessage>
                            .HandleResult(r => !r.IsSuccessStatusCode)
                            .OrResult(r => r.Content is null)
                            .WaitAndRetryAsync(numberOfRetries, retryAttempt => TimeSpan.FromMilliseconds(100 * retryAttempt));

        using var response = await policy.ExecuteAsync(() => httpClient.PostAsync(url, serializedPayload));

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return ApiResponse<TOut>.Failure();
        }

        var result = JsonSerializer.Deserialize<TOut>(responseContent);

        if (result is null)
        {
            return ApiResponse<TOut>.Failure();
        }

        return ApiResponse<TOut>.Success(result);
    }

    public static async Task<ApiResponse<TOut>> GetAsync<TOut>(this HttpClient httpClient, string url)
    {
        using var response = await httpClient.GetAsync(url);

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return ApiResponse<TOut>.Failure();
        }

        var result = JsonSerializer.Deserialize<TOut>(responseContent);

        if (result is null)
        {
            return ApiResponse<TOut>.Failure();
        }

        return ApiResponse<TOut>.Success(result);
    }

    public static async Task<ApiResponse<TOut>> GetAsyncWithRetry<TOut>(this HttpClient httpClient, string url, int numberOfRetries = 3)
    {
        var policy = Policy<HttpResponseMessage>
                            .HandleResult(r => !r.IsSuccessStatusCode)
                            .OrResult(r => r.Content is null)
                            .WaitAndRetryAsync(numberOfRetries, retryAttempt => TimeSpan.FromMilliseconds(100 * retryAttempt));

        using var response = await policy.ExecuteAsync(() => httpClient.GetAsync(url));

        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            return ApiResponse<TOut>.Failure();
        }

        var result = JsonSerializer.Deserialize<TOut>(responseContent);

        if (result is null)
        {
            return ApiResponse<TOut>.Failure();
        }

        return ApiResponse<TOut>.Success(result);
    }
}