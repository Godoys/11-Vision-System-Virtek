# WorkorderService.Swagger.Api.PartSerialOperationsApi

All URIs are relative to *http://localhost:9020*

 Method                                                                                                            | HTTP request                      | Description                                                                           
-------------------------------------------------------------------------------------------------------------------|-----------------------------------|---------------------------------------------------------------------------------------
 [**WorkOrderServiceAddNewPartSerial**](PartSerialOperationsApi.md#workorderserviceaddnewpartserial)               | **POST** /AddNewPartSerial        | Add a new PartSerial number to the specified work Order.                              
 [**WorkOrderServiceGetWorkOrderPartSerials**](PartSerialOperationsApi.md#workorderservicegetworkorderpartserials) | **POST** /GetWorkOrderPartSerials | Returns a list of available Part Serial Numbers and status of the specified WorkOrder 

<a name="workorderserviceaddnewpartserial"></a>

# **WorkOrderServiceAddNewPartSerial**

> ResultDto WorkOrderServiceAddNewPartSerial (PartSerialInfoDto partSerialInfoDto)

Add a new PartSerial number to the specified work Order.

This in case Part Serial Configuration is enabled

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceAddNewPartSerialExample
    {
        public void main()
        {
            var apiInstance = new PartSerialOperationsApi();
            var partSerialInfoDto = new PartSerialInfoDto(); // PartSerialInfoDto | Name of the Work Order as well as the PartSerial and the client

            try
            {
                // Add a new PartSerial number to the specified work Order.
                ResultDto result = apiInstance.WorkOrderServiceAddNewPartSerial(partSerialInfoDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PartSerialOperationsApi.WorkOrderServiceAddNewPartSerial: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                  | Type                                          | Description                                                     | Notes 
-----------------------|-----------------------------------------------|-----------------------------------------------------------------|-------
 **partSerialInfoDto** | [**PartSerialInfoDto**](PartSerialInfoDto.md) | Name of the Work Order as well as the PartSerial and the client |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetworkorderpartserials"></a>

# **WorkOrderServiceGetWorkOrderPartSerials**

> ResultDtoListPartSerialDto WorkOrderServiceGetWorkOrderPartSerials (WorkOrderNameInfoDto workOrderNameInfoDto)

Returns a list of available Part Serial Numbers and status of the specified WorkOrder

Lists all Part Serials within a Work Order * **WorkOrder name ** -Return all part Serials for the work Order named in
the parameter

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetWorkOrderPartSerialsExample
    {
        public void main()
        {
            var apiInstance = new PartSerialOperationsApi();
            var workOrderNameInfoDto = new WorkOrderNameInfoDto(); // WorkOrderNameInfoDto | WorkOrder Information

            try
            {
                // Returns a list of available Part Serial Numbers and status of the specified WorkOrder
                ResultDtoListPartSerialDto result = apiInstance.WorkOrderServiceGetWorkOrderPartSerials(workOrderNameInfoDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PartSerialOperationsApi.WorkOrderServiceGetWorkOrderPartSerials: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                     | Type                                                | Description           | Notes 
--------------------------|-----------------------------------------------------|-----------------------|-------
 **workOrderNameInfoDto** | [**WorkOrderNameInfoDto**](WorkOrderNameInfoDto.md) | WorkOrder Information |

### Return type

[**ResultDtoListPartSerialDto**](ResultDtoListPartSerialDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

