# VisionAndProjectionService.Swagger.Api.MessageApi

All URIs are relative to *http://localhost:9015*

Method | HTTP request | Description
------------- | ------------- | -------------
[**MessagePost**](MessageApi.md#messagepost) | **POST** /Message | 


<a name="messagepost"></a>
# **MessagePost**
> void MessagePost (string jsonObject)



### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class MessagePostExample
    {
        public void main()
        {
            var apiInstance = new MessageApi();
            var jsonObject = jsonObject_example;  // string | 

            try
            {
                apiInstance.MessagePost(jsonObject);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling MessageApi.MessagePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **jsonObject** | **string**|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

