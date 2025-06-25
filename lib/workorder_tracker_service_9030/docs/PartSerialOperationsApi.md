# WorkorderTrackerService.Swagger.Api.PartSerialOperationsApi

All URIs are relative to *http://localhost:9030*

 Method                                                                                                                          | HTTP request                      | Description                                                      
---------------------------------------------------------------------------------------------------------------------------------|-----------------------------------|------------------------------------------------------------------
 [**WorkOrderTrackerServiceGetWorkOrderPartSerials**](PartSerialOperationsApi.md#workordertrackerservicegetworkorderpartserials) | **POST** /GetWorkOrderPartSerials | Provides a list of all Part Serials of the Work Order (if any ). 

<a name="workordertrackerservicegetworkorderpartserials"></a>

# **WorkOrderTrackerServiceGetWorkOrderPartSerials**

> ResultDtoListPartSerialDto WorkOrderTrackerServiceGetWorkOrderPartSerials (WorkOrderNameInfoDto workOrderName)

Provides a list of all Part Serials of the Work Order (if any ).

This in case Part Serial Configuration is enabled

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetWorkOrderPartSerialsExample
    {
        public void main()
        {
            var apiInstance = new PartSerialOperationsApi();
            var workOrderName = new WorkOrderNameInfoDto(); // WorkOrderNameInfoDto | Name of the Work Order

            try
            {
                // Provides a list of all Part Serials of the Work Order (if any ).
                ResultDtoListPartSerialDto result = apiInstance.WorkOrderTrackerServiceGetWorkOrderPartSerials(workOrderName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PartSerialOperationsApi.WorkOrderTrackerServiceGetWorkOrderPartSerials: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                                | Description            | Notes 
-------------------|-----------------------------------------------------|------------------------|-------
 **workOrderName** | [**WorkOrderNameInfoDto**](WorkOrderNameInfoDto.md) | Name of the Work Order |

### Return type

[**ResultDtoListPartSerialDto**](ResultDtoListPartSerialDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

