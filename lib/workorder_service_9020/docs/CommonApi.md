# WorkorderService.Swagger.Api.CommonApi

All URIs are relative to *http://localhost:9020*

Method | HTTP request | Description
------------- | ------------- | -------------
[**WorkOrderServiceGetVersion**](CommonApi.md#workorderservicegetversion) | **GET** /GetVersion | Returns the version of the service


<a name="workorderservicegetversion"></a>
# **WorkOrderServiceGetVersion**
> ResultDtoApiVersionDto WorkOrderServiceGetVersion ()

Returns the version of the service

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetVersionExample
    {
        public void main()
        {
            var apiInstance = new CommonApi();

            try
            {
                // Returns the version of the service
                ResultDtoApiVersionDto result = apiInstance.WorkOrderServiceGetVersion();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CommonApi.WorkOrderServiceGetVersion: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**ResultDtoApiVersionDto**](ResultDtoApiVersionDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

