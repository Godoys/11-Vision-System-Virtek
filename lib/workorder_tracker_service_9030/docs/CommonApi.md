# WorkorderTrackerService.Swagger.Api.CommonApi

All URIs are relative to *http://localhost:9030*

 Method                                                                                  | HTTP request        | Description                        
-----------------------------------------------------------------------------------------|---------------------|------------------------------------
 [**WorkOrderTrackerServiceGetVersion**](CommonApi.md#workordertrackerservicegetversion) | **GET** /GetVersion | Returns the version of the service 

<a name="workordertrackerservicegetversion"></a>

# **WorkOrderTrackerServiceGetVersion**

> ResultDtoApiVersionDto WorkOrderTrackerServiceGetVersion ()

Returns the version of the service

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetVersionExample
    {
        public void main()
        {
            var apiInstance = new CommonApi();

            try
            {
                // Returns the version of the service
                ResultDtoApiVersionDto result = apiInstance.WorkOrderTrackerServiceGetVersion();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CommonApi.WorkOrderTrackerServiceGetVersion: " + e.Message );
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

